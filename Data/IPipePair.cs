using Flappy_Bird_Windows.Forms;

namespace Flappy_Bird_Windows.Data;

public interface IPipePair
{
    PipeTopForm? PipeTop { get; set; }
    PipeBottomForm? PipeBottom { get; set; }
    event EventHandler? Closed;

    int GetScoreCalcLocationX();
    bool HasCollision(Rectangle birdRect);
    void Kill();
    void Move();
    void Show();
}