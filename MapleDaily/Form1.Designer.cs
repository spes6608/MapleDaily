namespace MapleDaily
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbMainForm = new System.Windows.Forms.TabPage();
            this.pnlCheckItem = new System.Windows.Forms.Panel();
            this.pnlContorl = new System.Windows.Forms.Panel();
            this.btnDone = new System.Windows.Forms.Button();
            this.pnlCalendar = new System.Windows.Forms.Panel();
            this.tbMissionDaily = new System.Windows.Forms.TabPage();
            this.btnDeleteDaily = new System.Windows.Forms.Button();
            this.btnNewdaily = new System.Windows.Forms.Button();
            this.tbDaily = new System.Windows.Forms.TextBox();
            this.ckblDaily = new System.Windows.Forms.CheckedListBox();
            this.tbMissionWeekly = new System.Windows.Forms.TabPage();
            this.btnDeleteWeekly = new System.Windows.Forms.Button();
            this.btnNewWeekly = new System.Windows.Forms.Button();
            this.tbWeekly = new System.Windows.Forms.TextBox();
            this.ckblWeekly = new System.Windows.Forms.CheckedListBox();
            this.tbSetting = new System.Windows.Forms.TabPage();
            this.btnCleanFIle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbSettingFileSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPath = new System.Windows.Forms.Button();
            this.tbSignPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbMainForm.SuspendLayout();
            this.pnlContorl.SuspendLayout();
            this.tbMissionDaily.SuspendLayout();
            this.tbMissionWeekly.SuspendLayout();
            this.tbSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbMainForm);
            this.tabControl1.Controls.Add(this.tbMissionDaily);
            this.tabControl1.Controls.Add(this.tbMissionWeekly);
            this.tabControl1.Controls.Add(this.tbSetting);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 529);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tbMainForm
            // 
            this.tbMainForm.Controls.Add(this.pnlCheckItem);
            this.tbMainForm.Controls.Add(this.pnlContorl);
            this.tbMainForm.Controls.Add(this.pnlCalendar);
            this.tbMainForm.Location = new System.Drawing.Point(4, 28);
            this.tbMainForm.Name = "tbMainForm";
            this.tbMainForm.Padding = new System.Windows.Forms.Padding(3);
            this.tbMainForm.Size = new System.Drawing.Size(614, 497);
            this.tbMainForm.TabIndex = 0;
            this.tbMainForm.Text = "主頁面";
            this.tbMainForm.UseVisualStyleBackColor = true;
            // 
            // pnlCheckItem
            // 
            this.pnlCheckItem.Location = new System.Drawing.Point(379, 6);
            this.pnlCheckItem.Name = "pnlCheckItem";
            this.pnlCheckItem.Size = new System.Drawing.Size(229, 488);
            this.pnlCheckItem.TabIndex = 2;
            // 
            // pnlContorl
            // 
            this.pnlContorl.Controls.Add(this.btnDone);
            this.pnlContorl.Location = new System.Drawing.Point(6, 306);
            this.pnlContorl.Name = "pnlContorl";
            this.pnlContorl.Size = new System.Drawing.Size(367, 188);
            this.pnlContorl.TabIndex = 1;
            // 
            // btnDone
            // 
            this.btnDone.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnDone.Location = new System.Drawing.Point(230, 131);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(121, 44);
            this.btnDone.TabIndex = 0;
            this.btnDone.Text = "好MS寶簽到";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.Location = new System.Drawing.Point(6, 6);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Size = new System.Drawing.Size(367, 294);
            this.pnlCalendar.TabIndex = 0;
            // 
            // tbMissionDaily
            // 
            this.tbMissionDaily.Controls.Add(this.btnDeleteDaily);
            this.tbMissionDaily.Controls.Add(this.btnNewdaily);
            this.tbMissionDaily.Controls.Add(this.tbDaily);
            this.tbMissionDaily.Controls.Add(this.ckblDaily);
            this.tbMissionDaily.Location = new System.Drawing.Point(4, 28);
            this.tbMissionDaily.Name = "tbMissionDaily";
            this.tbMissionDaily.Padding = new System.Windows.Forms.Padding(3);
            this.tbMissionDaily.Size = new System.Drawing.Size(614, 497);
            this.tbMissionDaily.TabIndex = 1;
            this.tbMissionDaily.Text = "任務新增(每日)";
            this.tbMissionDaily.UseVisualStyleBackColor = true;
            // 
            // btnDeleteDaily
            // 
            this.btnDeleteDaily.Location = new System.Drawing.Point(472, 126);
            this.btnDeleteDaily.Name = "btnDeleteDaily";
            this.btnDeleteDaily.Size = new System.Drawing.Size(124, 45);
            this.btnDeleteDaily.TabIndex = 3;
            this.btnDeleteDaily.Text = "刪除";
            this.btnDeleteDaily.UseVisualStyleBackColor = true;
            this.btnDeleteDaily.Click += new System.EventHandler(this.btnDeleteDaily_Click);
            // 
            // btnNewdaily
            // 
            this.btnNewdaily.Location = new System.Drawing.Point(472, 75);
            this.btnNewdaily.Name = "btnNewdaily";
            this.btnNewdaily.Size = new System.Drawing.Size(124, 45);
            this.btnNewdaily.TabIndex = 2;
            this.btnNewdaily.Text = "新增";
            this.btnNewdaily.UseVisualStyleBackColor = true;
            this.btnNewdaily.Click += new System.EventHandler(this.btnNewdaily_Click);
            // 
            // tbDaily
            // 
            this.tbDaily.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbDaily.Location = new System.Drawing.Point(352, 32);
            this.tbDaily.Name = "tbDaily";
            this.tbDaily.Size = new System.Drawing.Size(244, 37);
            this.tbDaily.TabIndex = 1;
            // 
            // ckblDaily
            // 
            this.ckblDaily.FormattingEnabled = true;
            this.ckblDaily.Items.AddRange(new object[] {
            "每日ARC",
            "每日AUT",
            "個人怪公",
            "組隊怪公"});
            this.ckblDaily.Location = new System.Drawing.Point(6, 6);
            this.ckblDaily.Name = "ckblDaily";
            this.ckblDaily.Size = new System.Drawing.Size(325, 488);
            this.ckblDaily.TabIndex = 0;
            // 
            // tbMissionWeekly
            // 
            this.tbMissionWeekly.Controls.Add(this.btnDeleteWeekly);
            this.tbMissionWeekly.Controls.Add(this.btnNewWeekly);
            this.tbMissionWeekly.Controls.Add(this.tbWeekly);
            this.tbMissionWeekly.Controls.Add(this.ckblWeekly);
            this.tbMissionWeekly.Location = new System.Drawing.Point(4, 28);
            this.tbMissionWeekly.Name = "tbMissionWeekly";
            this.tbMissionWeekly.Size = new System.Drawing.Size(614, 497);
            this.tbMissionWeekly.TabIndex = 2;
            this.tbMissionWeekly.Text = "任務新增(每周)";
            this.tbMissionWeekly.UseVisualStyleBackColor = true;
            // 
            // btnDeleteWeekly
            // 
            this.btnDeleteWeekly.Location = new System.Drawing.Point(478, 124);
            this.btnDeleteWeekly.Name = "btnDeleteWeekly";
            this.btnDeleteWeekly.Size = new System.Drawing.Size(124, 45);
            this.btnDeleteWeekly.TabIndex = 6;
            this.btnDeleteWeekly.Text = "刪除";
            this.btnDeleteWeekly.UseVisualStyleBackColor = true;
            this.btnDeleteWeekly.Click += new System.EventHandler(this.btnDeleteWeekly_Click);
            // 
            // btnNewWeekly
            // 
            this.btnNewWeekly.Location = new System.Drawing.Point(478, 73);
            this.btnNewWeekly.Name = "btnNewWeekly";
            this.btnNewWeekly.Size = new System.Drawing.Size(124, 45);
            this.btnNewWeekly.TabIndex = 5;
            this.btnNewWeekly.Text = "新增";
            this.btnNewWeekly.UseVisualStyleBackColor = true;
            this.btnNewWeekly.Click += new System.EventHandler(this.btnNewWeekly_Click);
            // 
            // tbWeekly
            // 
            this.tbWeekly.Font = new System.Drawing.Font("Microsoft JhengHei UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbWeekly.Location = new System.Drawing.Point(358, 30);
            this.tbWeekly.Name = "tbWeekly";
            this.tbWeekly.Size = new System.Drawing.Size(244, 37);
            this.tbWeekly.TabIndex = 4;
            // 
            // ckblWeekly
            // 
            this.ckblWeekly.FormattingEnabled = true;
            this.ckblWeekly.Items.AddRange(new object[] {
            "困7",
            "聯盟戰地(記得回任)",
            "下水道",
            "高山副本"});
            this.ckblWeekly.Location = new System.Drawing.Point(3, 6);
            this.ckblWeekly.Name = "ckblWeekly";
            this.ckblWeekly.Size = new System.Drawing.Size(325, 488);
            this.ckblWeekly.TabIndex = 1;
            // 
            // tbSetting
            // 
            this.tbSetting.Controls.Add(this.btnCleanFIle);
            this.tbSetting.Controls.Add(this.label3);
            this.tbSetting.Controls.Add(this.lbSettingFileSize);
            this.tbSetting.Controls.Add(this.label2);
            this.tbSetting.Controls.Add(this.btnPath);
            this.tbSetting.Controls.Add(this.tbSignPath);
            this.tbSetting.Controls.Add(this.label1);
            this.tbSetting.Location = new System.Drawing.Point(4, 28);
            this.tbSetting.Name = "tbSetting";
            this.tbSetting.Size = new System.Drawing.Size(614, 497);
            this.tbSetting.TabIndex = 3;
            this.tbSetting.Text = "設定";
            this.tbSetting.UseVisualStyleBackColor = true;
            // 
            // btnCleanFIle
            // 
            this.btnCleanFIle.Location = new System.Drawing.Point(416, 269);
            this.btnCleanFIle.Name = "btnCleanFIle";
            this.btnCleanFIle.Size = new System.Drawing.Size(108, 45);
            this.btnCleanFIle.TabIndex = 6;
            this.btnCleanFIle.Text = "清除簽到記錄";
            this.btnCleanFIle.UseVisualStyleBackColor = true;
            this.btnCleanFIle.Click += new System.EventHandler(this.btnCleanFIle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(469, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 36);
            this.label3.TabIndex = 5;
            this.label3.Text = "/kB";
            // 
            // lbSettingFileSize
            // 
            this.lbSettingFileSize.AutoSize = true;
            this.lbSettingFileSize.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbSettingFileSize.Location = new System.Drawing.Point(401, 230);
            this.lbSettingFileSize.Name = "lbSettingFileSize";
            this.lbSettingFileSize.Size = new System.Drawing.Size(53, 36);
            this.lbSettingFileSize.TabIndex = 4;
            this.lbSettingFileSize.Text = "0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(20, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 36);
            this.label2.TabIndex = 3;
            this.label2.Text = "簽到擋大小(若卡頓請清除)";
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(416, 125);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(108, 45);
            this.btnPath.TabIndex = 2;
            this.btnPath.Text = "選擇路徑";
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // tbSignPath
            // 
            this.tbSignPath.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbSignPath.Location = new System.Drawing.Point(26, 68);
            this.tbSignPath.Name = "tbSignPath";
            this.tbSignPath.ReadOnly = true;
            this.tbSignPath.Size = new System.Drawing.Size(498, 33);
            this.tbSignPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "簽到擋路徑";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 558);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.Text = "好MS寶簽到器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tbMainForm.ResumeLayout(false);
            this.pnlContorl.ResumeLayout(false);
            this.tbMissionDaily.ResumeLayout(false);
            this.tbMissionDaily.PerformLayout();
            this.tbMissionWeekly.ResumeLayout(false);
            this.tbMissionWeekly.PerformLayout();
            this.tbSetting.ResumeLayout(false);
            this.tbSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbMainForm;
        private System.Windows.Forms.TabPage tbMissionDaily;
        private System.Windows.Forms.TabPage tbMissionWeekly;
        private System.Windows.Forms.TabPage tbSetting;
        private System.Windows.Forms.Panel pnlCheckItem;
        private System.Windows.Forms.Panel pnlContorl;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Panel pnlCalendar;
        private System.Windows.Forms.CheckedListBox ckblDaily;
        private System.Windows.Forms.Button btnDeleteDaily;
        private System.Windows.Forms.Button btnNewdaily;
        private System.Windows.Forms.TextBox tbDaily;
        private System.Windows.Forms.CheckedListBox ckblWeekly;
        private System.Windows.Forms.Button btnDeleteWeekly;
        private System.Windows.Forms.Button btnNewWeekly;
        private System.Windows.Forms.TextBox tbWeekly;
        private System.Windows.Forms.Button btnCleanFIle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbSettingFileSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox tbSignPath;
        private System.Windows.Forms.Label label1;
    }
}

