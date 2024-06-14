using Flappy_Bird_Windows.Forms;
using Flappy_Bird_Windows.Utility;

namespace Flappy_Bird_Windows.Repository.Bird;

public sealed class BirdRepository : IBirdRepository
{
    public Dictionary<Color, BirdForm> Birds { get; } = [];

    public BirdForm NewBird() => NewBird(GetRandomColor());

    public BirdForm NewBird(Color color)
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        var bird = new BirdForm(color);
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
        foreach (var bird in Birds.ToArray())
        {
            KillBird(bird.Key);
        }
    }

    private static Color GetRandomColor()
    {
        var random = new Random();
        var colors = Enum.GetValues(typeof(Color));
        var randomColor = (Color)colors.GetValue(random.Next(colors.Length))!;
        return randomColor;
    }
}
