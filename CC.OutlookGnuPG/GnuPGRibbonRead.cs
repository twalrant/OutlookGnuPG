using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;

namespace CC.OutlookGnuPG
{
    public partial class GnuPGRibbonRead : OfficeRibbon
    {
        public GnuPGRibbonRead()
        {
            InitializeComponent();
        }

        private void GnuPGRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void VerifyButton_Click(object sender, RibbonControlEventArgs e)
        {
            MailItem mailItem = GetMailItem(e.Control.Context);

            if (mailItem != null)
                Globals.OutlookGnuPG.VerifyEmail(mailItem);
        }

        private void DecryptButton_Click(object sender, RibbonControlEventArgs e)
        {
            MailItem mailItem = GetMailItem(e.Control.Context);

            if (mailItem != null)
                Globals.OutlookGnuPG.DecryptEmail(mailItem);
        }

        private void SettingsButton_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.OutlookGnuPG.Settings();
        }

        private void AboutButton_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.OutlookGnuPG.About();
        }

        private MailItem GetMailItem(object context)
        {
            var inspector = context as Inspector;

            if (inspector == null)
                return null;

            return inspector.CurrentItem as MailItem;
        }
    }
}
