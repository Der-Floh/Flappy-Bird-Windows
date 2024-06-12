namespace Flappy_Bird_Windows;

public sealed class PipeManager
{
    public List<PipePair> Pipes { get; } = [];
    private readonly int _screenHeight;
    private readonly int _screenWidth;
    private readonly Random _random = new Random();

    private int _lastGapY;

    public PipeManager()
    {
        _screenHeight = Screen.PrimaryScreen!.Bounds.Height;
        _screenWidth = Screen.PrimaryScreen!.Bounds.Width;
        _lastGapY = _random.Next(_screenHeight / 3);
    }

    public void Show()
    {
        foreach (var pipePair in Pipes)
        {
            pipePair.Show();
        }
    }

    public void KillAll()
    {
        foreach (var pipePair in Pipes.ToArray())
        {
            pipePair.Kill();
        }
    }

    public void MovePipes()
    {
        foreach (var pipePair in Pipes.ToArray())
        {
            pipePair.Move();
        }
    }

    public void SpawnPipe()
    {
        var gap = _random.Next(Program.GameplayConfig.PipeGapMin, Program.GameplayConfig.PipeGapMax);
        var pipeTopHeight = Math.Clamp(_random.Next(_lastGapY - Program.GameplayConfig.PipeGapShift, _lastGapY + Program.GameplayConfig.PipeGapShift), 50, _screenHeight - gap - 100);
        var pipeBottomHeight = _screenHeight - gap - pipeTopHeight;
        _lastGapY = pipeTopHeight;

        var pipeTopForm = new PipeTop();
        pipeTopForm.Size = new Size(pipeTopForm.Width, pipeTopHeight);
        pipeTopForm.Location = new Point(_screenWidth - pipeTopForm.Width + Program.GameplayConfig.PipeSpawnOffset, 0);

        var pipeBottomForm = new PipeBottom();
        pipeBottomForm.Size = new Size(pipeBottomForm.Width, pipeBottomHeight);
        pipeBottomForm.Location = new Point(_screenWidth - pipeBottomForm.Width + Program.GameplayConfig.PipeSpawnOffset, _screenHeight - pipeBottomHeight);

        var pipePair = new PipePair(pipeTopForm, pipeBottomForm);
        pipePair.Closed += PipePair_Closed;
        Pipes.Add(pipePair);
        pipePair.Show();
    }

    private void PipePair_Closed(object? sender, EventArgs e)
    {
        if (sender is PipePair pipePair)
        {
            pipePair.Closed -= PipePair_Closed;
            Pipes.Remove(pipePair);
        }
    }

    public bool HasCollision(Rectangle birdRect)
    {
        foreach (var pipe in Pipes)
        {
            if (pipe.HasCollision(birdRect))
                return true;
        }
        return false;
    }

    public bool HasScoreCollision(Rectangle birdRect)
    {
        foreach (var pipe in Pipes)
        {
            var scoreRect = new Rectangle(pipe.GetScoreCalcLocationX(), 0, 1, _screenHeight);
            if (birdRect.IntersectsWith(scoreRect))
                return true;
        }
        return false;
    }
}
