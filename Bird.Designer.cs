namespace Flappy_Bird_Windows;

partial class Bird
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(Bird));
        AnimationTimer = new System.Windows.Forms.Timer(components);
        SuspendLayout();
        // 
        // AnimationTimer
        // 
        AnimationTimer.Interval = 200;
        AnimationTimer.Tick += AnimationTimer_Tick;
        // 
        // Bird
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = Properties.Resources.yellowbird_upflap;
        BackgroundImageLayout = ImageLayout.Zoom;
        ClientSize = new Size(120, 86);
        DoubleBuffered = true;
        Icon = (Icon)resources.GetObject("$this.Icon");
        KeyPreview = true;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Bird";
        SizeGripStyle = SizeGripStyle.Hide;
        StartPosition = FormStartPosition.Manual;
        TopMost = true;
        Shown += Bird_Shown;
        ResumeLayout(false);
    }

    #endregion
    private System.Windows.Forms.Timer AnimationTimer;
}
