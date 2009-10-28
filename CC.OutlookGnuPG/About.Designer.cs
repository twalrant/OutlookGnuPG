namespace CC.OutlookGnuPG
{
  internal partial class About
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
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
      this.AboutLabel = new System.Windows.Forms.Label();
      this.BlogLabel = new System.Windows.Forms.LinkLabel();
      this.DonateLabel = new System.Windows.Forms.LinkLabel();
      this.IconLabel = new System.Windows.Forms.LinkLabel();
      this.OpenPGPLink = new System.Windows.Forms.LinkLabel();
      this.ClipboardLink = new System.Windows.Forms.LinkLabel();
      this.SuspendLayout();
      // 
      // AboutLabel
      // 
      this.AboutLabel.AutoSize = true;
      this.AboutLabel.BackColor = System.Drawing.Color.White;
      this.AboutLabel.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.AboutLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.AboutLabel.Location = new System.Drawing.Point(10, 123);
      this.AboutLabel.Name = "AboutLabel";
      this.AboutLabel.Size = new System.Drawing.Size(302, 29);
      this.AboutLabel.TabIndex = 0;
      this.AboutLabel.Text = "CC.OutlookGnuPG 1.0.3";
      // 
      // BlogLabel
      // 
      this.BlogLabel.ActiveLinkColor = System.Drawing.Color.Black;
      this.BlogLabel.AutoSize = true;
      this.BlogLabel.BackColor = System.Drawing.Color.White;
      this.BlogLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.BlogLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.BlogLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.BlogLabel.Location = new System.Drawing.Point(187, 167);
      this.BlogLabel.Name = "BlogLabel";
      this.BlogLabel.Size = new System.Drawing.Size(101, 13);
      this.BlogLabel.TabIndex = 1;
      this.BlogLabel.TabStop = true;
      this.BlogLabel.Text = "blog.cumps.be";
      this.BlogLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.BlogLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClickLink);
      // 
      // DonateLabel
      // 
      this.DonateLabel.ActiveLinkColor = System.Drawing.Color.Black;
      this.DonateLabel.AutoSize = true;
      this.DonateLabel.BackColor = System.Drawing.Color.White;
      this.DonateLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.DonateLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.DonateLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.DonateLabel.Location = new System.Drawing.Point(12, 167);
      this.DonateLabel.Name = "DonateLabel";
      this.DonateLabel.Size = new System.Drawing.Size(113, 13);
      this.DonateLabel.TabIndex = 2;
      this.DonateLabel.TabStop = true;
      this.DonateLabel.Text = "Donate (PayPal)";
      this.DonateLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.DonateLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClickLink);
      // 
      // IconLabel
      // 
      this.IconLabel.ActiveLinkColor = System.Drawing.Color.Black;
      this.IconLabel.AutoSize = true;
      this.IconLabel.BackColor = System.Drawing.Color.White;
      this.IconLabel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.IconLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.IconLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.IconLabel.Location = new System.Drawing.Point(12, 204);
      this.IconLabel.Name = "IconLabel";
      this.IconLabel.Size = new System.Drawing.Size(190, 13);
      this.IconLabel.TabIndex = 3;
      this.IconLabel.TabStop = true;
      this.IconLabel.Text = "Silk Icon Set by Mark James";
      this.IconLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.IconLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClickLink);
      // 
      // OpenPGPLink
      // 
      this.OpenPGPLink.ActiveLinkColor = System.Drawing.Color.Black;
      this.OpenPGPLink.AutoSize = true;
      this.OpenPGPLink.BackColor = System.Drawing.Color.White;
      this.OpenPGPLink.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.OpenPGPLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.OpenPGPLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.OpenPGPLink.Location = new System.Drawing.Point(12, 226);
      this.OpenPGPLink.Name = "OpenPGPLink";
      this.OpenPGPLink.Size = new System.Drawing.Size(209, 13);
      this.OpenPGPLink.TabIndex = 4;
      this.OpenPGPLink.TabStop = true;
      this.OpenPGPLink.Text = "OpenPGP Wrapper by Starksoft";
      this.OpenPGPLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.OpenPGPLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClickLink);
      // 
      // ClipboardLink
      // 
      this.ClipboardLink.ActiveLinkColor = System.Drawing.Color.Black;
      this.ClipboardLink.AutoSize = true;
      this.ClipboardLink.BackColor = System.Drawing.Color.White;
      this.ClipboardLink.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ClipboardLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
      this.ClipboardLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.ClipboardLink.Location = new System.Drawing.Point(12, 248);
      this.ClipboardLink.Name = "ClipboardLink";
      this.ClipboardLink.Size = new System.Drawing.Size(249, 13);
      this.ClipboardLink.TabIndex = 5;
      this.ClipboardLink.TabStop = true;
      this.ClipboardLink.Text = "Clipboard Wrapper by Alessio Deiana";
      this.ClipboardLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(149)))), ((int)(((byte)(152)))));
      this.ClipboardLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ClickLink);
      // 
      // About
      // 
      this.AcceptButton = this.DonateLabel;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.BackgroundImage = global::CC.OutlookGnuPG.Properties.Resources.About;
      this.ClientSize = new System.Drawing.Size(321, 271);
      this.Controls.Add(this.ClipboardLink);
      this.Controls.Add(this.OpenPGPLink);
      this.Controls.Add(this.IconLabel);
      this.Controls.Add(this.DonateLabel);
      this.Controls.Add(this.BlogLabel);
      this.Controls.Add(this.AboutLabel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "About";
      this.Padding = new System.Windows.Forms.Padding(9);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "About";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label AboutLabel;
    private System.Windows.Forms.LinkLabel BlogLabel;
    private System.Windows.Forms.LinkLabel DonateLabel;
    private System.Windows.Forms.LinkLabel IconLabel;
    private System.Windows.Forms.LinkLabel OpenPGPLink;
    private System.Windows.Forms.LinkLabel ClipboardLink;

  }
}
