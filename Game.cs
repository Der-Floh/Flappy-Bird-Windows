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
        GameOverForm.FormClosed += (sender, e) => Close();
        GameOverForm.RestartEvent += GameOverForm_RestartEvent;

        PipeManager = new PipeManager();

        BirdManager = new BirdManager();
        BirdManager.GameOver += BirdManager_GameOver;

        ScoreForm = new Score();
        ScoreForm.Show();

        Thread.Sleep(500);
        BirdManager.NewBird(Color.Yellow);
    }

    private void GameOverForm_RestartEvent(object? sender, EventArgs e) => GameOver = false;

    private void BirdManager_GameOver(object? sender, EventArgs e) => GameOver = true;

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
                //bird.Value.ControlsEnabled = false;
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
        if (GameOver)
            return;

        CheckCollision();

        if (GameOver)
            return;

        BirdManager.CheckKeyPresses();
        if (Keyboard.IsKeyDown(Keys.Space) && !BirdManager.Birds.ContainsKey(Color.Yellow))
            BirdManager.NewBird(Color.Yellow);
        if (Keyboard.IsKeyDown(Keys.Up) && !BirdManager.Birds.ContainsKey(Color.Blue))
            BirdManager.NewBird(Color.Blue);
        if (Keyboard.IsKeyDown(Keys.NumPad8) && !BirdManager.Birds.ContainsKey(Color.Red))
            BirdManager.NewBird(Color.Red);
    }

    private void PipeMoveTimer_Tick(object sender, EventArgs e)
    {
        PipeManager.MovePipes();
    }

    private void BirdMoveTimer_Tick(object sender, EventArgs e)
    {
        BirdManager.MoveBirds();
    }
}
