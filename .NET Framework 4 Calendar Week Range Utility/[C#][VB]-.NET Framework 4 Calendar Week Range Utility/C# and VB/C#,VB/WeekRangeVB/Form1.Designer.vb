<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.WeekRangeLabel = New System.Windows.Forms.Label()
      Me.WeekRanges = New System.Windows.Forms.TextBox()
      Me.Calculate = New System.Windows.Forms.Button()
      Me.CalendarLabel = New System.Windows.Forms.Label()
      Me.CalendarsList = New System.Windows.Forms.ComboBox()
      Me.DayOfWeekLabel = New System.Windows.Forms.Label()
      Me.DayOfWeekList = New System.Windows.Forms.ComboBox()
      Me.RuleGroup = New System.Windows.Forms.GroupBox()
      Me.FirstFourDayWeek = New System.Windows.Forms.RadioButton()
      Me.FirstFullWeek = New System.Windows.Forms.RadioButton()
      Me.FirstDay = New System.Windows.Forms.RadioButton()
      Me.YearsLabel = New System.Windows.Forms.Label()
      Me.YearsList = New System.Windows.Forms.ComboBox()
      Me.StatusBar = New System.Windows.Forms.StatusStrip()
      Me.EraLabel = New System.Windows.Forms.Label()
      Me.ErasList = New System.Windows.Forms.ComboBox()
      Me.RuleGroup.SuspendLayout()
      Me.SuspendLayout()
      '
      'WeekRangeLabel
      '
      Me.WeekRangeLabel.AutoSize = True
      Me.WeekRangeLabel.Location = New System.Drawing.Point(250, 22)
      Me.WeekRangeLabel.Name = "WeekRangeLabel"
      Me.WeekRangeLabel.Size = New System.Drawing.Size(79, 13)
      Me.WeekRangeLabel.TabIndex = 19
      Me.WeekRangeLabel.Text = "Week Ranges:"
      '
      'WeekRanges
      '
      Me.WeekRanges.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.WeekRanges.Location = New System.Drawing.Point(311, 36)
      Me.WeekRanges.Multiline = True
      Me.WeekRanges.Name = "WeekRanges"
      Me.WeekRanges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.WeekRanges.Size = New System.Drawing.Size(248, 283)
      Me.WeekRanges.TabIndex = 18
      '
      'Calculate
      '
      Me.Calculate.Location = New System.Drawing.Point(25, 291)
      Me.Calculate.Name = "Calculate"
      Me.Calculate.Size = New System.Drawing.Size(75, 28)
      Me.Calculate.TabIndex = 17
      Me.Calculate.Text = "Text"
      Me.Calculate.UseVisualStyleBackColor = True
      '
      'CalendarLabel
      '
      Me.CalendarLabel.AutoSize = True
      Me.CalendarLabel.Location = New System.Drawing.Point(19, 22)
      Me.CalendarLabel.Name = "CalendarLabel"
      Me.CalendarLabel.Size = New System.Drawing.Size(33, 13)
      Me.CalendarLabel.TabIndex = 16
      Me.CalendarLabel.Text = "Label"
      '
      'CalendarsList
      '
      Me.CalendarsList.FormattingEnabled = True
      Me.CalendarsList.Location = New System.Drawing.Point(87, 19)
      Me.CalendarsList.Name = "CalendarsList"
      Me.CalendarsList.Size = New System.Drawing.Size(121, 21)
      Me.CalendarsList.TabIndex = 15
      '
      'DayOfWeekLabel
      '
      Me.DayOfWeekLabel.AutoSize = True
      Me.DayOfWeekLabel.Location = New System.Drawing.Point(22, 237)
      Me.DayOfWeekLabel.Name = "DayOfWeekLabel"
      Me.DayOfWeekLabel.Size = New System.Drawing.Size(33, 13)
      Me.DayOfWeekLabel.TabIndex = 14
      Me.DayOfWeekLabel.Text = "Label"
      '
      'DayOfWeekList
      '
      Me.DayOfWeekList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.DayOfWeekList.FormattingEnabled = True
      Me.DayOfWeekList.Location = New System.Drawing.Point(69, 253)
      Me.DayOfWeekList.Name = "DayOfWeekList"
      Me.DayOfWeekList.Size = New System.Drawing.Size(121, 21)
      Me.DayOfWeekList.TabIndex = 13
      '
      'RuleGroup
      '
      Me.RuleGroup.Controls.Add(Me.FirstFourDayWeek)
      Me.RuleGroup.Controls.Add(Me.FirstFullWeek)
      Me.RuleGroup.Controls.Add(Me.FirstDay)
      Me.RuleGroup.Location = New System.Drawing.Point(22, 122)
      Me.RuleGroup.Name = "RuleGroup"
      Me.RuleGroup.Size = New System.Drawing.Size(200, 103)
      Me.RuleGroup.TabIndex = 12
      Me.RuleGroup.TabStop = False
      Me.RuleGroup.Text = "Label"
      '
      'FirstFourDayWeek
      '
      Me.FirstFourDayWeek.AutoSize = True
      Me.FirstFourDayWeek.Location = New System.Drawing.Point(15, 70)
      Me.FirstFourDayWeek.Name = "FirstFourDayWeek"
      Me.FirstFourDayWeek.Size = New System.Drawing.Size(46, 17)
      Me.FirstFourDayWeek.TabIndex = 2
      Me.FirstFourDayWeek.TabStop = True
      Me.FirstFourDayWeek.Text = "Text"
      Me.FirstFourDayWeek.UseVisualStyleBackColor = True
      '
      'FirstFullWeek
      '
      Me.FirstFullWeek.AutoSize = True
      Me.FirstFullWeek.Location = New System.Drawing.Point(15, 47)
      Me.FirstFullWeek.Name = "FirstFullWeek"
      Me.FirstFullWeek.Size = New System.Drawing.Size(46, 17)
      Me.FirstFullWeek.TabIndex = 1
      Me.FirstFullWeek.TabStop = True
      Me.FirstFullWeek.Text = "Text"
      Me.FirstFullWeek.UseVisualStyleBackColor = True
      '
      'FirstDay
      '
      Me.FirstDay.AutoSize = True
      Me.FirstDay.Location = New System.Drawing.Point(15, 23)
      Me.FirstDay.Name = "FirstDay"
      Me.FirstDay.Size = New System.Drawing.Size(46, 17)
      Me.FirstDay.TabIndex = 0
      Me.FirstDay.TabStop = True
      Me.FirstDay.Text = "Text"
      Me.FirstDay.UseVisualStyleBackColor = True
      '
      'YearsLabel
      '
      Me.YearsLabel.AutoSize = True
      Me.YearsLabel.Location = New System.Drawing.Point(19, 56)
      Me.YearsLabel.Name = "YearsLabel"
      Me.YearsLabel.Size = New System.Drawing.Size(33, 13)
      Me.YearsLabel.TabIndex = 11
      Me.YearsLabel.Text = "Label"
      '
      'YearsList
      '
      Me.YearsList.FormattingEnabled = True
      Me.YearsList.Location = New System.Drawing.Point(87, 56)
      Me.YearsList.Name = "YearsList"
      Me.YearsList.Size = New System.Drawing.Size(121, 21)
      Me.YearsList.TabIndex = 10
      '
      'StatusBar
      '
      Me.StatusBar.Location = New System.Drawing.Point(0, 339)
      Me.StatusBar.Name = "StatusBar"
      Me.StatusBar.Size = New System.Drawing.Size(601, 22)
      Me.StatusBar.TabIndex = 20
      Me.StatusBar.Text = "StatusStrip1"
      '
      'EraLabel
      '
      Me.EraLabel.AutoSize = True
      Me.EraLabel.Location = New System.Drawing.Point(19, 83)
      Me.EraLabel.Name = "EraLabel"
      Me.EraLabel.Size = New System.Drawing.Size(33, 13)
      Me.EraLabel.TabIndex = 22
      Me.EraLabel.Text = "Label"
      '
      'ErasList
      '
      Me.ErasList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ErasList.FormattingEnabled = True
      Me.ErasList.Location = New System.Drawing.Point(87, 83)
      Me.ErasList.Name = "ErasList"
      Me.ErasList.Size = New System.Drawing.Size(79, 21)
      Me.ErasList.TabIndex = 21
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(601, 361)
      Me.Controls.Add(Me.EraLabel)
      Me.Controls.Add(Me.ErasList)
      Me.Controls.Add(Me.StatusBar)
      Me.Controls.Add(Me.WeekRangeLabel)
      Me.Controls.Add(Me.WeekRanges)
      Me.Controls.Add(Me.Calculate)
      Me.Controls.Add(Me.CalendarLabel)
      Me.Controls.Add(Me.CalendarsList)
      Me.Controls.Add(Me.DayOfWeekLabel)
      Me.Controls.Add(Me.DayOfWeekList)
      Me.Controls.Add(Me.RuleGroup)
      Me.Controls.Add(Me.YearsLabel)
      Me.Controls.Add(Me.YearsList)
      Me.Name = "Form1"
      Me.Text = "<Title>"
      Me.RuleGroup.ResumeLayout(False)
      Me.RuleGroup.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents WeekRangeLabel As System.Windows.Forms.Label
   Private WithEvents WeekRanges As System.Windows.Forms.TextBox
   Private WithEvents Calculate As System.Windows.Forms.Button
   Private WithEvents CalendarLabel As System.Windows.Forms.Label
   Private WithEvents CalendarsList As System.Windows.Forms.ComboBox
   Private WithEvents DayOfWeekLabel As System.Windows.Forms.Label
   Private WithEvents DayOfWeekList As System.Windows.Forms.ComboBox
   Private WithEvents RuleGroup As System.Windows.Forms.GroupBox
   Private WithEvents FirstFourDayWeek As System.Windows.Forms.RadioButton
   Private WithEvents FirstFullWeek As System.Windows.Forms.RadioButton
   Private WithEvents FirstDay As System.Windows.Forms.RadioButton
   Private WithEvents YearsLabel As System.Windows.Forms.Label
   Private WithEvents YearsList As System.Windows.Forms.ComboBox
   Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
   Private WithEvents EraLabel As System.Windows.Forms.Label
   Private WithEvents ErasList As System.Windows.Forms.ComboBox

End Class
