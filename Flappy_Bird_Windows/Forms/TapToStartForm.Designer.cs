namespace Flappy_Bird_Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TapToStartForm));
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopToStartPixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            this.MainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopToStartPixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseMenuItem,
            this.OptionsMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(337, 24);
            this.MainMenuStrip.TabIndex = 1;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Image = global::Flappy_Bird_Windows.Properties.Resources.button_close_image;
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new System.Drawing.Size(64, 20);
            this.CloseMenuItem.Text = "Close";
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.Image = global::Flappy_Bird_Windows.Properties.Resources.button_settings_image;
            this.OptionsMenuItem.Name = "OptionsMenuItem";
            this.OptionsMenuItem.Size = new System.Drawing.Size(77, 20);
            this.OptionsMenuItem.Text = "Options";
            // 
            // TopToStartPixelBox
            // 
            this.TopToStartPixelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopToStartPixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.tap_to_start;
            this.TopToStartPixelBox.Location = new System.Drawing.Point(12, 27);
            this.TopToStartPixelBox.Name = "TopToStartPixelBox";
            this.TopToStartPixelBox.Size = new System.Drawing.Size(313, 301);
            this.TopToStartPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TopToStartPixelBox.TabIndex = 2;
            this.TopToStartPixelBox.TabStop = false;
            // 
            // TapToStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(337, 340);
            this.Controls.Add(this.TopToStartPixelBox);
            this.Controls.Add(this.MainMenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TapToStartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TapToStartForm_FormClosing);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TopToStartPixelBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    public MenuStrip MainMenuStrip;
    public ToolStripMenuItem OptionsMenuItem;
    public ToolStripMenuItem CloseMenuItem;
    private CustomControls.PixelBox TopToStartPixelBox;
}