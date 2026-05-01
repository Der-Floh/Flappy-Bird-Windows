using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Data.Config;
using Flappy_Bird_Windows.Repository.Scores;

using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Service.ScoreManager;

public sealed class ScoreService(IScoreRepository scoreRepository, IOptions<ProgramConfig> programOptions) : IScoreService
{
    public int BestScore { get; private set; }

    public bool RecordScore(int score)
    {
        var config = programOptions.Value;
        var isNewBest = score > BestScore;

        if (config.SaveScore && score != 0)
        {
            var entry = new Score
            {
                Username = Environment.UserName,
                ScoreValue = score,
                Time = DateTime.Now,
            };
            scoreRepository.Save(entry, config.SavedScoresMax);
        }

        if (isNewBest)
        {
            BestScore = score;
            if (config.SaveScore)
            {
                var bestEntry = new Score
                {
                    Username = Environment.UserName,
                    ScoreValue = BestScore,
                    Time = DateTime.Now,
                };
                scoreRepository.SaveBest(bestEntry, config.SavedScoresMax);
            }
        }

        return isNewBest;
    }

    public void LoadBestScore()
    {
        var scores = scoreRepository.GetBest();
        BestScore = scores.Count > 0
            ? scores.OrderByDescending(x => x.ScoreValue).First().ScoreValue
            : 0;
    }
}
