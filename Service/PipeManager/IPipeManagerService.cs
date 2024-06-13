
namespace Flappy_Bird_Windows.Service.PipeManager;

public interface IPipeManagerService
{
    bool HasCollision(Rectangle birdRect);
    bool HasScoreCollision(Rectangle birdRect);
    void MovePipes();
    void NewPipePair();
}