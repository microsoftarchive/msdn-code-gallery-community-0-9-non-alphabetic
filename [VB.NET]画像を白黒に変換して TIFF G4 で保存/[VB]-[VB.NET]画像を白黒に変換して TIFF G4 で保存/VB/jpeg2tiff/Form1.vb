Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices

Public Class Form1
    Private Sub Form1_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        If Not BackgroundWorker1.IsBusy AndAlso e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Link
        End If
    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        If BackgroundWorker1.IsBusy Then Return

        Dim files = CType(e.Data.GetData(DataFormats.FileDrop), String())
        If files Is Nothing Then Return

        BackgroundWorker1.RunWorkerAsync(files)
    End Sub

    Private Sub Convert(f$)
        Using srcimg = New Bitmap(f)
            Dim dir1 = Path.GetDirectoryName(f)
            Dim dir2 = Path.Combine(dir1, "output")
            Dim f2 = Path.Combine(dir2, Path.GetFileNameWithoutExtension(f) + ".tiff")
            If Not Directory.Exists(dir2) Then Directory.CreateDirectory(dir2)
            SaveAsG4(srcimg, 160, f2)
        End Using
    End Sub

    Public Shared Function ConvertMonochrome(srcbmp As Bitmap, threshold%) As Bitmap
        Dim w = srcbmp.Width, h = srcbmp.Height, w2a = ((w + 31) \ 32) * 32
        Dim bd1 = srcbmp.LockBits(New Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb)
        Dim src(w * h * 4 - 1) As Byte
        Marshal.Copy(bd1.Scan0, src, 0, src.Length)
        srcbmp.UnlockBits(bd1)

        Dim dst(((w2a * h) \ 8) - 1) As Byte
        Dim p1 = 0
        For y = 0 To h - 1
            Dim p2 = (w2a \ 8) * y
            Dim b = 128
            For x = 0 To w - 1
                Dim v = (CInt(src(p1)) + CInt(src(p1 + 1)) + CInt(src(p1 + 2))) \ 3
                If v >= threshold Then dst(p2) += b
                p1 += 4
                b >>= 1
                If b = 0 Then
                    b = 128
                    p2 += 1
                End If
            Next
        Next

        Dim dstbmp = New Bitmap(w, h, PixelFormat.Format1bppIndexed)
        dstbmp.SetResolution(srcbmp.VerticalResolution, srcbmp.HorizontalResolution)
        Dim bd2 = dstbmp.LockBits(New Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format1bppIndexed)
        Marshal.Copy(dst, 0, bd2.Scan0, dst.Length)
        dstbmp.UnlockBits(bd2)
        Return dstbmp
    End Function

    Public Shared Sub SaveAsG4(srcbmp As Bitmap, threshold%, f$)
        Using dstbmp = ConvertMonochrome(srcbmp, threshold)
            Dim tiff = (From enc In ImageCodecInfo.GetImageEncoders() Where enc.MimeType = "image/tiff" Select enc)(0)
            Dim g4 = New EncoderParameters(2)
            g4.Param(0) = New EncoderParameter(Encoder.ColorDepth, 1)
            g4.Param(1) = New EncoderParameter(Encoder.Compression, EncoderValue.CompressionCCITT4)
            dstbmp.Save(f, tiff, g4)
        End Using
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim files = CType(e.Argument, String())
        For i = 1 To files.Length
            BackgroundWorker1.ReportProgress((i * 100) \ files.Length)
            Convert(files(i - 1))
        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As System.Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As System.Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Value = 0
    End Sub
End Class
