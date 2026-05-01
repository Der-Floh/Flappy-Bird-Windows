namespace Flappy_Bird_Windows.Forms;

sealed partial class BirdForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BirdForm));
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.BirdPixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            ((System.ComponentModel.ISupportInitialize)(this.BirdPixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AnimationTimer
            // 
            this.AnimationTimer.Interval = 80;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // BirdPixelBox
            // 
            this.BirdPixelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BirdPixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.yellowbird_upflap;
            this.BirdPixelBox.Location = new System.Drawing.Point(0, 0);
            this.BirdPixelBox.Name = "BirdPixelBox";
            this.BirdPixelBox.Size = new System.Drawing.Size(120, 86);
            this.BirdPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BirdPixelBox.TabIndex = 0;
            this.BirdPixelBox.TabStop = false;
            // 
            // BirdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(120, 86);
            this.Controls.Add(this.BirdPixelBox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BirdForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Shown += new System.EventHandler(this.Bird_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.BirdPixelBox)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Timer AnimationTimer;
    public CustomControls.PixelBox BirdPixelBox;
}
