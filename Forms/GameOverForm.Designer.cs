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
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverForm));
        RestartButton = new Button();
        SuspendLayout();
        // 
        // RestartButton
        // 
        RestartButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        RestartButton.Cursor = Cursors.Hand;
        RestartButton.Location = new Point(12, 397);
        RestartButton.Name = "RestartButton";
        RestartButton.Size = new Size(776, 41);
        RestartButton.TabIndex = 0;
        RestartButton.Text = "Restart";
        RestartButton.UseVisualStyleBackColor = true;
        RestartButton.Click += RestartButton_Click;
        // 
        // GameOver
        // 
        AcceptButton = RestartButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImage = Properties.Resources.gameover;
        BackgroundImageLayout = ImageLayout.Zoom;
        ClientSize = new Size(800, 450);
        Controls.Add(RestartButton);
        DoubleBuffered = true;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "GameOver";
        StartPosition = FormStartPosition.CenterScreen;
        TopMost = true;
        ResumeLayout(false);
    }

    #endregion

    private Button RestartButton;
}