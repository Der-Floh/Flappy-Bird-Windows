using Flappy_Bird_Windows.Helper;

namespace Flappy_Bird_Windows.Forms;

public sealed partial class GameOverForm : Form
{
    public event EventHandler? RestartEvent;

    public GameOverForm()
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());

        InitializeComponent();

        TopMost = Program.GameplayConfig.AlwaysOnTop;
        BackColor = Color.FromArgb(255, 222, 216, 149);

        CurrScoreLabel.Font = new Font(Program.Fonts.Families[0], CurrScoreLabel.Font.Size);
        BestScoreLabel.Font = new Font(Program.Fonts.Families[0], BestScoreLabel.Font.Size);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        base.OnPaintBackground(e);
    }

    public void ShowGameOver(int score, int bestScore)
    {
        if (score > bestScore)
        {
            CurrScoreLabel.Text = score.ToString();
            BestScoreLabel.Text = score.ToString();
            NewPixelBox.Visible = true;
        }
        else
        {
            CurrScoreLabel.Text = score.ToString();
            BestScoreLabel.Text = bestScore.ToString();
            NewPixelBox.Visible = false;
        }

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

        Show();
    }

    private void RestartButton_Click(object sender, EventArgs e)
    {
        RestartEvent?.Invoke(this, EventArgs.Empty);
    }
}
