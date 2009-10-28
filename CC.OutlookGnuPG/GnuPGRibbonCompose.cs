using Microsoft.Office.Tools.Ribbon;

namespace CC.OutlookGnuPG
{
    public partial class GnuPGRibbonCompose : OfficeRibbon
    {
        public GnuPGRibbonCompose()
        {
            InitializeComponent();
        }

        internal void UpdateButtons(Properties.Settings settings)
        {
            EncryptButton.Checked = settings.AutoEncrypt;
            SignButton.Checked = settings.AutoSign;
        }

        private void GnuPGRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            var settings = new Properties.Settings();
            UpdateButtons(settings);
        }

        private void SignButton_Click(object sender, RibbonControlEventArgs e)
        {           
        }

        private void EncryptButton_Click(object sender, RibbonControlEventArgs e)
        {
        }

        private void SettingsButton_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.OutlookGnuPG.Settings();
        }

        private void AboutButton_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.OutlookGnuPG.About();
        }
    }
}
