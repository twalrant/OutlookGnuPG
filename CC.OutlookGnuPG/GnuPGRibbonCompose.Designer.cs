namespace CC.OutlookGnuPG
{
    public partial class GnuPGRibbonCompose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GnuPGRibbonCompose));
            this.OutlookGnuPGTab = new Microsoft.Office.Tools.Ribbon.RibbonTab();
            this.OutlookGnuPGGroup = new Microsoft.Office.Tools.Ribbon.RibbonGroup();
            this.SignButton = new Microsoft.Office.Tools.Ribbon.RibbonToggleButton();
            this.EncryptButton = new Microsoft.Office.Tools.Ribbon.RibbonToggleButton();
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
            this.OutlookGnuPGTab.ControlId.OfficeId = "TabNewMailMessage";
            this.OutlookGnuPGTab.Groups.Add(this.OutlookGnuPGGroup);
            this.OutlookGnuPGTab.Label = "TabNewMailMessage";
            this.OutlookGnuPGTab.Name = "OutlookGnuPGTab";
            // 
            // OutlookGnuPGGroup
            // 
            this.OutlookGnuPGGroup.Items.Add(this.SignButton);
            this.OutlookGnuPGGroup.Items.Add(this.EncryptButton);
            this.OutlookGnuPGGroup.Items.Add(this.SettingsButton);
            this.OutlookGnuPGGroup.Items.Add(this.separator1);
            this.OutlookGnuPGGroup.Items.Add(this.AboutButton);
            this.OutlookGnuPGGroup.Label = "OutlookGnuPG";
            this.OutlookGnuPGGroup.Name = "OutlookGnuPGGroup";
            // 
            // SignButton
            // 
            this.SignButton.Image = global::CC.OutlookGnuPG.Properties.Resources.link_edit;
            this.SignButton.Label = "Sign";
            this.SignButton.Name = "SignButton";
            this.SignButton.ShowImage = true;
            this.SignButton.SuperTip = "Sign the current email when sending.";
            this.SignButton.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.SignButton_Click);
            // 
            // EncryptButton
            // 
            this.EncryptButton.Image = global::CC.OutlookGnuPG.Properties.Resources.lock_edit;
            this.EncryptButton.Label = "Encrypt";
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.ShowImage = true;
            this.EncryptButton.SuperTip = "Encrypt the current email when sending.";
            this.EncryptButton.Click += new System.EventHandler<Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs>(this.EncryptButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Image = global::CC.OutlookGnuPG.Properties.Resources.database_gear;
            this.SettingsButton.Label = "Settings";
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.ShowImage = true;
            this.SettingsButton.SuperTip = "Settings to use when signing and encrypting.";
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
            // GnuPGRibbonCompose
            // 
            this.Name = "GnuPGRibbonCompose";
            this.RibbonType = "Microsoft.Outlook.Mail.Compose";
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
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton SignButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonToggleButton EncryptButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SettingsButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AboutButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
    }

    partial class ThisRibbonCollection : Microsoft.Office.Tools.Ribbon.RibbonReadOnlyCollection
    {
        internal GnuPGRibbonCompose GnuPGRibbonCompose
        {
            get { return this.GetRibbon<GnuPGRibbonCompose>(); }
        }
    }
}
