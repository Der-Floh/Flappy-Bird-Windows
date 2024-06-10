namespace Flappy_Bird_Windows;

public sealed class PipeManager
{
    public List<PipePair> Pipes { get; } = [];
    private readonly int _screenHeight;
    private readonly int _screenWidth;

    public PipeManager()
    {
        _screenHeight = Screen.PrimaryScreen!.Bounds.Height;
        _screenWidth = Screen.PrimaryScreen!.Bounds.Width;
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
            pipePair.MovePipes();
        }
    }

    public void SpawnPipe()
    {
        var gap = new Random().Next(400, 500);
        var pipeTopHeight = new Random().Next(50, _screenHeight - gap - 100);
        var pipeBottomHeight = _screenHeight - gap - pipeTopHeight;

        var pipeTopForm = new PipeTop();
        pipeTopForm.Size = new Size(pipeTopForm.Width, pipeTopHeight);
        pipeTopForm.Location = new Point(_screenWidth - pipeTopForm.Width, 0);

        var pipeBottomForm = new PipeBottom();
        pipeBottomForm.Size = new Size(pipeBottomForm.Width, pipeBottomHeight);
        pipeBottomForm.Location = new Point(_screenWidth - pipeBottomForm.Width, _screenHeight - pipeBottomHeight);

        var pipePair = new PipePair(pipeTopForm, pipeBottomForm);
        pipePair.Closed += PipePair_Closed;
        Pipes.Add(pipePair);
        pipePair.Show();
    }

    private void PipePair_Closed(object? sender, EventArgs e)
    {
        if (sender is PipePair pipePair)
            Pipes.Remove(pipePair);
    }

    public bool HasCollision(Rectangle birdRect)
    {
        foreach (var pipe in Pipes)
        {
            if (birdRect.IntersectsWith(pipe.PipeTop.Bounds) || birdRect.IntersectsWith(pipe.PipeBottom.Bounds))
                return true;
        }
        return false;
    }

    public bool HasScoreCollision(Rectangle birdRect)
    {
        foreach (var pipe in Pipes)
        {
            var scoreRect = new Rectangle(pipe.PipeTop.Location.X + pipe.PipeTop.Width, 0, 1, _screenHeight);
            if (birdRect.IntersectsWith(scoreRect))
                return true;
        }
        return false;
    }
}
