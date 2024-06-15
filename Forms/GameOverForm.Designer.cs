namespace Flappy_Bird_Windows.Forms;

sealed partial class GameOverForm
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverForm));
        GameOverPixelBox = new CustomControls.PixelBox();
        ((System.ComponentModel.ISupportInitialize)GameOverPixelBox).BeginInit();
        SuspendLayout();
        // 
        // GameOverPixelBox
        // 
        GameOverPixelBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        GameOverPixelBox.BackColor = Color.Transparent;
        GameOverPixelBox.Image = Properties.Resources.text_game_over;
        GameOverPixelBox.Location = new Point(0, 0);
        GameOverPixelBox.Name = "GameOverPixelBox";
        GameOverPixelBox.Size = new Size(509, 104);
        GameOverPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        GameOverPixelBox.TabIndex = 10;
        GameOverPixelBox.TabStop = false;
        // 
        // GameOverForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.PaleGoldenrod;
        ClientSize = new Size(508, 104);
        Controls.Add(GameOverPixelBox);
        DoubleBuffered = true;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "GameOverForm";
        StartPosition = FormStartPosition.Manual;
        FormClosing += GameOverForm_FormClosing;
        ((System.ComponentModel.ISupportInitialize)GameOverPixelBox).EndInit();
        ResumeLayout(false);
    }

    #endregion
    private CustomControls.PixelBox GameOverPixelBox;
}