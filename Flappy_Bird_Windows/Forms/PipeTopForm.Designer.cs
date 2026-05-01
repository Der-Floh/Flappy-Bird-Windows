namespace Flappy_Bird_Windows.Forms;

sealed partial class PipeTopForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PipeTopForm));
            this.PipeBottomPixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            this.PipeMiddlePixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            ((System.ComponentModel.ISupportInitialize)(this.PipeBottomPixelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PipeMiddlePixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PipeBottomPixelBox
            // 
            this.PipeBottomPixelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PipeBottomPixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.pipe_top;
            this.PipeBottomPixelBox.Location = new System.Drawing.Point(0, 589);
            this.PipeBottomPixelBox.Name = "PipeBottomPixelBox";
            this.PipeBottomPixelBox.Size = new System.Drawing.Size(124, 124);
            this.PipeBottomPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PipeBottomPixelBox.TabIndex = 1;
            this.PipeBottomPixelBox.TabStop = false;
            // 
            // PipeMiddlePixelBox
            // 
            this.PipeMiddlePixelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PipeMiddlePixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.pipe_middle;
            this.PipeMiddlePixelBox.Location = new System.Drawing.Point(0, 0);
            this.PipeMiddlePixelBox.Name = "PipeMiddlePixelBox";
            this.PipeMiddlePixelBox.Size = new System.Drawing.Size(124, 589);
            this.PipeMiddlePixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PipeMiddlePixelBox.TabIndex = 2;
            this.PipeMiddlePixelBox.TabStop = false;
            // 
            // PipeTopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(124, 712);
            this.Controls.Add(this.PipeMiddlePixelBox);
            this.Controls.Add(this.PipeBottomPixelBox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PipeTopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.PipeBottomPixelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PipeMiddlePixelBox)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private CustomControls.PixelBox PipeBottomPixelBox;
    private CustomControls.PixelBox PipeMiddlePixelBox;
}