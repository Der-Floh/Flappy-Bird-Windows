namespace Flappy_Bird_Windows.Forms;

sealed partial class SingleButtonForm
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleButtonForm));
        ButtonPixelBox = new CustomControls.PixelBox();
        ((System.ComponentModel.ISupportInitialize)ButtonPixelBox).BeginInit();
        SuspendLayout();
        // 
        // ButtonPixelBox
        // 
        ButtonPixelBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        ButtonPixelBox.Cursor = Cursors.Hand;
        ButtonPixelBox.Image = Properties.Resources.button_restart;
        ButtonPixelBox.Location = new Point(0, 0);
        ButtonPixelBox.Name = "ButtonPixelBox";
        ButtonPixelBox.Size = new Size(221, 83);
        ButtonPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        ButtonPixelBox.TabIndex = 0;
        ButtonPixelBox.TabStop = false;
        // 
        // SingleButtonForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(222, 83);
        Controls.Add(ButtonPixelBox);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SingleButtonForm";
        StartPosition = FormStartPosition.Manual;
        ((System.ComponentModel.ISupportInitialize)ButtonPixelBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    public CustomControls.PixelBox ButtonPixelBox;
}