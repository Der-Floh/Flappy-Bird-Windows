using Flappy_Bird_Windows.Forms;
using Flappy_Bird_Windows.Utility;

namespace Flappy_Bird_Windows.Data;

public sealed class PipePair : IPipePair
{
    public event EventHandler? Closed;

    private readonly PipeTopForm _pipeTop;
    private readonly PipeBottomForm _pipeBottom;

    public PipePair(PipeTopForm pipeTop, PipeBottomForm pipeBottom)
    {
        _pipeTop = pipeTop;
        _pipeBottom = pipeBottom;

        _pipeTop.FormClosed += PipeTop_FormClosed;
        _pipeBottom.FormClosed += PipeBottom_FormClosed;
    }

    public void Show()
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        _pipeTop.Show();
        _pipeBottom.Show();
    }

    public void Kill()
    {
        _pipeTop.Close();
        _pipeBottom.Close();
    }

    public void Move()
    {
        _pipeTop.MovePipe();
        _pipeBottom.MovePipe();
    }

    public bool HasCollision(Rectangle birdRect)
    {
        if (!_pipeTop.IsDisposed && birdRect.IntersectsWith(_pipeTop.Bounds))
            return true;

        if (!_pipeBottom.IsDisposed && birdRect.IntersectsWith(_pipeBottom.Bounds))
            return true;

        return false;
    }

    public int GetScoreCalcLocationX()
    {
        if (!_pipeTop.IsDisposed)
            return _pipeTop.Location.X + _pipeTop.Width / 2;

        if (!_pipeBottom.IsDisposed)
            return _pipeBottom.Location.X + _pipeBottom.Width / 2;

        return 0;
    }

    private void CheckAndRaiseClosed()
    {
        if (_pipeTop.IsDisposed && _pipeBottom.IsDisposed)
            Closed?.Invoke(this, EventArgs.Empty);
    }

    private void PipeTop_FormClosed(object? sender, FormClosedEventArgs e)
    {
        _pipeTop.FormClosed -= PipeTop_FormClosed;
        _pipeTop.BackgroundImage?.Dispose();
        _pipeTop.Dispose();
        CheckAndRaiseClosed();
    }

    private void PipeBottom_FormClosed(object? sender, FormClosedEventArgs e)
    {
        _pipeBottom.FormClosed -= PipeBottom_FormClosed;
        _pipeBottom.BackgroundImage?.Dispose();
        _pipeBottom.Dispose();
        CheckAndRaiseClosed();
    }
}
