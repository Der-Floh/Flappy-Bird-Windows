namespace Flappy_Bird_Windows;

public sealed class PipePair
{
    public PipeTop PipeTop { get; private set; }
    public bool PipeTopClosed { get; private set; }
    public PipeBottom PipeBottom { get; private set; }
    public bool PipeBottomClosed { get; private set; }
    public event EventHandler? Closed;

    public PipePair(PipeTop pipeTop, PipeBottom pipeBottom)
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        PipeTop = pipeTop;
        PipeTop.FormClosed += PipeTop_FormClosed;
        PipeBottom = pipeBottom;
        PipeBottom.FormClosed += PipeBottom_FormClosed;
    }

    private void PipeTop_FormClosed(object? sender, FormClosedEventArgs e)
    {
        PipeTopClosed = true;
        if (PipeBottomClosed)
            Closed?.Invoke(this, EventArgs.Empty);
    }
    private void PipeBottom_FormClosed(object? sender, FormClosedEventArgs e)
    {
        PipeBottomClosed = true;
        if (PipeTopClosed)
            Closed?.Invoke(this, EventArgs.Empty);
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

    public void MovePipes()
    {
        PipeTop.MovePipe();
        PipeBottom.MovePipe();
    }
}
