namespace CC.OutlookGnuPG
{
    internal partial class Settings
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ComposeSettings = new System.Windows.Forms.TabControl();
            this.GeneralTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.GnuPgExe = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ComposeTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SignCheckBox = new System.Windows.Forms.CheckBox();
            this.EncryptCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.KeyBox = new System.Windows.Forms.ComboBox();
            this.ReadTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.VerifyCheckBox = new System.Windows.Forms.CheckBox();
            this.DecryptCheckBox = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.Errors = new System.Windows.Forms.ErrorProvider(this.components);
            this.GnuPgExeFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ComposeSettings.SuspendLayout();
            this.GeneralTab.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.ComposeTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ReadTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ComposeSettings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(262, 171);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 0;
            // 
            // ComposeSettings
            // 
            this.ComposeSettings.Controls.Add(this.GeneralTab);
            this.ComposeSettings.Controls.Add(this.ComposeTab);
            this.ComposeSettings.Controls.Add(this.ReadTab);
            this.ComposeSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComposeSettings.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComposeSettings.Location = new System.Drawing.Point(0, 0);
            this.ComposeSettings.Name = "ComposeSettings";
            this.ComposeSettings.SelectedIndex = 0;
            this.ComposeSettings.Size = new System.Drawing.Size(262, 140);
            this.ComposeSettings.TabIndex = 0;
            // 
            // GeneralTab
            // 
            this.GeneralTab.Controls.Add(this.tableLayoutPanel3);
            this.GeneralTab.Location = new System.Drawing.Point(4, 22);
            this.GeneralTab.Name = "GeneralTab";
            this.GeneralTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTab.Size = new System.Drawing.Size(254, 114);
            this.GeneralTab.TabIndex = 2;
            this.GeneralTab.Text = "General";
            this.GeneralTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.GnuPgExe, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.BrowseButton, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(248, 108);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(21, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label2.Size = new System.Drawing.Size(226, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gpg.exe Location";
            // 
            // GnuPgExe
            // 
            this.GnuPgExe.CausesValidation = false;
            this.GnuPgExe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GnuPgExe.Enabled = false;
            this.Errors.SetIconPadding(this.GnuPgExe, 2);
            this.GnuPgExe.Location = new System.Drawing.Point(21, 26);
            this.GnuPgExe.Name = "GnuPgExe";
            this.GnuPgExe.Size = new System.Drawing.Size(226, 20);
            this.GnuPgExe.TabIndex = 1;
            // 
            // BrowseButton
            // 
            this.BrowseButton.CausesValidation = false;
            this.BrowseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseButton.Location = new System.Drawing.Point(21, 52);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(226, 23);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ComposeTab
            // 
            this.ComposeTab.Controls.Add(this.tableLayoutPanel1);
            this.ComposeTab.Location = new System.Drawing.Point(4, 22);
            this.ComposeTab.Name = "ComposeTab";
            this.ComposeTab.Padding = new System.Windows.Forms.Padding(3);
            this.ComposeTab.Size = new System.Drawing.Size(254, 114);
            this.ComposeTab.TabIndex = 0;
            this.ComposeTab.Text = "Compose";
            this.ComposeTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.SignCheckBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.EncryptCheckBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.KeyBox, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(248, 108);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // SignCheckBox
            // 
            this.SignCheckBox.AutoSize = true;
            this.SignCheckBox.Location = new System.Drawing.Point(21, 3);
            this.SignCheckBox.Name = "SignCheckBox";
            this.SignCheckBox.Size = new System.Drawing.Size(186, 17);
            this.SignCheckBox.TabIndex = 0;
            this.SignCheckBox.Text = "Automatically Sign New Mail";
            this.SignCheckBox.UseVisualStyleBackColor = true;
            // 
            // EncryptCheckBox
            // 
            this.EncryptCheckBox.AutoSize = true;
            this.EncryptCheckBox.Location = new System.Drawing.Point(21, 26);
            this.EncryptCheckBox.Name = "EncryptCheckBox";
            this.EncryptCheckBox.Size = new System.Drawing.Size(204, 17);
            this.EncryptCheckBox.TabIndex = 1;
            this.EncryptCheckBox.Text = "Automatically Encrypt New Mail";
            this.EncryptCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(21, 46);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(226, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Default Key";
            // 
            // KeyBox
            // 
            this.KeyBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyBox.FormattingEnabled = true;
            this.KeyBox.Items.AddRange(new object[] {
            "Key1",
            "Key2"});
            this.KeyBox.Location = new System.Drawing.Point(21, 72);
            this.KeyBox.Name = "KeyBox";
            this.KeyBox.Size = new System.Drawing.Size(226, 21);
            this.KeyBox.TabIndex = 3;
            // 
            // ReadTab
            // 
            this.ReadTab.Controls.Add(this.tableLayoutPanel2);
            this.ReadTab.Location = new System.Drawing.Point(4, 22);
            this.ReadTab.Name = "ReadTab";
            this.ReadTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReadTab.Size = new System.Drawing.Size(254, 114);
            this.ReadTab.TabIndex = 1;
            this.ReadTab.Text = "Read";
            this.ReadTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.VerifyCheckBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.DecryptCheckBox, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(248, 108);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // VerifyCheckBox
            // 
            this.VerifyCheckBox.AutoSize = true;
            this.VerifyCheckBox.Location = new System.Drawing.Point(21, 3);
            this.VerifyCheckBox.Name = "VerifyCheckBox";
            this.VerifyCheckBox.Size = new System.Drawing.Size(215, 17);
            this.VerifyCheckBox.TabIndex = 0;
            this.VerifyCheckBox.Text = "Automatically Verify Opened Mail";
            this.VerifyCheckBox.UseVisualStyleBackColor = true;
            // 
            // DecryptCheckBox
            // 
            this.DecryptCheckBox.AutoSize = true;
            this.DecryptCheckBox.Location = new System.Drawing.Point(21, 26);
            this.DecryptCheckBox.Name = "DecryptCheckBox";
            this.DecryptCheckBox.Size = new System.Drawing.Size(226, 17);
            this.DecryptCheckBox.TabIndex = 1;
            this.DecryptCheckBox.Text = "Automatically Decrypt Opened Mail";
            this.DecryptCheckBox.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.CancelButton);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.OkButton);
            this.splitContainer2.Size = new System.Drawing.Size(262, 27);
            this.splitContainer2.SplitterDistance = 125;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // CancelButton
            // 
            this.CancelButton.CausesValidation = false;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CancelButton.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(0, 0);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(125, 27);
            this.CancelButton.TabIndex = 0;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OkButton.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.Location = new System.Drawing.Point(0, 0);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(132, 27);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // Errors
            // 
            this.Errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.Errors.ContainerControl = this;
            // 
            // GnuPgExeFolderDialog
            // 
            this.GnuPgExeFolderDialog.ShowNewFolderButton = false;
            // 
            // Settings
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 171);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ComposeSettings.ResumeLayout(false);
            this.GeneralTab.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ComposeTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ReadTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Errors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TabControl ComposeSettings;
        private System.Windows.Forms.TabPage ComposeTab;
        private System.Windows.Forms.TabPage ReadTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox SignCheckBox;
        private System.Windows.Forms.CheckBox EncryptCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox KeyBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox VerifyCheckBox;
        private System.Windows.Forms.CheckBox DecryptCheckBox;
        private System.Windows.Forms.TabPage GeneralTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox GnuPgExe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.ErrorProvider Errors;
        private System.Windows.Forms.FolderBrowserDialog GnuPgExeFolderDialog;

    }
}