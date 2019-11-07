   partial class Form1
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.YearsList = new System.Windows.Forms.ComboBox();
         this.YearsLabel = new System.Windows.Forms.Label();
         this.RuleGroup = new System.Windows.Forms.GroupBox();
         this.FirstFourDayWeek = new System.Windows.Forms.RadioButton();
         this.FirstFullWeek = new System.Windows.Forms.RadioButton();
         this.FirstDay = new System.Windows.Forms.RadioButton();
         this.DayOfWeekLabel = new System.Windows.Forms.Label();
         this.DayOfWeekList = new System.Windows.Forms.ComboBox();
         this.CalendarLabel = new System.Windows.Forms.Label();
         this.CalendarsList = new System.Windows.Forms.ComboBox();
         this.Calculate = new System.Windows.Forms.Button();
         this.WeekRanges = new System.Windows.Forms.TextBox();
         this.WeekRangeLabel = new System.Windows.Forms.Label();
         this.StatusBar = new System.Windows.Forms.StatusStrip();
         this.EraLabel = new System.Windows.Forms.Label();
         this.ErasList = new System.Windows.Forms.ComboBox();
         this.RuleGroup.SuspendLayout();
         this.SuspendLayout();
         // 
         // YearsList
         // 
         this.YearsList.FormattingEnabled = true;
         this.YearsList.Location = new System.Drawing.Point(77, 43);
         this.YearsList.Name = "YearsList";
         this.YearsList.Size = new System.Drawing.Size(121, 21);
         this.YearsList.TabIndex = 0;
         this.YearsList.SelectedIndexChanged += new System.EventHandler(this.YearsList_SelectedIndexChanged);
         // 
         // YearsLabel
         // 
         this.YearsLabel.AutoSize = true;
         this.YearsLabel.Location = new System.Drawing.Point(9, 43);
         this.YearsLabel.Name = "YearsLabel";
         this.YearsLabel.Size = new System.Drawing.Size(33, 13);
         this.YearsLabel.TabIndex = 1;
         this.YearsLabel.Text = "Label";
         // 
         // RuleGroup
         // 
         this.RuleGroup.Controls.Add(this.FirstFourDayWeek);
         this.RuleGroup.Controls.Add(this.FirstFullWeek);
         this.RuleGroup.Controls.Add(this.FirstDay);
         this.RuleGroup.Location = new System.Drawing.Point(12, 130);
         this.RuleGroup.Name = "RuleGroup";
         this.RuleGroup.Size = new System.Drawing.Size(200, 103);
         this.RuleGroup.TabIndex = 2;
         this.RuleGroup.TabStop = false;
         this.RuleGroup.Text = "Label";
         // 
         // FirstFourDayWeek
         // 
         this.FirstFourDayWeek.AutoSize = true;
         this.FirstFourDayWeek.Location = new System.Drawing.Point(15, 70);
         this.FirstFourDayWeek.Name = "FirstFourDayWeek";
         this.FirstFourDayWeek.Size = new System.Drawing.Size(46, 17);
         this.FirstFourDayWeek.TabIndex = 2;
         this.FirstFourDayWeek.TabStop = true;
         this.FirstFourDayWeek.Text = "Text";
         this.FirstFourDayWeek.UseVisualStyleBackColor = true;
         // 
         // FirstFullWeek
         // 
         this.FirstFullWeek.AutoSize = true;
         this.FirstFullWeek.Location = new System.Drawing.Point(15, 47);
         this.FirstFullWeek.Name = "FirstFullWeek";
         this.FirstFullWeek.Size = new System.Drawing.Size(46, 17);
         this.FirstFullWeek.TabIndex = 1;
         this.FirstFullWeek.TabStop = true;
         this.FirstFullWeek.Text = "Text";
         this.FirstFullWeek.UseVisualStyleBackColor = true;
         // 
         // FirstDay
         // 
         this.FirstDay.AutoSize = true;
         this.FirstDay.Location = new System.Drawing.Point(15, 23);
         this.FirstDay.Name = "FirstDay";
         this.FirstDay.Size = new System.Drawing.Size(46, 17);
         this.FirstDay.TabIndex = 0;
         this.FirstDay.TabStop = true;
         this.FirstDay.Text = "Text";
         this.FirstDay.UseVisualStyleBackColor = true;
         // 
         // DayOfWeekLabel
         // 
         this.DayOfWeekLabel.AutoSize = true;
         this.DayOfWeekLabel.Location = new System.Drawing.Point(9, 250);
         this.DayOfWeekLabel.Name = "DayOfWeekLabel";
         this.DayOfWeekLabel.Size = new System.Drawing.Size(33, 13);
         this.DayOfWeekLabel.TabIndex = 4;
         this.DayOfWeekLabel.Text = "Label";
         // 
         // DayOfWeekList
         // 
         this.DayOfWeekList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.DayOfWeekList.FormattingEnabled = true;
         this.DayOfWeekList.Location = new System.Drawing.Point(56, 266);
         this.DayOfWeekList.Name = "DayOfWeekList";
         this.DayOfWeekList.Size = new System.Drawing.Size(121, 21);
         this.DayOfWeekList.TabIndex = 3;
         // 
         // CalendarLabel
         // 
         this.CalendarLabel.AutoSize = true;
         this.CalendarLabel.Location = new System.Drawing.Point(9, 9);
         this.CalendarLabel.Name = "CalendarLabel";
         this.CalendarLabel.Size = new System.Drawing.Size(33, 13);
         this.CalendarLabel.TabIndex = 6;
         this.CalendarLabel.Text = "Label";
         // 
         // CalendarsList
         // 
         this.CalendarsList.FormattingEnabled = true;
         this.CalendarsList.Location = new System.Drawing.Point(77, 6);
         this.CalendarsList.Name = "CalendarsList";
         this.CalendarsList.Size = new System.Drawing.Size(121, 21);
         this.CalendarsList.TabIndex = 5;
         this.CalendarsList.SelectedIndexChanged += new System.EventHandler(this.CalendarsList_SelectedIndexChanged);
         // 
         // Calculate
         // 
         this.Calculate.Location = new System.Drawing.Point(15, 320);
         this.Calculate.Name = "Calculate";
         this.Calculate.Size = new System.Drawing.Size(75, 28);
         this.Calculate.TabIndex = 7;
         this.Calculate.Text = "Text";
         this.Calculate.UseVisualStyleBackColor = true;
         this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
         // 
         // WeekRanges
         // 
         this.WeekRanges.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.WeekRanges.Location = new System.Drawing.Point(301, 23);
         this.WeekRanges.Multiline = true;
         this.WeekRanges.Name = "WeekRanges";
         this.WeekRanges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
         this.WeekRanges.Size = new System.Drawing.Size(248, 325);
         this.WeekRanges.TabIndex = 8;
         // 
         // WeekRangeLabel
         // 
         this.WeekRangeLabel.AutoSize = true;
         this.WeekRangeLabel.Location = new System.Drawing.Point(240, 9);
         this.WeekRangeLabel.Name = "WeekRangeLabel";
         this.WeekRangeLabel.Size = new System.Drawing.Size(33, 13);
         this.WeekRangeLabel.TabIndex = 9;
         this.WeekRangeLabel.Text = "Label";
         // 
         // StatusBar
         // 
         this.StatusBar.Location = new System.Drawing.Point(0, 371);
         this.StatusBar.Name = "StatusBar";
         this.StatusBar.Size = new System.Drawing.Size(578, 22);
         this.StatusBar.SizingGrip = false;
         this.StatusBar.TabIndex = 10;
         // 
         // EraLabel
         // 
         this.EraLabel.AutoSize = true;
         this.EraLabel.Location = new System.Drawing.Point(9, 82);
         this.EraLabel.Name = "EraLabel";
         this.EraLabel.Size = new System.Drawing.Size(33, 13);
         this.EraLabel.TabIndex = 24;
         this.EraLabel.Text = "Label";
         // 
         // ErasList
         // 
         this.ErasList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.ErasList.FormattingEnabled = true;
         this.ErasList.Location = new System.Drawing.Point(77, 82);
         this.ErasList.Name = "ErasList";
         this.ErasList.Size = new System.Drawing.Size(79, 21);
         this.ErasList.TabIndex = 23;
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(578, 393);
         this.Controls.Add(this.EraLabel);
         this.Controls.Add(this.ErasList);
         this.Controls.Add(this.StatusBar);
         this.Controls.Add(this.WeekRangeLabel);
         this.Controls.Add(this.WeekRanges);
         this.Controls.Add(this.Calculate);
         this.Controls.Add(this.CalendarLabel);
         this.Controls.Add(this.CalendarsList);
         this.Controls.Add(this.DayOfWeekLabel);
         this.Controls.Add(this.DayOfWeekList);
         this.Controls.Add(this.RuleGroup);
         this.Controls.Add(this.YearsLabel);
         this.Controls.Add(this.YearsList);
         this.Name = "Form1";
         this.Text = "<Title>";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.RuleGroup.ResumeLayout(false);
         this.RuleGroup.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ComboBox YearsList;
      private System.Windows.Forms.Label YearsLabel;
      private System.Windows.Forms.GroupBox RuleGroup;
      private System.Windows.Forms.RadioButton FirstFourDayWeek;
      private System.Windows.Forms.RadioButton FirstFullWeek;
      private System.Windows.Forms.RadioButton FirstDay;
      private System.Windows.Forms.Label DayOfWeekLabel;
      private System.Windows.Forms.ComboBox DayOfWeekList;
      private System.Windows.Forms.Label CalendarLabel;
      private System.Windows.Forms.ComboBox CalendarsList;
      private System.Windows.Forms.Button Calculate;
      private System.Windows.Forms.TextBox WeekRanges;
      private System.Windows.Forms.Label WeekRangeLabel;
      private System.Windows.Forms.StatusStrip StatusBar;
      private System.Windows.Forms.Label EraLabel;
      private System.Windows.Forms.ComboBox ErasList;
   }


