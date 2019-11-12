Imports System.IO
Imports System.Resources
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text

Module Encode64

   Public Const DefaultSize As Integer = 1024000

   Private BufferSize As Integer = DefaultSize
   Private CharsToRead As Integer = BufferSize \ 2

   Sub Main()
      Dim args() As String = Environment.GetCommandLineArgs()
      Dim toEncode, toDecode As Boolean

      ' Display application name.
      Console.WriteLine(My.Resources.CmdResources.AppName)

      ' Display help text if command line includes /?
      If args.Length < 3 Or Array.Exists(args, AddressOf New Switches("/?").IsSwitchSet) Then
         Console.WriteLine(My.Resources.CmdResources.HelpText)
         Exit Sub
      End If

      If Array.Exists(args, AddressOf New Switches("/e").IsSwitchSet) Then toEncode = True
      If Array.Exists(args, AddressOf New Switches("/d").IsSwitchSet) Then toDecode = True
      If Array.Exists(args, AddressOf New Switches("/s").HasSwitch) Then
         BufferSize = Switches.GetBufferSize(args)
         CharsToRead = BufferSize \ 2
      End If

      ' Make sure only an encode or a decode switch is present.
      If toEncode And toDecode Then
         Console.WriteLine(My.Resources.CmdResources.BadSwitches)
         Exit Sub
      ElseIf Not toEncode And Not toDecode Then
         toEncode = True
      End If

      ' Make sure the source file exists.
      Dim srcFile As String = args(args.Length - 2)
      Dim targetFile As String = args(args.Length - 1)
      If Not File.Exists(srcFile) Then
         Console.WriteLine(My.Resources.CmdResources.FileNotFound, srcFile)
         Exit Sub
      End If

      ' Perform the encoding or the decoding.
      If toEncode Then
         EncodeFile(srcFile, targetFile)
      Else
         DecodeFile(srcFile, targetFile)
      End If
   End Sub

   Private Sub EncodeFile(ByVal srcFile As String, ByVal targetFile As String)
      Dim bytes(BufferSize - 1) As Byte
      Dim fs As FileStream = Nothing
      Dim sw As StreamWriter = Nothing
      Dim fsOut As FileStream = Nothing
      Dim bytesRead As Integer = 0
      Dim totalBytesRead As Integer = 0

      ' Open srcFile in read-only mode.
      Try
         fs = New FileStream(srcFile, FileMode.Open, FileAccess.Read, FileShare.Read, BufferSize)
         Dim sourceSize As Long = New FileInfo(srcFile).Length

         If sourceSize <= BufferSize Then
            ' Open stream writer
            sw = New StreamWriter(targetFile, False, Encoding.ASCII)
            bytesRead = fs.Read(bytes, 0, BufferSize)

            If bytesRead > 0 Then
               Dim base64String As String = Convert.ToBase64String(bytes, 0, bytesRead)
               totalBytesRead += bytesRead
               Console.CursorLeft = 0
               Console.Write(My.Resources.CmdResources.ProgressEncodedMsg, totalBytesRead)
               sw.Write(base64String)
            End If
         Else
            ' Instantiate a ToBase64Transform object.
            Dim transf As New ToBase64Transform()
            ' Arrays to hold input and output bytes.
            Dim inputBytes(transf.InputBlockSize - 1) As Byte
            Dim outputBytes(transf.OutputBlockSize - 1) As Byte
            Dim bytesWritten As Integer

            fsOut = New FileStream(targetFile, FileMode.Create, FileAccess.Write)

            Do
               bytesRead = fs.Read(inputBytes, 0, inputBytes.Length)
               totalBytesRead += bytesRead
               bytesWritten = transf.TransformBlock(inputBytes, 0, bytesRead, outputBytes, 0)
               fsOut.Write(outputBytes, 0, bytesWritten)
            Loop While sourceSize - totalBytesRead > transf.InputBlockSize

            ' Transform the final block of data.
            bytesRead = fs.Read(inputBytes, 0, inputBytes.Length)
            Dim finalOutputBytes As Byte() = transf.TransformFinalBlock(inputBytes, 0, bytesRead)
            fsOut.Write(finalOutputBytes, 0, finalOutputBytes.Length)

            ' Clear Base64Transform object.
            transf.Clear()
         End If

         Console.WriteLine()
         Console.WriteLine(My.Resources.CmdResources.SuccessEncodedMsg, srcFile, targetFile)
      Catch e As IOException
         Console.WriteLine(My.Resources.CmdResources.IOException)
         Exit Sub
      Catch e As SecurityException
         Console.WriteLine(My.Resources.CmdResources.SecurityException, srcFile)
         Exit Sub
      Catch e As UnauthorizedAccessException
         Console.WriteLine(My.Resources.CmdResources.AccessException, srcFile)
         Exit Sub
      Finally
         If sw IsNot Nothing Then sw.Close()
         If fs IsNot Nothing Then fs.Dispose() : fs.Close()
         If fsOut IsNot Nothing Then fsOut.Dispose() : fsOut.Close()
      End Try
   End Sub

   Private Sub DecodeFile(ByVal srcFile As String, ByVal targetFile As String)

      Dim reader As TextReader = Nothing
      Dim fs As FileStream = Nothing
      Dim fsIn As FileStream = Nothing
      Dim sourceSize As Long = New FileInfo(srcFile).Length

      Try
         fs = New FileStream(targetFile, FileMode.Create, FileAccess.Write)

         ' Read entire file in a single operation.
         If sourceSize <= CharsToRead Then
            reader = New StreamReader(srcFile, Encoding.ASCII)

            Dim encodedChars As String = reader.ReadToEnd()

            Try
               Dim bytes() As Byte = Convert.FromBase64String(encodedChars)
               fs.Write(bytes, 0, bytes.Length)
            Catch e As FormatException
               Console.WriteLine(e.Message)
            End Try

            Console.CursorLeft = 0
         Else
            ' Read file as a stream into a buffer.

            ' Instantiate a FromBase64Transform object.
            Dim transf As New FromBase64Transform()
            ' Arrays to hold input and output bytes.
            Dim inputBytes(transf.InputBlockSize - 1) As Byte
            Dim outputBytes(transf.OutputBlockSize - 1) As Byte
            Dim bytesRead As Integer = 0
            Dim bytesWritten As Integer = 0
            Dim totalBytesRead As Integer = 0

            fsIn = New FileStream(srcFile, FileMode.Open, FileAccess.Read)

            Do
               bytesRead = fsIn.Read(inputBytes, 0, inputBytes.Length)
               totalBytesRead += bytesRead
               bytesWritten = transf.TransformBlock(inputBytes, 0, bytesRead, outputBytes, 0)
               fs.Write(outputBytes, 0, bytesWritten)
            Loop While sourceSize - totalBytesRead > transf.InputBlockSize

            ' Transform the final block of data.
            bytesRead = fsIn.Read(inputBytes, 0, inputBytes.Length)
            Dim finalOutputBytes As Byte() = transf.TransformFinalBlock(inputBytes, 0, bytesRead)
            fs.Write(finalOutputBytes, 0, finalOutputBytes.Length)

            ' Clear Base64Transform object.
            transf.Clear()
         End If

         Console.WriteLine()
         Console.WriteLine(My.Resources.CmdResources.SuccessDecodedMsg, srcFile, targetFile)
      Catch e As IOException
         Console.WriteLine(My.Resources.CmdResources.IOException)
         Exit Sub

      Finally
         If reader IsNot Nothing Then reader.Close()
         If fs IsNot Nothing Then fs.Close() : fs.Dispose()
         If fsIn IsNot Nothing Then fsIn.Close() : fs.Dispose()
      End Try
   End Sub
End Module
