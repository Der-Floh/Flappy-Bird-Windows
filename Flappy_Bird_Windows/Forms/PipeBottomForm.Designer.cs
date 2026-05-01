namespace Flappy_Bird_Windows.Forms;

sealed partial class PipeBottomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PipeBottomForm));
            this.PipeTopPixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            this.PipeMiddlePixelBox = new Flappy_Bird_Windows.CustomControls.PixelBox();
            ((System.ComponentModel.ISupportInitialize)(this.PipeTopPixelBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PipeMiddlePixelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PipeTopPixelBox
            // 
            this.PipeTopPixelBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PipeTopPixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.pipe_bottom;
            this.PipeTopPixelBox.Location = new System.Drawing.Point(0, 0);
            this.PipeTopPixelBox.Name = "PipeTopPixelBox";
            this.PipeTopPixelBox.Size = new System.Drawing.Size(124, 124);
            this.PipeTopPixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PipeTopPixelBox.TabIndex = 0;
            this.PipeTopPixelBox.TabStop = false;
            // 
            // PipeMiddlePixelBox
            // 
            this.PipeMiddlePixelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PipeMiddlePixelBox.Image = global::Flappy_Bird_Windows.Properties.Resources.pipe_middle;
            this.PipeMiddlePixelBox.Location = new System.Drawing.Point(0, 124);
            this.PipeMiddlePixelBox.Name = "PipeMiddlePixelBox";
            this.PipeMiddlePixelBox.Size = new System.Drawing.Size(124, 589);
            this.PipeMiddlePixelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PipeMiddlePixelBox.TabIndex = 1;
            this.PipeMiddlePixelBox.TabStop = false;
            // 
            // PipeBottomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(124, 712);
            this.Controls.Add(this.PipeMiddlePixelBox);
            this.Controls.Add(this.PipeTopPixelBox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PipeBottomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.PipeTopPixelBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PipeMiddlePixelBox)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private CustomControls.PixelBox PipeTopPixelBox;
    private CustomControls.PixelBox PipeMiddlePixelBox;
}