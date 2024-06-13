
using Flappy_Bird_Windows.Data;

namespace Flappy_Bird_Windows.Repository.Pipe;

public interface IPipeRepository
{
    List<IPipePair> Pipes { get; set; }

    void KillAll();
    IPipePair NewPipePair();
}