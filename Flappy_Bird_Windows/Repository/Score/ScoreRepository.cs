using Flappy_Bird_Windows.Data;
using Flappy_Bird_Windows.Utility;

using Microsoft.Extensions.Logging;

namespace Flappy_Bird_Windows.Repository.Scores;

public sealed class ScoreRepository(ILogger<ScoreRepository> logger) : IScoreRepository
{
    private static readonly string SaveFolder =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Flappy Bird Windows");

    private const string ScoresFile = "scores.csv";
    private const string BestScoresFile = "bestscores.csv";

    public IReadOnlyList<Score> GetAll() => ReadFile(ScoresFile);

    public IReadOnlyList<Score> GetBest() => ReadFile(BestScoresFile);

    public void Save(Score score, int maxEntries) => WriteFile(ScoresFile, score, maxEntries);

    public void SaveBest(Score score, int maxEntries) => WriteFile(BestScoresFile, score, maxEntries);

    private IReadOnlyList<Score> ReadFile(string fileName)
    {
        var path = Path.Combine(SaveFolder, fileName);
        if (!File.Exists(path))
            return [];

        try
        {
            var csv = File.ReadAllText(path);
            return [.. CSVSerializer.Deserialize<Score>(csv)];
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to read score file {File}", fileName);
            return [];
        }
    }

    private void WriteFile(string fileName, Score score, int maxEntries)
    {
        try
        {
            if (!Directory.Exists(SaveFolder))
                Directory.CreateDirectory(SaveFolder);

            var existing = ReadFile(fileName).ToList();
            existing.Insert(0, score);

            if (existing.Count > maxEntries)
                existing.RemoveRange(maxEntries, existing.Count - maxEntries);

            File.WriteAllText(Path.Combine(SaveFolder, fileName), CSVSerializer.Serialize(existing));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to write score file {File}", fileName);
        }
    }
}
