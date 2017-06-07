namespace File_Renamer_V1._23B
{
    partial class progSettings
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
            this.settingsTabs = new System.Windows.Forms.TabControl();
            this.genSetting = new System.Windows.Forms.TabPage();
            this.cBoxWOnClose = new System.Windows.Forms.CheckBox();
            this.fOvSetting = new System.Windows.Forms.TabPage();
            this.cBoxOEFiles = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.settingsTabs.SuspendLayout();
            this.genSetting.SuspendLayout();
            this.fOvSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTabs
            // 
            this.settingsTabs.Controls.Add(this.genSetting);
            this.settingsTabs.Controls.Add(this.fOvSetting);
            this.settingsTabs.Location = new System.Drawing.Point(13, 13);
            this.settingsTabs.Name = "settingsTabs";
            this.settingsTabs.SelectedIndex = 0;
            this.settingsTabs.Size = new System.Drawing.Size(325, 187);
            this.settingsTabs.TabIndex = 0;
            // 
            // genSetting
            // 
            this.genSetting.BackColor = System.Drawing.Color.Transparent;
            this.genSetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.genSetting.Controls.Add(this.cBoxWOnClose);
            this.genSetting.Location = new System.Drawing.Point(4, 22);
            this.genSetting.Name = "genSetting";
            this.genSetting.Padding = new System.Windows.Forms.Padding(3);
            this.genSetting.Size = new System.Drawing.Size(317, 161);
            this.genSetting.TabIndex = 0;
            this.genSetting.Text = "General Settings";
            // 
            // cBoxWOnClose
            // 
            this.cBoxWOnClose.AutoSize = true;
            this.cBoxWOnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxWOnClose.Location = new System.Drawing.Point(6, 6);
            this.cBoxWOnClose.Name = "cBoxWOnClose";
            this.cBoxWOnClose.Size = new System.Drawing.Size(139, 21);
            this.cBoxWOnClose.TabIndex = 1;
            this.cBoxWOnClose.Text = "Warning on Close";
            this.cBoxWOnClose.UseVisualStyleBackColor = true;
            this.cBoxWOnClose.CheckedChanged += new System.EventHandler(this.cBoxWOnCloseChanged);
            // 
            // fOvSetting
            // 
            this.fOvSetting.BackColor = System.Drawing.Color.Transparent;
            this.fOvSetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fOvSetting.Controls.Add(this.cBoxOEFiles);
            this.fOvSetting.Location = new System.Drawing.Point(4, 22);
            this.fOvSetting.Name = "fOvSetting";
            this.fOvSetting.Padding = new System.Windows.Forms.Padding(3);
            this.fOvSetting.Size = new System.Drawing.Size(317, 161);
            this.fOvSetting.TabIndex = 1;
            this.fOvSetting.Text = "File Overwrite Settings";
            // 
            // cBoxOEFiles
            // 
            this.cBoxOEFiles.AutoSize = true;
            this.cBoxOEFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxOEFiles.Location = new System.Drawing.Point(7, 7);
            this.cBoxOEFiles.Name = "cBoxOEFiles";
            this.cBoxOEFiles.Size = new System.Drawing.Size(172, 21);
            this.cBoxOEFiles.TabIndex = 0;
            this.cBoxOEFiles.Text = "Overwrite Existing Files";
            this.cBoxOEFiles.UseVisualStyleBackColor = true;
            this.cBoxOEFiles.CheckedChanged += new System.EventHandler(this.cBoxOEFilesChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.closePanel);
            // 
            // progSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.settingsTabs);
            this.Name = "progSettings";
            this.Text = "Program Settings";
            this.settingsTabs.ResumeLayout(false);
            this.genSetting.ResumeLayout(false);
            this.genSetting.PerformLayout();
            this.fOvSetting.ResumeLayout(false);
            this.fOvSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl settingsTabs;
        private System.Windows.Forms.TabPage genSetting;
        private System.Windows.Forms.CheckBox cBoxWOnClose;
        private System.Windows.Forms.TabPage fOvSetting;
        private System.Windows.Forms.CheckBox cBoxOEFiles;
        private System.Windows.Forms.Button button1;
    }
}