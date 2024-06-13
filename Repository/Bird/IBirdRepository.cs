using Flappy_Bird_Windows.Forms;

namespace Flappy_Bird_Windows.Repository.Bird;

public interface IBirdRepository
{
    Dictionary<Color, BirdForm> Birds { get; }

    void KillAll();
    void KillBird(Color color);
    BirdForm NewBird();
    BirdForm NewBird(Color color);
}