namespace Flappy_Bird_Windows;

public partial class Game : Form
{
    public GameOver GameOverForm { get; set; }
    public PipeManager PipeManager { get; set; }
    public BirdManager BirdManager { get; set; }
    public Score ScoreForm { get; set; }
    public bool GameOver { get => _gameOver; set { _gameOver = value; SetGameOver(value); } }
    private bool _gameOver;

    private DateTime _lastScoreCount = DateTime.MinValue;
    private DateTime _lastKeyDown = DateTime.MinValue;

    public Game()
    {
        InitializeComponent();

        GameOverForm = new GameOver();
        GameOverForm.FormClosed += (_, _) => Close();
        GameOverForm.RestartEvent += (_, _) => GameOver = false;

        PipeManager = new PipeManager();

        BirdManager = new BirdManager();
        BirdManager.GameOver += (_, _) => GameOver = true;

        ScoreForm = new Score();
        ScoreForm.Show();

        Thread.Sleep(500);
        BirdManager.NewBird(Color.Yellow);
    }

    public void Reset()
    {
        GameOverForm.Hide();
        PipeManager.KillAll();
        PipeSpawnTimer.Enabled = true;
        PipeMoveTimer.Enabled = true;
        BirdManager.ControlsEnabled = true;
        ScoreForm.Close();
        ScoreForm = new Score();
        ScoreForm.Show();

        Thread.Sleep(500);
        BirdManager.NewBird(Color.Yellow);
    }

    private void SetGameOver(bool gameOver)
    {
        if (gameOver)
        {
            BirdManager.KillBirds();
            PipeSpawnTimer.Enabled = false;
            PipeMoveTimer.Enabled = false;
            BirdManager.ControlsEnabled = false;
            GameOverForm.Show();
        }
        else
        {
            Reset();
        }
    }

    public void CheckCollision()
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

    private void PipeSpawnTimer_Tick(object sender, EventArgs e)
    {
        PipeManager.SpawnPipe();
    }

    private void GameTimer_Tick(object sender, EventArgs e)
    {
        if (!GameOver)
            CheckCollision();
    }

    private void PipeMoveTimer_Tick(object sender, EventArgs e)
    {
        PipeManager.MovePipes();
    }

    private void BirdMoveTimer_Tick(object sender, EventArgs e)
    {
        BirdManager.MoveBirds();

        if (!GameOver)
        {
            BirdManager.CheckKeyPresses();
            if (Keyboard.IsKeyDown(Program.ControlsConfig.GameOver))
                GameOver = true;
            if (Keyboard.IsKeyDown(Program.ControlsConfig.Player1) && !BirdManager.Birds.ContainsKey(Color.Yellow))
                BirdManager.NewBird(Color.Yellow);
            if (Keyboard.IsKeyDown(Program.ControlsConfig.Player2) && !BirdManager.Birds.ContainsKey(Color.Blue))
                BirdManager.NewBird(Color.Blue);
            if (Keyboard.IsKeyDown(Program.ControlsConfig.Player3) && !BirdManager.Birds.ContainsKey(Color.Red))
                BirdManager.NewBird(Color.Red);
        }
    }
}
