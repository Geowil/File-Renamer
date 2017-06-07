namespace File_Renamer_V1._23B
{
    partial class fRenamer
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnRFiles = new System.Windows.Forms.Button();
            this.rBtnLSuff = new System.Windows.Forms.RadioButton();
            this.rBtnNumSuff = new System.Windows.Forms.RadioButton();
            this.rBtnNoSuff = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxRFName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dGVFileList = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxNumSuffix = new System.Windows.Forms.TextBox();
            this.cBoxLSuffix = new System.Windows.Forms.ComboBox();
            this.cBoxCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelAllFiles = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFileList)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select a Directory";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.selectDir);
            // 
            // btnRFiles
            // 
            this.btnRFiles.Location = new System.Drawing.Point(602, 254);
            this.btnRFiles.Name = "btnRFiles";
            this.btnRFiles.Size = new System.Drawing.Size(128, 23);
            this.btnRFiles.TabIndex = 1;
            this.btnRFiles.Text = "Rename Selected Files";
            this.btnRFiles.UseVisualStyleBackColor = true;
            this.btnRFiles.Click += new System.EventHandler(this.renameFiles);
            // 
            // rBtnLSuff
            // 
            this.rBtnLSuff.AutoSize = true;
            this.rBtnLSuff.Location = new System.Drawing.Point(18, 19);
            this.rBtnLSuff.Name = "rBtnLSuff";
            this.rBtnLSuff.Size = new System.Drawing.Size(103, 17);
            this.rBtnLSuff.TabIndex = 2;
            this.rBtnLSuff.TabStop = true;
            this.rBtnLSuff.Text = "Add Letter Suffix";
            this.rBtnLSuff.UseVisualStyleBackColor = true;
            this.rBtnLSuff.CheckedChanged += new System.EventHandler(this.rBtnLSuffChanged);
            // 
            // rBtnNumSuff
            // 
            this.rBtnNumSuff.AutoSize = true;
            this.rBtnNumSuff.Location = new System.Drawing.Point(18, 42);
            this.rBtnNumSuff.Name = "rBtnNumSuff";
            this.rBtnNumSuff.Size = new System.Drawing.Size(113, 17);
            this.rBtnNumSuff.TabIndex = 3;
            this.rBtnNumSuff.TabStop = true;
            this.rBtnNumSuff.Text = "Add Number Suffix";
            this.rBtnNumSuff.UseVisualStyleBackColor = true;
            this.rBtnNumSuff.CheckedChanged += new System.EventHandler(this.rBtnNumSuffChanged);
            // 
            // rBtnNoSuff
            // 
            this.rBtnNoSuff.AutoSize = true;
            this.rBtnNoSuff.Checked = true;
            this.rBtnNoSuff.Location = new System.Drawing.Point(18, 65);
            this.rBtnNoSuff.Name = "rBtnNoSuff";
            this.rBtnNoSuff.Size = new System.Drawing.Size(68, 17);
            this.rBtnNoSuff.TabIndex = 5;
            this.rBtnNoSuff.TabStop = true;
            this.rBtnNoSuff.Text = "No Suffix";
            this.rBtnNoSuff.UseVisualStyleBackColor = true;
            this.rBtnNoSuff.CheckedChanged += new System.EventHandler(this.rBtnNoSuffChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(581, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "New File Name";
            // 
            // tBoxRFName
            // 
            this.tBoxRFName.Location = new System.Drawing.Point(584, 228);
            this.tBoxRFName.MaxLength = 200;
            this.tBoxRFName.Name = "tBoxRFName";
            this.tBoxRFName.Size = new System.Drawing.Size(162, 20);
            this.tBoxRFName.TabIndex = 7;
            this.tBoxRFName.TextChanged += new System.EventHandler(this.tBoxRFNameChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBtnLSuff);
            this.groupBox1.Controls.Add(this.rBtnNumSuff);
            this.groupBox1.Controls.Add(this.rBtnNoSuff);
            this.groupBox1.Location = new System.Drawing.Point(584, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 93);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Renaming Options";
            // 
            // dGVFileList
            // 
            this.dGVFileList.AllowUserToAddRows = false;
            this.dGVFileList.AllowUserToDeleteRows = false;
            this.dGVFileList.AllowUserToResizeColumns = false;
            this.dGVFileList.AllowUserToResizeRows = false;
            this.dGVFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cBoxCol,
            this.fNameCol});
            this.dGVFileList.Location = new System.Drawing.Point(12, 91);
            this.dGVFileList.Name = "dGVFileList";
            this.dGVFileList.RowHeadersVisible = false;
            this.dGVFileList.Size = new System.Drawing.Size(553, 333);
            this.dGVFileList.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(877, 24);
            this.menuStrip1.TabIndex = 10;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeProg);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programSettingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // programSettingsToolStripMenuItem
            // 
            this.programSettingsToolStripMenuItem.Name = "programSettingsToolStripMenuItem";
            this.programSettingsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.programSettingsToolStripMenuItem.Text = "Program Settings";
            this.programSettingsToolStripMenuItem.Click += new System.EventHandler(this.openSettings);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(753, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Choose Starting Letter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(753, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Enter Starting Number";
            // 
            // tBoxNumSuffix
            // 
            this.tBoxNumSuffix.Enabled = false;
            this.tBoxNumSuffix.Location = new System.Drawing.Point(756, 164);
            this.tBoxNumSuffix.MaxLength = 5;
            this.tBoxNumSuffix.Name = "tBoxNumSuffix";
            this.tBoxNumSuffix.Size = new System.Drawing.Size(86, 20);
            this.tBoxNumSuffix.TabIndex = 13;
            this.tBoxNumSuffix.TextChanged += new System.EventHandler(this.tBoxNumSuffixChanged);
            // 
            // cBoxLSuffix
            // 
            this.cBoxLSuffix.Enabled = false;
            this.cBoxLSuffix.FormattingEnabled = true;
            this.cBoxLSuffix.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "AA",
            "BB",
            "CC",
            "DD",
            "EE",
            "FF",
            "GG",
            "HH",
            "II",
            "JJ",
            "KK",
            "LL",
            "MM",
            "NN",
            "OO",
            "PP",
            "QQ",
            "RR",
            "SS",
            "TT",
            "UU",
            "VV",
            "WW",
            "XX",
            "YY",
            "ZZ"});
            this.cBoxLSuffix.Location = new System.Drawing.Point(756, 110);
            this.cBoxLSuffix.MaxDropDownItems = 58;
            this.cBoxLSuffix.Name = "cBoxLSuffix";
            this.cBoxLSuffix.Size = new System.Drawing.Size(49, 21);
            this.cBoxLSuffix.TabIndex = 14;
            this.cBoxLSuffix.SelectedValueChanged += new System.EventHandler(this.cBoxLSuffixChanged);
            // 
            // cBoxCol
            // 
            this.cBoxCol.HeaderText = "";
            this.cBoxCol.Name = "cBoxCol";
            this.cBoxCol.Width = 40;
            // 
            // fNameCol
            // 
            this.fNameCol.HeaderText = "File Name";
            this.fNameCol.MaxInputLength = 150;
            this.fNameCol.Name = "fNameCol";
            this.fNameCol.ReadOnly = true;
            this.fNameCol.Width = 200;
            // 
            // btnSelAllFiles
            // 
            this.btnSelAllFiles.Location = new System.Drawing.Point(12, 431);
            this.btnSelAllFiles.Name = "btnSelAllFiles";
            this.btnSelAllFiles.Size = new System.Drawing.Size(135, 23);
            this.btnSelAllFiles.TabIndex = 15;
            this.btnSelAllFiles.Text = "Select/Deselect All Files";
            this.btnSelAllFiles.UseVisualStyleBackColor = true;
            this.btnSelAllFiles.Click += new System.EventHandler(this.toggleFileSelect);
            // 
            // fRenamer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 475);
            this.Controls.Add(this.btnSelAllFiles);
            this.Controls.Add(this.cBoxLSuffix);
            this.Controls.Add(this.tBoxNumSuffix);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dGVFileList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tBoxRFName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRFiles);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fRenamer";
            this.Text = "File Renamer V1.23 Beta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFileList)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRFiles;
        private System.Windows.Forms.RadioButton rBtnLSuff;
        private System.Windows.Forms.RadioButton rBtnNumSuff;
        private System.Windows.Forms.RadioButton rBtnNoSuff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxRFName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dGVFileList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programSettingsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tBoxNumSuffix;
        private System.Windows.Forms.ComboBox cBoxLSuffix;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cBoxCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn fNameCol;
        private System.Windows.Forms.Button btnSelAllFiles;
    }
}

