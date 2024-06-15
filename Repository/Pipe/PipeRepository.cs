using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Flappy_Bird_Windows.Repository.Pipe;

public sealed class PipeRepository : IPipeRepository
{
    public List<IPipePair> Pipes { get; set; } = [];

    private readonly int _screenHeight;
    private readonly int _screenWidth;
    private readonly int _pipeScreenDistanceMin;
    private readonly Random _random;

    private int _lastGapY;

    public PipeRepository()
    {
        _screenHeight = Screen.PrimaryScreen!.Bounds.Height;
        _screenWidth = Screen.PrimaryScreen!.Bounds.Width;
        _pipeScreenDistanceMin = Program.GameplayConfig.PipeScreenDistanceMin;
        _random = new Random();
        _lastGapY = _random.Next(_screenHeight / 3);
    }

    public IPipePair NewPipePair()
    {
        var gap = _random.Next(Program.GameplayConfig.PipeGapMin, Program.GameplayConfig.PipeGapMax);
        var pipeTopHeight = CalcPipeTopHeight(gap);
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

    private int CalcPipeTopHeight(int gap)
    {
        var isMoreTop = false;
        if (_lastGapY == _screenHeight - gap - _pipeScreenDistanceMin * 2)
            isMoreTop = true;
        else if (_lastGapY != _pipeScreenDistanceMin)
            isMoreTop = _random.Next(2) == 0;

        int minPipeTopHeight, maxPipeTopHeight;

        if (isMoreTop)
        {
            minPipeTopHeight = _lastGapY - Program.GameplayConfig.PipeGapShiftMax;
            maxPipeTopHeight = _lastGapY - Program.GameplayConfig.PipeGapShiftMin;
        }
        else
        {
            minPipeTopHeight = _lastGapY + Program.GameplayConfig.PipeGapShiftMin;
            maxPipeTopHeight = _lastGapY + Program.GameplayConfig.PipeGapShiftMax;
        }

        minPipeTopHeight = Math.Clamp(minPipeTopHeight, _pipeScreenDistanceMin, _screenHeight - gap - _pipeScreenDistanceMin * 2);
        maxPipeTopHeight = Math.Clamp(maxPipeTopHeight, _pipeScreenDistanceMin, _screenHeight - gap - _pipeScreenDistanceMin * 2);

        return _random.Next(minPipeTopHeight, maxPipeTopHeight);
    }

    public void KillAll()
    {
        foreach (var pipePair in Pipes.ToArray())
        {
            pipePair.Kill();
        }
    }
}
