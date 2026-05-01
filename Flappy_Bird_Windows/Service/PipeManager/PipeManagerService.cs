using System.Diagnostics;

using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Repository.Pipe;
using Flappy_Bird_Windows.Service.Performance;

using Microsoft.Extensions.Logging;

namespace Flappy_Bird_Windows.Service.PipeManager;

public sealed class PipeManagerService : IPipeManagerService
{
    private readonly IPipeRepository _pipeRepository;
    private readonly IPerformanceService _perf;
    private readonly ILogger<PipeManagerService> _logger;
    private readonly int _screenHeight;

    public PipeManagerService(IPipeRepository pipeRepository, IPerformanceService perf, ILogger<PipeManagerService> logger)
    {
        _pipeRepository = pipeRepository;
        _perf = perf;
        _logger = logger;
        _screenHeight = Screen.PrimaryScreen!.Bounds.Height;
    }

    public void MovePipes()
    {
        var sw = Stopwatch.StartNew();

        foreach (var pipePair in _pipeRepository.Pipes.ToArray())
            pipePair.Move();

        sw.Stop();
        _perf.RecordMoveTime(sw.Elapsed);
        _perf.PipeCount = _pipeRepository.Pipes.Count;
    }

    public void NewPipePair()
    {
        var pipePair = _pipeRepository.NewPipePair();
        pipePair.Closed += PipePair_Closed;
        pipePair.Show();
    }

    public bool HasCollision(Rectangle birdRect)
    {
        foreach (var pipePair in _pipeRepository.Pipes)
        {
            if (pipePair.HasCollision(birdRect))
                return true;
        }
        return false;
    }

    public bool HasScoreCollision(Rectangle birdRect)
    {
        foreach (var pipePair in _pipeRepository.Pipes)
        {
            if (pipePair.ScoreGiven)
                continue;
            var scoreRect = new Rectangle(pipePair.GetScoreCalcLocationX(), 0, 1, _screenHeight);
            if (birdRect.IntersectsWith(scoreRect))
            {
                pipePair.ScoreGiven = true;
                return true;
            }
        }
        return false;
    }

    private void PipePair_Closed(object? sender, EventArgs e)
    {
        if (sender is not IPipePair pipePair)
            return;

        pipePair.Closed -= PipePair_Closed;
        _pipeRepository.Pipes.Remove(pipePair);
    }
}
