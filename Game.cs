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

        PipeSpawnTimer.Interval = Program.GameplayConfig.PipeSpawnDelay;

        GameOverForm = new GameOver();
        GameOverForm.FormClosed += (_, _) => Close();
        GameOverForm.RestartEvent += (_, _) => Reset();

        PipeManager = new PipeManager();

        BirdManager = new BirdManager();
        BirdManager.GameOver += (_, _) => GameOver();

        ScoreForm = new Score();
        ScoreForm.Show();

        Task.Run(CollisionChecker);

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
                    BirdCollided(bird.Value);
                }
                if (PipeManager.HasScoreCollision(birdRect) && _lastScoreCount.AddSeconds(1) < DateTime.Now)
                {
                    ScoreCollided(ScoreForm);
                    _lastScoreCount = DateTime.Now;
                }
            }
        }
        catch { }
    }

    private static void BirdCollided(Bird bird)
    {
        if (bird.InvokeRequired)
        {
            bird.BeginInvoke(new Action(() => BirdCollided(bird)));
            return;
        }
        bird.KillBird();
    }

    private static void ScoreCollided(Score score)
    {
        if (score.InvokeRequired)
        {
            score.BeginInvoke(new Action(() => ScoreCollided(score)));
            return;
        }
        score.AddScore();
    }

    private async Task CollisionChecker()
    {
        while (true)
        {
            if (IsGameOver)
                continue;

            CheckCollision();
            await Task.Delay(20);
        }
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
