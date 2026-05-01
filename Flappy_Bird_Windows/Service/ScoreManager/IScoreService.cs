namespace Flappy_Bird_Windows.Service.ScoreManager;

public interface IScoreService
{
    int BestScore { get; }

    bool RecordScore(int score);
    void LoadBestScore();
}
