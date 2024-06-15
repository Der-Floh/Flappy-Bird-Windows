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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(PipeTopForm));
        PipeBottomPixelBox = new CustomControls.PixelBox();
        PipeMiddlePixelBox = new CustomControls.PixelBox();
        ((System.ComponentModel.ISupportInitialize)PipeBottomPixelBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)PipeMiddlePixelBox).BeginInit();
        SuspendLayout();
        // 
        // PipeBottomPixelBox
        // 
        PipeBottomPixelBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        PipeBottomPixelBox.Image = Properties.Resources.pipe_top;
        PipeBottomPixelBox.Location = new Point(0, 589);
        PipeBottomPixelBox.Name = "PipeBottomPixelBox";
        PipeBottomPixelBox.Size = new Size(124, 124);
        PipeBottomPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        PipeBottomPixelBox.TabIndex = 1;
        PipeBottomPixelBox.TabStop = false;
        // 
        // PipeMiddlePixelBox
        // 
        PipeMiddlePixelBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        PipeMiddlePixelBox.Image = Properties.Resources.pipe_middle;
        PipeMiddlePixelBox.Location = new Point(0, 0);
        PipeMiddlePixelBox.Name = "PipeMiddlePixelBox";
        PipeMiddlePixelBox.Size = new Size(124, 589);
        PipeMiddlePixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        PipeMiddlePixelBox.TabIndex = 2;
        PipeMiddlePixelBox.TabStop = false;
        // 
        // PipeTopForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(124, 712);
        Controls.Add(PipeMiddlePixelBox);
        Controls.Add(PipeBottomPixelBox);
        DoubleBuffered = true;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "PipeTopForm";
        StartPosition = FormStartPosition.Manual;
        ((System.ComponentModel.ISupportInitialize)PipeBottomPixelBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)PipeMiddlePixelBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private CustomControls.PixelBox PipeBottomPixelBox;
    private CustomControls.PixelBox PipeMiddlePixelBox;
}