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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(PipeBottomForm));
        PipeTopPixelBox = new CustomControls.PixelBox();
        PipeMiddlePixelBox = new CustomControls.PixelBox();
        ((System.ComponentModel.ISupportInitialize)PipeTopPixelBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PipeMiddlePixelBox).BeginInit();
        SuspendLayout();
        // 
        // PipeTopPixelBox
        // 
        PipeTopPixelBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        PipeTopPixelBox.Image = Properties.Resources.pipe_bottom;
        PipeTopPixelBox.Location = new Point(0, 0);
        PipeTopPixelBox.Name = "PipeTopPixelBox";
        PipeTopPixelBox.Size = new Size(124, 124);
        PipeTopPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        PipeTopPixelBox.TabIndex = 0;
        PipeTopPixelBox.TabStop = false;
        // 
        // PipeMiddlePixelBox
        // 
        PipeMiddlePixelBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        PipeMiddlePixelBox.Image = Properties.Resources.pipe_middle;
        PipeMiddlePixelBox.Location = new Point(0, 124);
        PipeMiddlePixelBox.Name = "PipeMiddlePixelBox";
        PipeMiddlePixelBox.Size = new Size(124, 589);
        PipeMiddlePixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        PipeMiddlePixelBox.TabIndex = 1;
        PipeMiddlePixelBox.TabStop = false;
        // 
        // PipeBottomForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(124, 712);
        Controls.Add(PipeMiddlePixelBox);
        Controls.Add(PipeTopPixelBox);
        DoubleBuffered = true;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PipeBottomForm";
        StartPosition = FormStartPosition.Manual;
        ((System.ComponentModel.ISupportInitialize)PipeTopPixelBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)PipeMiddlePixelBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private CustomControls.PixelBox PipeTopPixelBox;
    private CustomControls.PixelBox PipeMiddlePixelBox;
}