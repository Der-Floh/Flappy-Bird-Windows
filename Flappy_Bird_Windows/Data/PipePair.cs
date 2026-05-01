using Flappy_Bird_Windows.Forms;
using Flappy_Bird_Windows.Utility;

namespace Flappy_Bird_Windows.Data;

public sealed class PipePair : IPipePair
{
    public event EventHandler? Closed;

    public PipeTopForm? PipeTop
    {
        get;
        set
        {
            if (field is not null && !field.IsDisposed)
                field.Close();
            field = value;
            if (field is not null)
                field.FormClosed += PipeTop_FormClosed;
        }
    }

    public PipeBottomForm? PipeBottom
    {
        get;
        set
        {
            if (field is not null && !field.IsDisposed)
                field.Close();
            field = value;
            if (field is not null)
                field.FormClosed += PipeBottom_FormClosed;
        }
    }

    public bool ScoreGiven { get; set; }

    public void Show()
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        PipeTop?.Show();
        PipeBottom?.Show();
    }

    public void Kill()
    {
        PipeTop?.Close();
        PipeBottom?.Close();
    }

    public void Move()
    {
        PipeTop?.MovePipe();
        PipeBottom?.MovePipe();
    }

    public bool HasCollision(Rectangle birdRect)
    {
        if (PipeTop is not null && !PipeTop.IsDisposed && birdRect.IntersectsWith(PipeTop.Bounds))
            return true;

        if (PipeBottom is not null && !PipeBottom.IsDisposed && birdRect.IntersectsWith(PipeBottom.Bounds))
            return true;

        return false;
    }

    public int GetScoreCalcLocationX()
    {
        if (PipeTop is not null && !PipeTop.IsDisposed)
            return PipeTop.Location.X + (PipeTop.Width / 2);

        if (PipeBottom is not null && !PipeBottom.IsDisposed)
            return PipeBottom.Location.X + (PipeBottom.Width / 2);

        return 0;
    }

    private void CheckAndRaiseClosed()
    {
        if ((PipeTop?.IsDisposed ?? true) && (PipeBottom?.IsDisposed ?? true))
            Closed?.Invoke(this, EventArgs.Empty);
    }

    private void PipeTop_FormClosed(object? sender, FormClosedEventArgs e)
    {
        if (PipeTop is not null)
        {
            PipeTop.FormClosed -= PipeTop_FormClosed;
            PipeTop.BackgroundImage?.Dispose();
            PipeTop.Dispose();
        }
        CheckAndRaiseClosed();
    }

    private void PipeBottom_FormClosed(object? sender, FormClosedEventArgs e)
    {
        if (PipeBottom is not null)
        {
            PipeBottom.FormClosed -= PipeBottom_FormClosed;
            PipeBottom.BackgroundImage?.Dispose();
            PipeBottom.Dispose();
        }
        CheckAndRaiseClosed();
    }
}
