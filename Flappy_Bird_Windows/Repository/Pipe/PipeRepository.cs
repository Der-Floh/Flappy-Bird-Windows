using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Data.Config;
using Flappy_Bird_Windows.Forms;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Repository.Pipe;

public sealed class PipeRepository : IPipeRepository
{
    public List<IPipePair> Pipes { get; set; } = [];

    private readonly GameplayConfig _config;
    private readonly ProgramConfig _programConfig;
    private readonly IServiceProvider _serviceProvider;
    private readonly int _screenHeight;
    private readonly int _screenWidth;
    private readonly Random _random;

    private int _lastGapY;

    public PipeRepository(IOptions<GameplayConfig> gameplayOptions, IOptions<ProgramConfig> programOptions, IServiceProvider serviceProvider)
    {
        _config = gameplayOptions.Value;
        _programConfig = programOptions.Value;
        _serviceProvider = serviceProvider;
        _screenHeight = Screen.PrimaryScreen!.Bounds.Height;
        _screenWidth = Screen.PrimaryScreen!.Bounds.Width;
        _random = new Random();
        _lastGapY = _random.Next(_screenHeight / 2);
    }

    public IPipePair NewPipePair()
    {
        var gap = _random.Next(_config.PipeGapMin, _config.PipeGapMax);
        var pipeTopHeight = CalcPipeTopHeight(gap);
        var pipeBottomHeight = _screenHeight - gap - pipeTopHeight;
        _lastGapY = pipeTopHeight;

        var pipeTopForm = new PipeTopForm(_programConfig.AlwaysOnTop, _config.PipeMoveSpeed, _config.PipeDespawnOffset);
        pipeTopForm.Size = new Size(pipeTopForm.Width, pipeTopHeight);
        pipeTopForm.Location = new Point(_screenWidth - pipeTopForm.Width + _config.PipeSpawnOffset, 0);

        var pipeBottomForm = new PipeBottomForm(_programConfig.AlwaysOnTop, _config.PipeMoveSpeed, _config.PipeDespawnOffset);
        pipeBottomForm.Size = new Size(pipeBottomForm.Width, pipeBottomHeight);
        pipeBottomForm.Location = new Point(_screenWidth - pipeBottomForm.Width + _config.PipeSpawnOffset, _screenHeight - pipeBottomHeight);

        var pipePair = _serviceProvider.GetRequiredService<IPipePair>();
        pipePair.PipeTop = pipeTopForm;
        pipePair.PipeBottom = pipeBottomForm;
        Pipes.Add(pipePair);
        return pipePair;
    }

    private int CalcPipeTopHeight(int gap)
    {
        var pipeScreenDistanceMin = _config.PipeScreenDistanceMin;
        var isMoreTop = false;
        if (_lastGapY == _screenHeight - gap - (pipeScreenDistanceMin * 2))
            isMoreTop = true;
        else if (_lastGapY != pipeScreenDistanceMin)
            isMoreTop = _random.Next(2) == 0;

        int minPipeTopHeight, maxPipeTopHeight;

        if (isMoreTop)
        {
            minPipeTopHeight = _lastGapY - _config.PipeGapShiftMax;
            maxPipeTopHeight = _lastGapY - _config.PipeGapShiftMin;
        }
        else
        {
            minPipeTopHeight = _lastGapY + _config.PipeGapShiftMin;
            maxPipeTopHeight = _lastGapY + _config.PipeGapShiftMax;
        }

        var pipeScreenDistanceMax = _screenHeight - gap - (pipeScreenDistanceMin * 2);
        if (pipeScreenDistanceMin > pipeScreenDistanceMax)
            pipeScreenDistanceMax = pipeScreenDistanceMin;

        minPipeTopHeight = Math.Clamp(minPipeTopHeight, pipeScreenDistanceMin, pipeScreenDistanceMax);
        maxPipeTopHeight = Math.Clamp(maxPipeTopHeight, pipeScreenDistanceMin, pipeScreenDistanceMax);

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
