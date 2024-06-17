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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(TapToStartForm));
        TopToStartPixelBox = new CustomControls.PixelBox();
        ((System.ComponentModel.ISupportInitialize)TopToStartPixelBox).BeginInit();
        SuspendLayout();
        // 
        // TopToStartPixelBox
        // 
        TopToStartPixelBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        TopToStartPixelBox.Image = Properties.Resources.tap_to_start;
        TopToStartPixelBox.Location = new Point(0, 0);
        TopToStartPixelBox.Name = "TopToStartPixelBox";
        TopToStartPixelBox.Size = new Size(356, 340);
        TopToStartPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        TopToStartPixelBox.TabIndex = 0;
        TopToStartPixelBox.TabStop = false;
        // 
        // TapToStartForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(357, 340);
        Controls.Add(TopToStartPixelBox);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "TapToStartForm";
        StartPosition = FormStartPosition.Manual;
        FormClosing += TapToStartForm_FormClosing;
        ((System.ComponentModel.ISupportInitialize)TopToStartPixelBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    public CustomControls.PixelBox TopToStartPixelBox;
}