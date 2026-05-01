using Flappy_Bird_Windows.Data;

namespace Flappy_Bird_Windows.Repository.Scores;

public interface IScoreRepository
{
    IReadOnlyList<Score> GetAll();
    IReadOnlyList<Score> GetBest();
    void Save(Score score, int maxEntries);
    void SaveBest(Score score, int maxEntries);
}
