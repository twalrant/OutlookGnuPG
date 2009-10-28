using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using CC.OutlookGnuPG.Properties;

using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using Outlook = Microsoft.Office.Interop.Outlook;

using Starksoft.Cryptography.OpenPGP;
using Exception = System.Exception;

// TODO: Refactor some of the checks to central places

namespace CC.OutlookGnuPG
{
    public partial class OutlookGnuPG
    {
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += OutlookGnuPG_Startup;
        }

        #endregion

        private Properties.Settings _settings;
        private GnuPG _gnuPg;
        private PositionalCommandBar _gpgBar;
        private const string _gnuPgErrorString = "[@##$$##@|!GNUPGERROR!|@##$$##@]"; // Hacky way of dealing with exceptions

        // The GC comes along and eats our buttons, we need to hold a reference to it... *sigh*
        private IDictionary<string, CommandBarButton> _buttons = new Dictionary<string, CommandBarButton>();

        private void OutlookGnuPG_Startup(object sender, EventArgs e)
        {
            _settings = new Properties.Settings();

            if (string.IsNullOrEmpty(_settings.GnuPgPath))
            {
                _gnuPg = new GnuPG();
                Settings(); // Prompt for GnuPG Path
            }
            else
            {
                _gnuPg = new GnuPG(null, _settings.GnuPgPath);
            }
            _gnuPg.OutputType = OutputTypes.AsciiArmor;

            AddGnuPGCommandBar();

            Application.ItemSend += Application_ItemSend;
            ((ApplicationEvents_11_Event)Application).Quit += OutlookGnuPG_Quit;
        }

        private void OutlookGnuPG_Quit()
        {
            _gpgBar.SavePosition(_settings);
        }

        #region CommandBar Logic
        private void AddGnuPGCommandBar()
        {
            // Add a commandbar with a verify/decrypt button
            var bars = Application.ActiveExplorer().CommandBars;
            PositionalCommandBar gpgBar = GetGnuPGCommandBar(bars);

            // Add the bar if it doesn't exist yet
            if (gpgBar.Bar == null)
            {
                gpgBar = new PositionalCommandBar(bars.Add("GnuPGCommandBar", Type.Missing, Type.Missing, true));
                gpgBar.Bar.Protection = MsoBarProtection.msoBarNoCustomize;
                gpgBar.Bar.Visible = true;
            }

            // Check if verify button exists, add it if it doesn't
            var verifyButton = (CommandBarButton)gpgBar.Bar.FindControl(MsoControlType.msoControlButton, Type.Missing, "GnuPGVerifyMail", Type.Missing, true) ??
                               (CommandBarButton)gpgBar.Bar.Controls.Add(MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);

            verifyButton.Style = MsoButtonStyle.msoButtonIconAndCaption;
            verifyButton.Caption = "Verify";
            verifyButton.Tag = "GnuPGVerifyMail";
            verifyButton.Click += VerifyButton_Click;
            SetIcon(verifyButton, Resources.link_edit);
            if (!_buttons.ContainsKey(verifyButton.Tag))
                _buttons.Add(verifyButton.Tag, verifyButton);

            // Check if decrypt button exists, add it if it doesn't
            var decryptButton = (CommandBarButton)gpgBar.Bar.FindControl(MsoControlType.msoControlButton, Type.Missing, "GnuPGDecryptMail", Type.Missing, true) ??
                                (CommandBarButton)gpgBar.Bar.Controls.Add(MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);

            decryptButton.Style = MsoButtonStyle.msoButtonIconAndCaption;
            decryptButton.Caption = "Decrypt";
            decryptButton.Tag = "GnuPGDecryptMail";
            decryptButton.Click += DecryptButton_Click;
            SetIcon(decryptButton, Resources.lock_edit);
            if (!_buttons.ContainsKey(decryptButton.Tag))
                _buttons.Add(decryptButton.Tag, decryptButton);

            // Check if about button exists, add it if it doesn't
            var settingsButton = (CommandBarButton)gpgBar.Bar.FindControl(MsoControlType.msoControlButton, Type.Missing, "GnuPGSettings", Type.Missing, true) ??
                                 (CommandBarButton)gpgBar.Bar.Controls.Add(MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);

            settingsButton.Style = MsoButtonStyle.msoButtonIconAndCaption;
            settingsButton.Caption = "Settings";
            settingsButton.Tag = "GnuPGSettings";
            settingsButton.Click += SettingsButton_Click;
            SetIcon(settingsButton, Resources.database_gear);
            if (!_buttons.ContainsKey(settingsButton.Tag))
                _buttons.Add(settingsButton.Tag, settingsButton);

            // Check if about button exists, add it if it doesn't
            var aboutButton = (CommandBarButton)gpgBar.Bar.FindControl(MsoControlType.msoControlButton, Type.Missing, "AboutGnuPG", Type.Missing, true) ??
                              (CommandBarButton)gpgBar.Bar.Controls.Add(MsoControlType.msoControlButton, Type.Missing, Type.Missing, Type.Missing, true);

            aboutButton.Style = MsoButtonStyle.msoButtonIconAndCaption;
            aboutButton.Caption = "About";
            aboutButton.Tag = "AboutGnuPG";
            aboutButton.Click += AboutButton_Click;
            SetIcon(aboutButton, Resources.Logo);
            if (!_buttons.ContainsKey(aboutButton.Tag))
                _buttons.Add(aboutButton.Tag, aboutButton);

            gpgBar.RestorePosition(bars, _settings);
            _gpgBar = gpgBar;
        }

        private PositionalCommandBar GetGnuPGCommandBar(CommandBars bars)
        {
            CommandBar gpgBar = null;

            // Check if we added it already
            foreach (var bar in bars)
            {
                if (((CommandBar)bar).Name != "GnuPGCommandBar")
                    continue;

                gpgBar = (CommandBar)bar;
                break;
            }

            return new PositionalCommandBar(gpgBar);
        }

        private void SetIcon(CommandBarButton buttonToSet, Bitmap iconToSet)
        {
            var clipboardBackup = ClipboardHelper.GetClipboard();
            ClipboardHelper.EmptyClipboard();

            Clipboard.SetImage(iconToSet);
            buttonToSet.PasteFace();

            ClipboardHelper.EmptyClipboard();
            ClipboardHelper.SetClipboard(clipboardBackup);
        }

        private void VerifyButton_Click(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            // Get the selected item in Outlook and determine its type.
            Selection outlookSelection = Application.ActiveExplorer().Selection;
            if (outlookSelection.Count <= 0)
                return;

            object selectedItem = outlookSelection[1];
            var mailItem = selectedItem as MailItem;

            if (mailItem == null)
            {
                MessageBox.Show(
                    "OutlookGnuPG can only verify mails.",
                    "Invalid Item Type",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            VerifyEmail(mailItem);
        }

        private void DecryptButton_Click(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            // Get the selected item in Outlook and determine its type.
            Selection outlookSelection = Application.ActiveExplorer().Selection;
            if (outlookSelection.Count <= 0)
                return;

            object selectedItem = outlookSelection[1];
            var mailItem = selectedItem as MailItem;

            if (mailItem == null)
            {
                MessageBox.Show(
                    "OutlookGnuPG can only decrypt mails.",
                    "Invalid Item Type",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            DecryptEmail(mailItem);
        }

        private void AboutButton_Click(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            Globals.OutlookGnuPG.About();
        }

        private void SettingsButton_Click(CommandBarButton Ctrl, ref bool CancelDefault)
        {
            Globals.OutlookGnuPG.Settings();
        }

        #endregion

        #region Send Logic
        private void Application_ItemSend(object Item, ref bool Cancel)
        {
            var mailItem = Item as MailItem;

            if (mailItem == null)
                return;

            //var inspector = Application.ActiveInspector();
            var inspector = mailItem.GetInspector;
            var currentRibbons = Globals.Ribbons[inspector];
            var currentRibbon = currentRibbons.GnuPGRibbonCompose;

            if (currentRibbon == null)
                return;

            var mail = mailItem.Body;
            var mailType = mailItem.BodyFormat;
            var needToEncrypt = currentRibbon.EncryptButton.Checked;
            var needToSign = currentRibbon.SignButton.Checked;

            // Early out when we don't need to sign/encrypt
            if (!needToEncrypt && !needToSign)
                return;

            if (mailType != OlBodyFormat.olFormatPlain)
            {
                MessageBox.Show(
                    "OutlookGnuPG can only sign/encrypt plain text mails. Please change the format, or disable signing/encrypting for this mail.",
                    "Invalid Mail Format",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Cancel = true; // Prevent sending the mail
                return;
            }

            // Still no gpg.exe path... Annoy the user once again, maybe he'll get it ;)
            if (string.IsNullOrEmpty(_settings.GnuPgPath))
                Settings();

            // Stubborn, give up
            if (string.IsNullOrEmpty(_settings.GnuPgPath))
            {
                MessageBox.Show(
                    "OutlookGnuPG can only sign/encrypt when you provide a valid gpg.exe path. Please open Settings and configure it.",
                    "Invalid GnuPG Executable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Cancel = true; // Prevent sending the mail
                return;
            }

            var passphrase = string.Empty;
            var privateKey = string.Empty;
            if (needToSign)
            {
                // Popup UI to select the passphrase and private key.
                var passphraseDialog = new Passphrase(_settings.DefaultKey, "Sign");
                var passphraseResult = passphraseDialog.ShowDialog();
                if (passphraseResult != DialogResult.OK)
                {
                    // The user closed the passphrase dialog, prevent sending the mail
                    Cancel = true;
                    return;
                }

                passphrase = passphraseDialog.EnteredPassphrase;
                privateKey = passphraseDialog.SelectedKey;
                passphraseDialog.Close();

                if (string.IsNullOrEmpty(privateKey))
                {
                    MessageBox.Show(
                        "OutlookGnuPG needs a private key for signing. No keys were detected.",
                        "Invalid Private Key",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Cancel = true; // Prevent sending the mail
                    return;
                }
            }

            IList<string> recipients = new List<string> { string.Empty };
            if (needToEncrypt)
            {
                // Popup UI to select the encryption targets 
                var mailRecipients = new List<string>();
                foreach (var mailRecipient in mailItem.Recipients)
                    mailRecipients.Add(((Outlook.Recipient)mailRecipient).Address);

                var recipientDialog = new Recipient(mailRecipients); // Passing in the first addres, maybe it matches
                var recipientResult = recipientDialog.ShowDialog();

                if (recipientResult != DialogResult.OK)
                {
                    // The user closed the recipient dialog, prevent sending the mail
                    Cancel = true;
                    return;
                }

                recipients = recipientDialog.SelectedKeys;
                recipientDialog.Close();

                if (recipients.Count == 0)
                {
                    MessageBox.Show(
                        "OutlookGnuPG needs a recipient when encrypting. No keys were detected/selected.",
                        "Invalid Recipient Key",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    Cancel = true; // Prevent sending the mail
                    return;
                }
            }

            // Sign and encrypt the plaintext mail
            if ((needToSign) && (needToEncrypt))
            {
                mail = SignAndEncryptEmail(mail, privateKey, passphrase, recipients);
            }
            else if (needToSign)
            {
                // Sign the plaintext mail if needed
                mail = SignEmail(mail, privateKey, passphrase);
            }
            else if (needToEncrypt)
            {
                // Encrypt the plaintext mail if needed
                mail = EncryptEmail(mail, passphrase, recipients);
            }

            // Update the new content
            if (mail != _gnuPgErrorString)
                mailItem.Body = mail;
            else
                Cancel = true;
        }

        private string SignEmail(string mail, string key, string passphrase)
        {
            using (var inputStream = new MemoryStream(mail.Length))
            using (var outputStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(inputStream))
                {
                    writer.Write(mail);
                    writer.Flush();
                    inputStream.Position = 0;
                    _gnuPg.Passphrase = passphrase;
                    _gnuPg.Sender = key;

                    try
                    {
                        _gnuPg.OutputStatus = false;
                        _gnuPg.Sign(inputStream, outputStream);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            ex.Message,
                            "GnuPG Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return _gnuPgErrorString;
                    }
                }

                using (var reader = new StreamReader(outputStream))
                {
                    outputStream.Position = 0;
                    mail = reader.ReadToEnd();
                }
            }

            return mail;
        }

        private string EncryptEmail(string mail, string passphrase, IList<string> recipients)
        {
            using (var inputStream = new MemoryStream(mail.Length))
            using (var outputStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(inputStream))
                {
                    writer.Write(mail);
                    writer.Flush();
                    inputStream.Position = 0;
                    _gnuPg.Passphrase = passphrase;
                    _gnuPg.Recipients = recipients;
                    _gnuPg.OutputStatus = false;

                    try
                    {
                        _gnuPg.Encrypt(inputStream, outputStream);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            ex.Message,
                            "GnuPG Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return _gnuPgErrorString;
                    }
                }

                using (var reader = new StreamReader(outputStream))
                {
                    outputStream.Position = 0;
                    mail = reader.ReadToEnd();
                }
            }

            return mail;
        }

        private string SignAndEncryptEmail(string mail, string key, string passphrase, IList<string> recipients)
        {
            using (var inputStream = new MemoryStream(mail.Length))
            using (var outputStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(inputStream))
                {
                    writer.Write(mail);
                    writer.Flush();
                    inputStream.Position = 0;
                    _gnuPg.Passphrase = passphrase;
                    _gnuPg.Recipients = recipients;
                    _gnuPg.Sender = key;
                    _gnuPg.OutputStatus = false;

                    try
                    {
                        _gnuPg.SignAndEncrypt(inputStream, outputStream);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            ex.Message,
                            "GnuPG Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return _gnuPgErrorString;
                    }
                }

                using (var reader = new StreamReader(outputStream))
                {
                    outputStream.Position = 0;
                    mail = reader.ReadToEnd();
                }
            }

            return mail;
        }
        #endregion

        #region Receive Logic
        internal void VerifyEmail(MailItem mailItem)
        {
            var mail = mailItem.Body;
            var mailType = mailItem.BodyFormat;

            if (mailType != OlBodyFormat.olFormatPlain)
            {
                MessageBox.Show(
                    "OutlookGnuPG can only verify plain text mails.",
                    "Invalid Mail Format",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Still no gpg.exe path... Annoy the user once again, maybe he'll get it ;)
            if (string.IsNullOrEmpty(_settings.GnuPgPath))
                Settings();

            // Stubborn, give up
            if (string.IsNullOrEmpty(_settings.GnuPgPath))
            {
                MessageBox.Show(
                    "OutlookGnuPG can only verify when you provide a valid gpg.exe path. Please open Settings and configure it.",
                    "Invalid GnuPG Executable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var verifyResult = string.Empty;
            var errorResult = string.Empty;
            using (var inputStream = new MemoryStream(mail.Length))
            using (var outputStream = new MemoryStream())
            using (var errorStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(inputStream))
                {
                    writer.Write(mail);
                    writer.Flush();
                    inputStream.Position = 0;

                    try
                    {
                        _gnuPg.OutputStatus = true;
                        _gnuPg.Verify(inputStream, outputStream, errorStream);
                    }
                    catch (Exception ex)
                    {
                        var error = ex.Message;

                        // We deal with bad signature later
                        if (!error.ToLowerInvariant().Contains("bad signature"))
                        {
                            MessageBox.Show(
                                error,
                                "GnuPG Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            return;
                        }
                    }
                }

                using (var reader = new StreamReader(outputStream))
                {
                    outputStream.Position = 0;
                    verifyResult = reader.ReadToEnd();
                }

                using (var reader = new StreamReader(errorStream))
                {
                    errorStream.Position = 0;
                    errorResult = reader.ReadToEnd();
                }
            }

            if (verifyResult.Contains("BADSIG"))
            {
                errorResult = errorResult.Replace("gpg: ", string.Empty);

                MessageBox.Show(
                    errorResult,
                    "Invalid Signature",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (verifyResult.Contains("GOODSIG"))
            {
                errorResult = errorResult.Replace("gpg: ", string.Empty);

                MessageBox.Show(
                    errorResult,
                    "Valid Signature",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                errorResult = errorResult.Replace("gpg: ", string.Empty);

                MessageBox.Show(
                    errorResult,
                    "Unknown Signature",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        internal void DecryptEmail(MailItem mailItem)
        {
            var mail = mailItem.Body;
            var mailType = mailItem.BodyFormat;

            if (mailType != OlBodyFormat.olFormatPlain)
            {
                MessageBox.Show(
                    "OutlookGnuPG can only decrypt plain text mails.",
                    "Invalid Mail Format",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Still no gpg.exe path... Annoy the user once again, maybe he'll get it ;)
            if (string.IsNullOrEmpty(_settings.GnuPgPath))
                Settings();

            // Stubborn, give up
            if (string.IsNullOrEmpty(_settings.GnuPgPath))
            {
                MessageBox.Show(
                    "OutlookGnuPG can only decrypt when you provide a valid gpg.exe path. Please open Settings and configure it.",
                    "Invalid GnuPG Executable",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            var passphrase = string.Empty;
            var privateKey = string.Empty;

            // Popup UI to select the passphrase and private key.
            var passphraseDialog = new Passphrase(_settings.DefaultKey, "Decrypt");
            var passphraseResult = passphraseDialog.ShowDialog();
            if (passphraseResult != DialogResult.OK)
            {
                // The user closed the passphrase dialog, prevent sending the mail
                return;
            }

            passphrase = passphraseDialog.EnteredPassphrase;
            privateKey = passphraseDialog.SelectedKey;
            passphraseDialog.Close();

            if (string.IsNullOrEmpty(privateKey))
            {
                MessageBox.Show(
                    "OutlookGnuPG needs a private key for decrypting. No keys were detected.",
                    "Invalid Private Key",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // Decrypt without fd-status (might already blow up, early out)
            // Decrypt with fd-status and cut out the stdout of normal decrypt (prevents BAD/GOODMC messages in message confusing us)
            var stdOutResult = string.Empty;
            using (var inputStream = new MemoryStream(mail.Length))
            using (var outputStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(inputStream))
                {
                    writer.Write(mail);
                    writer.Flush();
                    inputStream.Position = 0;

                    try
                    {
                        _gnuPg.OutputStatus = false;
                        _gnuPg.Passphrase = passphrase;
                        _gnuPg.Decrypt(inputStream, outputStream, new MemoryStream());
                    }
                    catch (Exception ex)
                    {
                        var error = ex.Message;

                        // We deal with bad signature later
                        if (!error.ToLowerInvariant().Contains("bad signature"))
                        {
                            MessageBox.Show(
                                error,
                                "GnuPG Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            return;
                        }
                    }
                }

                using (var reader = new StreamReader(outputStream))
                {
                    outputStream.Position = 0;
                    stdOutResult = reader.ReadToEnd();
                }
            }

            var verifyResult = string.Empty;
            var errorResult = string.Empty;
            using (var inputStream = new MemoryStream(mail.Length))
            using (var outputStream = new MemoryStream())
            using (var errorStream = new MemoryStream())
            {
                using (var writer = new StreamWriter(inputStream))
                {
                    writer.Write(mail);
                    writer.Flush();
                    inputStream.Position = 0;

                    try
                    {
                        _gnuPg.OutputStatus = true;
                        _gnuPg.Passphrase = passphrase;
                        _gnuPg.Decrypt(inputStream, outputStream, errorStream);
                    }
                    catch (Exception ex)
                    {
                        var error = ex.Message;

                        // We deal with bad signature later
                        if (!error.ToLowerInvariant().Contains("bad signature"))
                        {
                            MessageBox.Show(
                                error,
                                "GnuPG Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            return;
                        }
                    }
                }

                using (var reader = new StreamReader(outputStream))
                {
                    outputStream.Position = 0;
                    verifyResult = reader.ReadToEnd();
                }

                using (var reader = new StreamReader(errorStream))
                {
                    errorStream.Position = 0;
                    errorResult = reader.ReadToEnd();
                }
            }

            verifyResult = verifyResult.Replace(stdOutResult, string.Empty);

            // Verify: status-fd
            // stdOut: the message
            // error: gpg error/status

            if (verifyResult.Contains("BADMDC"))
            {
                errorResult = errorResult.Replace("gpg: ", string.Empty);

                MessageBox.Show(
                    errorResult,
                    "Invalid Encryption",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (verifyResult.Contains("GOODMDC"))
            {
                // Decrypted OK, check for validsig
                if (verifyResult.Contains("BADSIG"))
                {
                    errorResult = errorResult.Replace("gpg: ", string.Empty);

                    MessageBox.Show(
                        errorResult,
                        "Invalid Signature",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else if (verifyResult.Contains("GOODSIG"))
                {
                    errorResult = errorResult.Replace("gpg: ", string.Empty);

                    MessageBox.Show(
                        errorResult,
                        "Valid Signature",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Valid signature!
                    mailItem.Body = stdOutResult;
                }
                else
                {
                    // No signature?
                    mailItem.Body = stdOutResult;
                }
            }
            else
            {
                errorResult = errorResult.Replace("gpg: ", string.Empty);

                MessageBox.Show(
                    errorResult,
                    "Unknown Encryption",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

        }
        #endregion

        #region General Logic
        internal void About()
        {
            var aboutBox = new About();
            aboutBox.ShowDialog();
        }

        internal void Settings()
        {
            var settingsBox = new Settings(_settings);
            var result = settingsBox.ShowDialog();

            if (result != DialogResult.OK)
                return;

            _settings.GnuPgPath = settingsBox.GnuPgPath;
            _settings.AutoDecrypt = settingsBox.AutoDecrypt;
            _settings.AutoVerify = settingsBox.AutoVerify;
            _settings.AutoEncrypt = settingsBox.AutoEncrypt;
            _settings.AutoSign = settingsBox.AutoSign;
            _settings.DefaultKey = settingsBox.DefaultKey;
            _settings.Save();

            _gnuPg.BinaryPath = _settings.GnuPgPath;
            UpdateRibbons();
        }

        internal void UpdateRibbons()
        {
            foreach (var outlookRibbon in Globals.Ribbons)
            {
                var ribbon = outlookRibbon as GnuPGRibbonCompose;

                if (ribbon == null)
                    continue;

                ribbon.UpdateButtons(_settings);
            }
        }
        #endregion

        #region Key Management
        internal IList<GnuKey> GetPrivateKeys()
        {
            var gnuPath = _gnuPg.BinaryPath;
            if (!gnuPath.EndsWith("gpg.exe"))
                _gnuPg.BinaryPath = Path.Combine(gnuPath, "gpg.exe");

            var privateKeys = _gnuPg.GetSecretKeys();
            _gnuPg.BinaryPath = gnuPath;

            var keys = new List<GnuKey>();
            foreach (var privateKey in privateKeys)
            {
                keys.Add(new GnuKey
                {
                    Key = privateKey.UserId,
                    KeyDisplay = string.Format("{0} <{1}>", privateKey.UserName, privateKey.UserId)
                });
            }

            return keys;
        }

        internal IList<GnuKey> GetPrivateKeys(string gnuPgPath)
        {
            _gnuPg.BinaryPath = gnuPgPath;
            return GetPrivateKeys();
        }

        public IList<GnuKey> GetKeys()
        {
            var gnuPath = _gnuPg.BinaryPath;
            if (!gnuPath.EndsWith("gpg.exe"))
                _gnuPg.BinaryPath = Path.Combine(gnuPath, "gpg.exe");

            var privateKeys = _gnuPg.GetKeys();
            _gnuPg.BinaryPath = gnuPath;

            var keys = new List<GnuKey>();
            foreach (var privateKey in privateKeys)
            {
                keys.Add(new GnuKey
                {
                    Key = privateKey.UserId,
                    KeyDisplay = string.Format("{0} <{1}>", privateKey.UserName, privateKey.UserId)
                });
            }

            return keys;
        }
        #endregion
    }
}
