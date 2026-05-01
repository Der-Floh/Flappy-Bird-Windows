using Flappy_Bird_Windows.Forms;
using Flappy_Bird_Windows.Repository.Bird;

using Microsoft.Extensions.Logging;

namespace Flappy_Bird_Windows.Service.BirdManager;

public sealed class BirdManagerService : IBirdManagerService
{
    private bool _controlsEnabled = true;
    public bool ControlsEnabled
    {
        get => _controlsEnabled;
        set
        {
            _controlsEnabled = value;
            if (value)
                EnableControls();
            else
                DisableControls();
        }
    }

    public event EventHandler? GameOver;

    private readonly IBirdRepository _birdRepository;
    private readonly ILogger<BirdManagerService> _logger;

    public BirdManagerService(IBirdRepository birdRepository, ILogger<BirdManagerService> logger)
    {
        _birdRepository = birdRepository;
        _logger = logger;
    }

    public void NewBird(Color color)
    {
        var bird = _birdRepository.NewBird(color);
        bird.FormClosed += Bird_FormClosed;
        bird.Location = new Point(200, 0);
        bird.Show();
    }

    public void NewBird(Color color, Point location)
    {
        var bird = _birdRepository.NewBird(color);
        bird.FormClosed += Bird_FormClosed;
        bird.Location = location;
        bird.Show();
    }

    public void MoveBirds()
    {
        try
        {
            foreach (var bird in _birdRepository.Birds)
                bird.Value.MoveBird();
        }
        catch (ObjectDisposedException ex)
        {
            _logger.LogDebug(ex, "MoveBirds: bird form disposed during iteration");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error in MoveBirds");
        }
    }

    public void CheckKeyPresses()
    {
        try
        {
            foreach (var bird in _birdRepository.Birds)
                bird.Value.CheckKeyPress();
        }
        catch (ObjectDisposedException ex)
        {
            _logger.LogDebug(ex, "CheckKeyPresses: bird form disposed during iteration");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error in CheckKeyPresses");
        }
    }

    public void FlapBird(Color color)
    {
        if (!_birdRepository.Birds.ContainsKey(color))
            NewBird(color);
        _birdRepository.Birds[color].FlapBird();
    }

    private void EnableControls()
    {
        foreach (var bird in _birdRepository.Birds.Values)
            bird.ControlsEnabled = true;
        _controlsEnabled = true;
    }

    private void DisableControls()
    {
        foreach (var bird in _birdRepository.Birds.Values)
            bird.ControlsEnabled = false;
        _controlsEnabled = false;
    }

    private void Bird_FormClosed(object? sender, FormClosedEventArgs e)
    {
        if (sender is not BirdForm bird)
            return;

        bird.FormClosed -= Bird_FormClosed;
        bird.DisposeImages();
        bird.Dispose();
        _birdRepository.Birds.Remove(bird.Color);
        if (_birdRepository.Birds.Count == 0)
            GameOver?.Invoke(this, EventArgs.Empty);
    }
}
