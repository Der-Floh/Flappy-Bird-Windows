
namespace Flappy_Bird_Windows.Service.BirdManager;

public interface IBirdManagerService
{
    bool ControlsEnabled { get; set; }

    event EventHandler? GameOver;

    void CheckKeyPresses();
    void FlapBird(Color color);
    void MoveBirds();
    void NewBird(Color color);
}