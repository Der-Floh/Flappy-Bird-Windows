namespace Flappy_Bird_Windows;

public sealed class PipePair
{
    public Guid Id { get; } = Guid.NewGuid();
    public PipeTop PipeTop { get; private set; }
    public PipeBottom PipeBottom { get; private set; }
    public event EventHandler? Closed;

    public PipePair(PipeTop pipeTop, PipeBottom pipeBottom)
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());

        PipeTop = pipeTop;
        PipeBottom = pipeBottom;

        PipeTop.FormClosed += PipeTop_FormClosed;
        PipeBottom.FormClosed += PipeBottom_FormClosed;
    }

    public void Show()
    {
        PipeTop.Show();
        PipeBottom.Show();
    }

    public void Kill()
    {
        PipeTop.Close();
        PipeBottom.Close();
    }

    public void Move()
    {
        PipeTop.MovePipe();
        PipeBottom.MovePipe();
    }

    public bool HasCollision(Rectangle birdRect)
    {
        if (!PipeTop.IsDisposed && birdRect.IntersectsWith(PipeTop.Bounds))
            return true;

        if (!PipeBottom.IsDisposed && birdRect.IntersectsWith(PipeBottom.Bounds))
            return true;

        return false;
    }

    public int GetScoreCalcLocationX()
    {
        if (!PipeTop.IsDisposed)
            return PipeTop.Location.X + PipeTop.Width / 2;

        if (!PipeBottom.IsDisposed)
            return PipeBottom.Location.X + PipeBottom.Width / 2;

        return 0;
    }

    private void CheckAndRaiseClosed()
    {
        if (PipeTop.IsDisposed && PipeBottom.IsDisposed)
            Closed?.Invoke(this, EventArgs.Empty);
    }

    private void PipeTop_FormClosed(object? sender, FormClosedEventArgs e)
    {
        PipeTop.FormClosed -= PipeTop_FormClosed;
        PipeTop.Dispose();
        CheckAndRaiseClosed();
    }

    private void PipeBottom_FormClosed(object? sender, FormClosedEventArgs e)
    {
        PipeBottom.FormClosed -= PipeBottom_FormClosed;
        PipeBottom.Dispose();
        CheckAndRaiseClosed();
    }
}
