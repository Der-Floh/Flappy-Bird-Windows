﻿namespace Flappy_Bird_Windows.Forms;

sealed partial class TapToStartForm
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(TapToStartForm));
        TopToStartPixelBox = new CustomControls.PixelBox();
        MainMenuStrip = new MenuStrip();
        CloseMenuItem = new ToolStripMenuItem();
        OptionsMenuItem = new ToolStripMenuItem();
        ((System.ComponentModel.ISupportInitialize)TopToStartPixelBox).BeginInit();
        MainMenuStrip.SuspendLayout();
        SuspendLayout();
        // 
        // TopToStartPixelBox
        // 
        TopToStartPixelBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        TopToStartPixelBox.Image = Properties.Resources.tap_to_start;
        TopToStartPixelBox.Location = new Point(0, 27);
        TopToStartPixelBox.Name = "TopToStartPixelBox";
        TopToStartPixelBox.Size = new Size(336, 313);
        TopToStartPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        TopToStartPixelBox.TabIndex = 0;
        TopToStartPixelBox.TabStop = false;
        // 
        // MainMenuStrip
        // 
        MainMenuStrip.Items.AddRange(new ToolStripItem[] { CloseMenuItem, OptionsMenuItem });
        MainMenuStrip.Location = new Point(0, 0);
        MainMenuStrip.Name = "MainMenuStrip";
        MainMenuStrip.Size = new Size(337, 24);
        MainMenuStrip.TabIndex = 1;
        MainMenuStrip.Text = "menuStrip1";
        // 
        // CloseMenuItem
        // 
        CloseMenuItem.Image = Properties.Resources.button_close_image;
        CloseMenuItem.Name = "CloseMenuItem";
        CloseMenuItem.Size = new Size(64, 20);
        CloseMenuItem.Text = "Close";
        // 
        // OptionsMenuItem
        // 
        OptionsMenuItem.Image = Properties.Resources.button_settings_image;
        OptionsMenuItem.Name = "OptionsMenuItem";
        OptionsMenuItem.Size = new Size(77, 20);
        OptionsMenuItem.Text = "Options";
        // 
        // TapToStartForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(337, 340);
        Controls.Add(TopToStartPixelBox);
        Controls.Add(MainMenuStrip);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "TapToStartForm";
        StartPosition = FormStartPosition.Manual;
        FormClosing += TapToStartForm_FormClosing;
        ((System.ComponentModel.ISupportInitialize)TopToStartPixelBox).EndInit();
        MainMenuStrip.ResumeLayout(false);
        MainMenuStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    public CustomControls.PixelBox TopToStartPixelBox;
    public MenuStrip MainMenuStrip;
    public ToolStripMenuItem OptionsMenuItem;
    public ToolStripMenuItem CloseMenuItem;
}