namespace Flappy_Bird_Windows.Data;

public interface IPipePair
{
    event EventHandler? Closed;

    int GetScoreCalcLocationX();
    bool HasCollision(Rectangle birdRect);
    void Kill();
    void Move();
    void Show();
}