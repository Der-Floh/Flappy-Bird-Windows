namespace Flappy_Bird_Windows.Forms;

sealed partial class ScoreForm
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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreForm));
        ScoreLabel = new Label();
        SuspendLayout();
        // 
        // ScoreLabel
        // 
        ScoreLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        ScoreLabel.Font = new Font("Segoe UI", 28F);
        ScoreLabel.Location = new Point(0, 0);
        ScoreLabel.Name = "ScoreLabel";
        ScoreLabel.Size = new Size(122, 53);
        ScoreLabel.TabIndex = 0;
        ScoreLabel.Text = "0";
        ScoreLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ScoreForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(120, 52);
        Controls.Add(ScoreLabel);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ScoreForm";
        StartPosition = FormStartPosition.Manual;
        Text = "Score";
        ResumeLayout(false);
    }

    #endregion

    private Label ScoreLabel;
}