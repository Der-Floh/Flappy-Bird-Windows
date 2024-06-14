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
        CurrScoreLabel = new Label();
        BestScoreLabel = new Label();
        GameOverPixelBox = new CustomControls.PixelBox();
        ScoreBoardPixelBox = new CustomControls.PixelBox();
        MedalPixelBox = new CustomControls.PixelBox();
        NewPixelBox = new CustomControls.PixelBox();
        ((System.ComponentModel.ISupportInitialize)GameOverPixelBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)ScoreBoardPixelBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)MedalPixelBox).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NewPixelBox).BeginInit();
        SuspendLayout();
        // 
        // RestartButton
        // 
        RestartButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        RestartButton.Cursor = Cursors.Hand;
        RestartButton.Location = new Point(12, 421);
        RestartButton.Name = "RestartButton";
        RestartButton.Size = new Size(506, 41);
        RestartButton.TabIndex = 0;
        RestartButton.Text = "Restart";
        RestartButton.UseVisualStyleBackColor = true;
        RestartButton.Click += RestartButton_Click;
        // 
        // CurrScoreLabel
        // 
        CurrScoreLabel.BackColor = Color.Transparent;
        CurrScoreLabel.Font = new Font("Lucida Console", 36F);
        CurrScoreLabel.ForeColor = Color.White;
        CurrScoreLabel.Location = new Point(257, 206);
        CurrScoreLabel.Name = "CurrScoreLabel";
        CurrScoreLabel.Size = new Size(228, 54);
        CurrScoreLabel.TabIndex = 6;
        CurrScoreLabel.Text = "0";
        CurrScoreLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // BestScoreLabel
        // 
        BestScoreLabel.Font = new Font("Lucida Console", 36F);
        BestScoreLabel.ForeColor = Color.White;
        BestScoreLabel.Location = new Point(257, 316);
        BestScoreLabel.Name = "BestScoreLabel";
        BestScoreLabel.Size = new Size(228, 54);
        BestScoreLabel.TabIndex = 7;
        BestScoreLabel.Text = "0";
        BestScoreLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // GameOverPixelBox
        // 
        GameOverPixelBox.BackColor = Color.Transparent;
        GameOverPixelBox.Image = Properties.Resources.text_game_over;
        GameOverPixelBox.Location = new Point(12, 12);
        GameOverPixelBox.Name = "GameOverPixelBox";
        GameOverPixelBox.Size = new Size(506, 104);
        GameOverPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        GameOverPixelBox.TabIndex = 10;
        GameOverPixelBox.TabStop = false;
        // 
        // ScoreBoardPixelBox
        // 
        ScoreBoardPixelBox.BackColor = Color.Transparent;
        ScoreBoardPixelBox.Image = Properties.Resources.score_board;
        ScoreBoardPixelBox.Location = new Point(12, 122);
        ScoreBoardPixelBox.Name = "ScoreBoardPixelBox";
        ScoreBoardPixelBox.Size = new Size(506, 288);
        ScoreBoardPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        ScoreBoardPixelBox.TabIndex = 11;
        ScoreBoardPixelBox.TabStop = false;
        // 
        // MedalPixelBox
        // 
        MedalPixelBox.BackColor = Color.Transparent;
        MedalPixelBox.Image = Properties.Resources.medal_empty;
        MedalPixelBox.Location = new Point(68, 219);
        MedalPixelBox.Name = "MedalPixelBox";
        MedalPixelBox.Size = new Size(106, 106);
        MedalPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        MedalPixelBox.TabIndex = 12;
        MedalPixelBox.TabStop = false;
        // 
        // NewPixelBox
        // 
        NewPixelBox.BackColor = Color.Transparent;
        NewPixelBox.Image = Properties.Resources.text_new;
        NewPixelBox.Location = new Point(316, 267);
        NewPixelBox.Name = "NewPixelBox";
        NewPixelBox.Size = new Size(69, 35);
        NewPixelBox.SizeMode = PictureBoxSizeMode.StretchImage;
        NewPixelBox.TabIndex = 13;
        NewPixelBox.TabStop = false;
        // 
        // GameOverForm
        // 
        AcceptButton = RestartButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.PaleGoldenrod;
        ClientSize = new Size(530, 474);
        Controls.Add(NewPixelBox);
        Controls.Add(MedalPixelBox);
        Controls.Add(GameOverPixelBox);
        Controls.Add(BestScoreLabel);
        Controls.Add(CurrScoreLabel);
        Controls.Add(RestartButton);
        Controls.Add(ScoreBoardPixelBox);
        DoubleBuffered = true;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "GameOverForm";
        StartPosition = FormStartPosition.CenterScreen;
        ((System.ComponentModel.ISupportInitialize)GameOverPixelBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)ScoreBoardPixelBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)MedalPixelBox).EndInit();
        ((System.ComponentModel.ISupportInitialize)NewPixelBox).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button RestartButton;
    private Label CurrScoreLabel;
    private Label BestScoreLabel;
    private CustomControls.PixelBox GameOverPixelBox;
    private CustomControls.PixelBox ScoreBoardPixelBox;
    private CustomControls.PixelBox MedalPixelBox;
    private CustomControls.PixelBox NewPixelBox;
}