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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverForm));
            this.GameOverPixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameOverPixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GameOverPixelBox
            // 
            this.GameOverPixelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameOverPixelBox.BackColor = System.Drawing.Color.Transparent;
            this.GameOverPixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.text_game_over;
            this.GameOverPixelBox.Location = new System.Drawing.Point(0, 0);
            this.GameOverPixelBox.Name = "GameOverPixelBox";
            this.GameOverPixelBox.Size = new System.Drawing.Size(509, 104);
            this.GameOverPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GameOverPixelBox.TabIndex = 10;
            this.GameOverPixelBox.TabStop = false;
            // 
            // GameOverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(508, 104);
            this.Controls.Add(this.GameOverPixelBox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameOverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameOverForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.GameOverPixelBox)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion
    private CustomControls.PixelBox GameOverPixelBox;
}