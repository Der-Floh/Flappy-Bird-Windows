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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleButtonForm));
            this.ButtonPixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonPixelBox
            // 
            this.ButtonPixelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonPixelBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonPixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.button_restart;
            this.ButtonPixelBox.Location = new System.Drawing.Point(0, 0);
            this.ButtonPixelBox.Name = "ButtonPixelBox";
            this.ButtonPixelBox.Size = new System.Drawing.Size(221, 83);
            this.ButtonPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ButtonPixelBox.TabIndex = 0;
            this.ButtonPixelBox.TabStop = false;
            // 
            // SingleButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(222, 83);
            this.Controls.Add(this.ButtonPixelBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SingleButtonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.ButtonPixelBox)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    public CustomControls.PixelBox ButtonPixelBox;
}