using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Repository.Pipe;

namespace Flappy_Bird_Windows.Service.PipeManager;

public sealed class PipeManagerService : IPipeManagerService
{
    private readonly IPipeRepository _pipeRepository;
    private readonly int _screenHeight;

    public PipeManagerService(IPipeRepository pipeRepository)
    {
        _pipeRepository = pipeRepository;
        _screenHeight = Screen.PrimaryScreen!.Bounds.Height;
    }

    public void MovePipes()
    {
        foreach (var pipePair in _pipeRepository.Pipes.ToArray())
        {
            pipePair.Move();
        }
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
