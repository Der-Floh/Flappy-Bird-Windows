using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Flappy_Bird_Windows.Repository.Pipe;

public sealed class PipeRepository : IPipeRepository
{
    public List<IPipePair> Pipes { get; set; } = [];

    private readonly int _screenHeight;
    private readonly int _screenWidth;
    private readonly Random _random = new Random();

    private int _lastGapY;

    public PipeRepository()
    {
        _screenHeight = Screen.PrimaryScreen!.Bounds.Height;
        _screenWidth = Screen.PrimaryScreen!.Bounds.Width;
        _lastGapY = _random.Next(_screenHeight / 3);
    }

    public IPipePair NewPipePair()
    {
        var gap = _random.Next(Program.GameplayConfig.PipeGapMin, Program.GameplayConfig.PipeGapMax);
        var pipeTopHeight = Math.Clamp(_random.Next(_lastGapY - Program.GameplayConfig.PipeGapShift, _lastGapY + Program.GameplayConfig.PipeGapShift), 50, _screenHeight - gap - 100);
        var pipeBottomHeight = _screenHeight - gap - pipeTopHeight;
        _lastGapY = pipeTopHeight;

        var pipeTopForm = new PipeTopForm();
        pipeTopForm.Size = new Size(pipeTopForm.Width, pipeTopHeight);
        pipeTopForm.Location = new Point(_screenWidth - pipeTopForm.Width + Program.GameplayConfig.PipeSpawnOffset, 0);

        var pipeBottomForm = new PipeBottomForm();
        pipeBottomForm.Size = new Size(pipeBottomForm.Width, pipeBottomHeight);
        pipeBottomForm.Location = new Point(_screenWidth - pipeBottomForm.Width + Program.GameplayConfig.PipeSpawnOffset, _screenHeight - pipeBottomHeight);

        var pipePair = Program.Services!.GetRequiredService<IPipePair>();
        pipePair.PipeTop = pipeTopForm;
        pipePair.PipeBottom = pipeBottomForm;
        Pipes.Add(pipePair);
        return pipePair;
    }

    public void KillAll()
    {
        foreach (var pipePair in Pipes.ToArray())
        {
            pipePair.Kill();
        }
    }
}
