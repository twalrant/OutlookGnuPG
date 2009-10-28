namespace CC.OutlookGnuPG
{
    public partial class GnuPGRibbonRead
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GnuPGRibbonRead));
            this.OutlookGnuPGTab = new Microsoft.Office.Tools.Ribbon.RibbonTab();
            this.OutlookGnuPGGroup = new Microsoft.Office.Tools.Ribbon.RibbonGroup();
            this.VerifyButton = new Microsoft.Office.Tools.Ribbon.RibbonButton();
            this.DecryptButton = new Microsoft.Office.Tools.Ribbon.RibbonButton();
            this.SettingsButton = new Microsoft.Office.Tools.Ribbon.RibbonButton();
            this.AboutButton = new Microsoft.Office.Tools.Ribbon.RibbonButton();
            this.separator1 = new Microsoft.Office.Tools.Ribbon.RibbonSeparator();
            this.OutlookGnuPGTab.SuspendLayout();
            this.OutlookGnuPGGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutlookGnuPGTab
            // 
            this.OutlookGnuPGTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.OutlookGnuPGTab.ControlId.OfficeId = "TabReadMessage";
            this.OutlookGnuPGTab.Groups.Add(this.OutlookGnuPGGroup);
            this.OutlookGnuPGTab.Label = "TabReadMessage";
            this.OutlookGnuPGTab.Name = "OutlookGnuPGTab";
            // 
            // OutlookGnuPGGroup
            // 
            this.OutlookGnuPGGroup.Items.Add(this.VerifyButton);
            this.OutlookGnuPGGroup.Items.Add(this.DecryptButton);
            this.OutlookGnuPGGroup.Items.Add(this.SettingsButton);
            this.OutlookGnuPGGroup.Items.Add(this.separator1);
            this.OutlookGnuPGGroup.Items.Add(this.AboutButton);
            this.OutlookGnuPGGroup.Label = "OutlookGnuPG";
            this.OutlookGnuPGGroup.Name = "OutlookGnuPGGroup";
            // 
            // VerifyButton
            // 
            this.VerifyButton.Image = global::CC.OutlookGnuPG.Properties.Resources.link_edit;
            this.VerifyButton.Label = "Verify";
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.ShowImage = true;
            this.VerifyButton.SuperTip = "Verify the signature on the current email.";
            this.VerifyButton.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.VerifyButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.Image = global::CC.OutlookGnuPG.Properties.Resources.lock_edit;
            this.DecryptButton.Label = "Decrypt";
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.ShowImage = true;
            this.DecryptButton.SuperTip = "Decrypt the current email.";
            this.DecryptButton.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.DecryptButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Image = global::CC.OutlookGnuPG.Properties.Resources.database_gear;
            this.SettingsButton.Label = "Settings";
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.ShowImage = true;
            this.SettingsButton.SuperTip = "Settings to use when verifying and decrypting.";
            this.SettingsButton.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.SettingsButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AboutButton.Image = ((System.Drawing.Image)(resources.GetObject("AboutButton.Image")));
            this.AboutButton.Label = "About";
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.ShowImage = true;
            this.AboutButton.SuperTip = "About CC.OutlookGnuPG";
            this.AboutButton.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.AboutButton_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // GnuPGRibbonRead
            // 
            this.Name = "GnuPGRibbonRead";
            this.RibbonType = "Microsoft.Outlook.Mail.Read";
            this.Tabs.Add(this.OutlookGnuPGTab);
            this.Load += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonUIEventArgs>(this.GnuPGRibbon_Load);
            this.OutlookGnuPGTab.ResumeLayout(false);
            this.OutlookGnuPGTab.PerformLayout();
            this.OutlookGnuPGGroup.ResumeLayout(false);
            this.OutlookGnuPGGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab OutlookGnuPGTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup OutlookGnuPGGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton VerifyButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DecryptButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SettingsButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AboutButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
    }

    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection
    {
        internal GnuPGRibbonRead GnuPGRibbonRead
        {
            get { return this.GetRibbon<GnuPGRibbonRead>(); }
        }
    }
}
