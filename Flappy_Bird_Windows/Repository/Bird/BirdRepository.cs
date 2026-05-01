using Flappy_Bird_Windows.Data.Config;
using Flappy_Bird_Windows.Forms;
using Flappy_Bird_Windows.Utility;

using Microsoft.Extensions.Options;

namespace Flappy_Bird_Windows.Repository.Bird;

public sealed class BirdRepository(IOptions<GameplayConfig> gameplayOptions, IOptions<ControlsConfig> controlsOptions, IOptions<ProgramConfig> programOptions) : IBirdRepository
{
    public Dictionary<Color, BirdForm> Birds { get; } = [];

    public BirdForm NewBird() => NewBird(GetRandomColor());

    public BirdForm NewBird(Color color)
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        var bird = new BirdForm(color, gameplayOptions, controlsOptions, programOptions);
        Birds[color] = bird;
        return bird;
    }

    public void KillBird(Color color)
    {
        if (Birds.TryGetValue(color, out var value))
            value.KillBird();
    }

    public void KillAll()
    {
        GetRandomColor();
        foreach (var bird in Birds.ToArray())
        {
            KillBird(bird.Key);
        }
    }

    private static readonly Random _random = new();
    private static readonly KnownColor[] _colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));

    private static Color GetRandomColor() => Color.FromKnownColor(_colors[_random.Next(_colors.Length)]);
}
