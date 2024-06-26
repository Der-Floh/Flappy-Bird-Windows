﻿namespace Flappy_Bird_Windows.Forms;

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
        components = new System.ComponentModel.Container();
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(BirdForm));
        AnimationTimer = new System.Windows.Forms.Timer(components);
        BirdPixelBox = new CustomControls.PixelBox();
        ((System.ComponentModel.ISupportInitialize)BirdPixelBox).BeginInit();
        SuspendLayout();
        // 
        // AnimationTimer
        // 
        AnimationTimer.Interval = 80;
        AnimationTimer.Tick += AnimationTimer_Tick;
        // 
        // BirdPixelBox
        // 
        BirdPixelBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        BirdPixelBox.Image = Properties.Resources.yellowbird_upflap;
        BirdPixelBox.Location = new Point(0, 0);
        BirdPixelBox.Name = "BirdPixelBox";
        BirdPixelBox.Size = new Size(120, 86);
        BirdPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        BirdPixelBox.TabIndex = 0;
        BirdPixelBox.TabStop = false;
        // 
        // BirdForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(120, 86);
        Controls.Add(BirdPixelBox);
        DoubleBuffered = true;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "BirdForm";
        StartPosition = FormStartPosition.Manual;
        Shown += Bird_Shown;
        ((System.ComponentModel.ISupportInitialize)BirdPixelBox).EndInit();
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Timer AnimationTimer;
    public CustomControls.PixelBox BirdPixelBox;
}
