using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CC.OutlookGnuPG
{
    internal partial class Recipient : Form
    {
        private readonly List<string> _defaultKeys;

        internal IList<string> SelectedKeys
        {
            get
            {
                var recipients = new List<string>();

                for (int i = 0; i < KeyBox.Items.Count; i++)
                {
                    var recipient = (GnuKey)KeyBox.Items[i];
                    if (KeyBox.GetItemChecked(i))
                        recipients.Add(recipient.Key);
                }

                return recipients;
            }
        }

        internal Recipient(List<string> defaultRecipients)
        {
            _defaultKeys = defaultRecipients;
            InitializeComponent();
        }

        private void Passphrase_Load(object sender, EventArgs e)
        {
            IList<GnuKey> keys = Globals.OutlookGnuPG.GetKeys();
            KeyBox.DataSource = keys;
            KeyBox.DisplayMember = "KeyDisplay";
            KeyBox.ValueMember = "Key";

            if (KeyBox.Items.Count <= 0)
            {
                // No keys available, no use in showing this dialog at all
                Hide();
                return;
            }

            var boxHeight = (keys.Count > 10) ? KeyBox.ItemHeight * 10 : KeyBox.ItemHeight * keys.Count;
            KeyBox.Height = boxHeight + 5;
            Height = boxHeight + 90;

            // Enlarge dialog to fit the longest key
            using (var g = CreateGraphics())
            {
                var maxSize = Width;
                foreach (var key in keys)
                {
                    var textWidth = (int)g.MeasureString(key.KeyDisplay, KeyBox.Font).Width + 50;
                    if (textWidth > maxSize)
                        maxSize = textWidth;
                }
                Width = maxSize;
                CenterToScreen();
            }

            for (int i = 0; i < KeyBox.Items.Count; i++)
            {
                var recipient = (GnuKey)KeyBox.Items[i];
                KeyBox.SetItemChecked(i, _defaultKeys.Contains(recipient.Key));
            }
        }
    }
}
