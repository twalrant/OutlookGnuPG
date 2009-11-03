using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace OutlookGnuPG
{
  public partial class OutlookGnuPG
  {
    private GnuPGRibbon ribbon;

    protected override object RequestService(Guid serviceGuid)
    {
      if (serviceGuid == typeof(Office.IRibbonExtensibility).GUID)
      {
        if (ribbon == null)
          ribbon = new GnuPGRibbon();
        return ribbon;
      }

      return base.RequestService(serviceGuid);
    }
  }

  [ComVisible(true)]
  public class GnuPGRibbon : Office.IRibbonExtensibility
  {
    private Office.IRibbonUI ribbon;

    public GnuPGToggleButton SignButton;
    public GnuPGToggleButton EncryptButton;
    public GnuPGToggleButton VerifyButton;
    public GnuPGToggleButton DecryptButton;

    const string signButtonId = "signButton";
    const string encryptButtonId = "encryptButton";
    const string verifyButtonId = "verifyButton";
    const string decryptButtonId = "decryptButton";

    public GnuPGRibbon()
    {
      SignButton = new GnuPGToggleButton(signButtonId);
      EncryptButton = new GnuPGToggleButton(encryptButtonId);
      VerifyButton = new GnuPGToggleButton(verifyButtonId);
      DecryptButton = new GnuPGToggleButton(decryptButtonId);
    }

    #region IRibbonExtensibility Members

    public string GetCustomUI(string ribbonID)
    {
      String ui = null;
      // Examine the ribbonID to see if the current item
      // is a Mail inspector.
      if (ribbonID == "Microsoft.Outlook.Mail.Read")
      {
        // Retrieve the customized Ribbon XML.
        ui = GetResourceText("OutlookGnuPG.GnuPGRibbonRead.xml");
      }
      if (ribbonID == "Microsoft.Outlook.Mail.Compose")
      {
        // Retrieve the customized Ribbon XML.
        ui = GetResourceText("OutlookGnuPG.GnuPGRibbonCompose.xml");
      }
      return ui;
    }

    #endregion

    internal void UpdateButtons(Properties.Settings settings)
    {
      EncryptButton.Checked = settings.AutoEncrypt;
      SignButton.Checked = settings.AutoSign;
      DecryptButton.Checked = settings.AutoDecrypt;
      VerifyButton.Checked = settings.AutoVerify;
    }

    #region Ribbon Callbacks

    public void OnLoad(Office.IRibbonUI ribbonUI)
    {
      this.ribbon = ribbonUI;
      Properties.Settings settings = new Properties.Settings();
      UpdateButtons(settings);
    }

    public void OnEncryptButton(Office.IRibbonControl control, bool isPressed)
    {
      EncryptButton.Checked = isPressed;
      ribbon.InvalidateControl(EncryptButton.ControlID);
    }

    public void OnDecryptButton(Office.IRibbonControl control, bool isPressed)
    {
      DecryptButton.Checked = isPressed;
      ribbon.InvalidateControl(DecryptButton.ControlID);
    }

    public void OnSignButton(Office.IRibbonControl control, bool isPressed)
    {
      SignButton.Checked = isPressed;
      ribbon.InvalidateControl(SignButton.ControlID);
    }

    public void OnVerifyButton(Office.IRibbonControl control, bool isPressed)
    {
      VerifyButton.Checked = isPressed;
      ribbon.InvalidateControl(VerifyButton.ControlID);
    }

    public void OnSettingsButtonRead(Office.IRibbonControl control)
    {
      Globals.OutlookGnuPG.Settings();
    }

    public void OnSettingsButtonNew(Office.IRibbonControl control)
    {
      Globals.OutlookGnuPG.Settings();

      // Force an update of button state:
      ribbon.InvalidateControl(signButtonId);
      ribbon.InvalidateControl(encryptButtonId);
    }

    public void OnAboutButton(Office.IRibbonControl control)
    {
      Globals.OutlookGnuPG.About();
    }

    public stdole.IPictureDisp
      GetCustomImage(Office.IRibbonControl control)
    {
      stdole.IPictureDisp pictureDisp = null;
      switch (control.Id)
      {
        case encryptButtonId:
        case decryptButtonId:
          pictureDisp = ImageConverter.Convert(global::OutlookGnuPG.Properties.Resources.lock_edit);
          break;
        case signButtonId:
        case verifyButtonId:
          pictureDisp = ImageConverter.Convert(global::OutlookGnuPG.Properties.Resources.link_edit);
          break;
        case "settingsButtonNew":
        case "settingsButtonRead":
          pictureDisp = ImageConverter.Convert(global::OutlookGnuPG.Properties.Resources.database_gear);
          break;
        case "aboutButtonNew":
        case "aboutButtonRead":
          pictureDisp = ImageConverter.Convert(global::OutlookGnuPG.Properties.Resources.Logo);
          break;
      }
      return pictureDisp;
    }

    public bool GetPressed(Office.IRibbonControl control)
    {
      switch (control.Id)
      {
        case encryptButtonId:
          return EncryptButton.Checked;
        case signButtonId:
          return SignButton.Checked;
        case decryptButtonId:
          return DecryptButton.Checked;
        case verifyButtonId:
          return VerifyButton.Checked;
        default:
          return false;
      }
    }
    #endregion

    #region Helpers

    private static string GetResourceText(string resourceName)
    {
      Assembly asm = Assembly.GetExecutingAssembly();
      string[] resourceNames = asm.GetManifestResourceNames();
      for (int i = 0; i < resourceNames.Length; ++i)
      {
        if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
        {
          using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
          {
            if (resourceReader != null)
            {
              return resourceReader.ReadToEnd();
            }
          }
        }
      }
      return null;
    }

    #endregion
  }

  internal class ImageConverter : System.Windows.Forms.AxHost
  {
    private ImageConverter()
      : base(null)
    {
    }
    public static stdole.IPictureDisp Convert(System.Drawing.Image image)
    {
      return (stdole.IPictureDisp)AxHost.GetIPictureDispFromPicture(image);
    }
  }

  public class GnuPGToggleButton
  {
    private bool m_Checked;
    public bool Checked
    {
      get { return m_Checked; }
      set { m_Checked = value; }
    }

    private string m_ControlId;
    public string ControlID
    {
      get { return m_ControlId; }
      set { m_ControlId = value; }
    }

    public GnuPGToggleButton(string controlId)
    {
      ControlID = controlId;
    }
  }
}
