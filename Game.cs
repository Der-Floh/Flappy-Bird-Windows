namespace Flappy_Bird_Windows;

public partial class Game : Form
{
    public GameOver GameOverForm { get; set; }
    public PipeManager PipeManager { get; set; }
    public BirdManager BirdManager { get; set; }
    public Score ScoreForm { get; set; }
    public bool IsGameOver { get; set; }

    private DateTime _lastScoreCount = DateTime.MinValue;

    public Game()
    {
        InitializeComponent();

        GameOverForm = new GameOver();
        GameOverForm.FormClosed += (_, _) => Close();
        GameOverForm.RestartEvent += (_, _) => Reset();

        PipeManager = new PipeManager();

        BirdManager = new BirdManager();
        BirdManager.GameOver += (_, _) => GameOver();

        ScoreForm = new Score();
        ScoreForm.Show();

        Thread.Sleep(200);
        BirdManager.NewBird(Color.Yellow);
    }

    public void Reset()
    {
        GameOverForm.Hide();
        PipeManager.KillAll();

        ScoreForm.Close();
        ScoreForm = new Score();
        ScoreForm.Show();

        Thread.Sleep(200);

        PipeSpawnTimer.Enabled = true;
        PipeMoveTimer.Enabled = true;
        BirdMoveTimer.Enabled = true;
        BirdManager.ControlsEnabled = true;

        BirdManager.NewBird(Color.Yellow);
        IsGameOver = false;
    }

    private void GameOver()
    {
        IsGameOver = true;
        BirdManager.KillBirds();

        BirdMoveTimer.Enabled = false;
        PipeSpawnTimer.Enabled = false;
        PipeMoveTimer.Enabled = false;
        BirdManager.ControlsEnabled = false;
        if (Program.GameplayConfig.CloseOnLoose)
            Close();
        else if (Program.GameplayConfig.InstantRestart)
            Reset();
        else
            GameOverForm.Show();
    }

    public void CheckCollision()
    {
        try
        {
            foreach (var bird in BirdManager.Birds)
            {
                var birdRect = new Rectangle(bird.Value.Location.X, bird.Value.Location.Y, bird.Value.Width, bird.Value.Height);
                if (PipeManager.HasCollision(birdRect))
                {
                    bird.Value.KillBird();
                }
                if (PipeManager.HasScoreCollision(birdRect) && _lastScoreCount.AddSeconds(1) < DateTime.Now)
                {
                    ScoreForm.AddScore();
                    _lastScoreCount = DateTime.Now;
                }
            }
        }
        catch { }
    }

    private void GameTimer_Tick(object sender, EventArgs e)
    {
        if (!IsGameOver)
            CheckCollision();
    }

    private void BirdMoveTimer_Tick(object sender, EventArgs e)
    {
        BirdManager.MoveBirds();

        if (!IsGameOver)
        {
            BirdManager.CheckKeyPresses();
            if (Keyboard.IsKeyDown(Program.ControlsConfig.GameOver))
                BirdManager.KillBirds();
            if (Keyboard.IsKeyDown(Program.ControlsConfig.Player1) && !BirdManager.Birds.ContainsKey(Color.Yellow))
                BirdManager.NewBird(Color.Yellow);
            if (Keyboard.IsKeyDown(Program.ControlsConfig.Player2) && !BirdManager.Birds.ContainsKey(Color.Blue))
                BirdManager.NewBird(Color.Blue);
            if (Keyboard.IsKeyDown(Program.ControlsConfig.Player3) && !BirdManager.Birds.ContainsKey(Color.Red))
                BirdManager.NewBird(Color.Red);
        }
    }

    private void PipeSpawnTimer_Tick(object sender, EventArgs e) => PipeManager.SpawnPipe();

    private void PipeMoveTimer_Tick(object sender, EventArgs e) => PipeManager.MovePipes();
}
