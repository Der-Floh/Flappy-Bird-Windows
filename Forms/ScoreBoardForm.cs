namespace Flappy_Bird_Windows.Forms;

public sealed partial class ScoreBoardForm : Form
{
    public int Score { get => _score; set { _score = value; SetScore(value); } }
    private int _score;
    public int BestScore { get => _bestScore; set { _bestScore = value; BestScoreLabel.Text = value.ToString(); } }
    private int _bestScore;

    public ScoreBoardForm()
    {
        InitializeComponent();

        TopMost = Program.GameplayConfig.AlwaysOnTop;
        BackColor = Color.FromArgb(255, 222, 216, 149);

        CurrScoreLabel.Font = new Font(Program.Fonts.Families[0], CurrScoreLabel.Font.Size);
        BestScoreLabel.Font = new Font(Program.Fonts.Families[0], BestScoreLabel.Font.Size);
    }

    public void SetScore(int score)
    {
        CurrScoreLabel.Text = score.ToString();
        if (score > BestScore)
        {
            BestScore = score;
            NewPixelBox.Visible = true;
        }
        else
        {
            NewPixelBox.Visible = false;
        }
        SetScoreMedal(score);
    }

    public void SetScoreMedal(int score)
    {
        if (score >= 40)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_platinum") as Bitmap;
        else if (score >= 30)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_gold") as Bitmap;
        else if (score >= 20)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_silver") as Bitmap;
        else if (score >= 10)
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_bronze") as Bitmap;
        else
            MedalPixelBox.Image = Properties.Resources.ResourceManager.GetObject("medal_empty") as Bitmap;
    }
}
