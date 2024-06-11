namespace Flappy_Bird_Windows;

public sealed class BirdManager
{
    public Dictionary<Color, Bird> Birds = [];
    public bool ControlsEnabled { get => _controlsEnabled; set { _controlsEnabled = value; SetControlsEnabled(value); } }
    private bool _controlsEnabled = true;
    public event EventHandler? GameOver;

    public void NewBird(Color color)
    {
        ProcessModelId.SetCurrentProcessExplicitAppUserModelID(Guid.NewGuid().ToString());
        var bird = new Bird(color, GetKeyFromColor(color))
        {
            ControlsEnabled = ControlsEnabled
        };
        bird.FormClosed += Bird_FormClosed;
        Birds[color] = bird;
        bird.Show();
    }

    public void MoveBirds()
    {
        try
        {
            foreach (var bird in Birds)
            {
                bird.Value.MoveBird();
            }
        }
        catch { }
    }

    public void CheckKeyPresses()
    {
        try
        {
            foreach (var bird in Birds)
            {
                bird.Value.CheckKeyPress();
            }
        }
        catch { }
    }

    public void FlapBird(Color color)
    {
        if (!Birds.ContainsKey(color))
            NewBird(color);
        Birds[color].FlapBird();
    }

    public void KillBird(Color color)
    {
        if (Birds.TryGetValue(color, out var value))
            value.KillBird();
    }

    public void KillBirds()
    {
        foreach (var bird in Birds.ToArray())
        {
            KillBird(bird.Key);
        }
    }

    public void EnableControl(Color color)
    {
        if (Birds.TryGetValue(color, out var value))
            value.ControlsEnabled = true;
    }

    public void DisableControl(Color color)
    {
        if (Birds.TryGetValue(color, out var value))
            value.ControlsEnabled = false;
    }

    private static Keys GetKeyFromColor(Color color)
    {
        if (color == Color.Yellow)
            return Program.ControlsConfig.Player1;
        else if (color == Color.Blue)
            return Program.ControlsConfig.Player2;
        else if (color == Color.Red)
            return Program.ControlsConfig.Player3;
        return Keys.None;
    }

    private void SetControlsEnabled(bool enabled)
    {
        foreach (var bird in Birds)
        {
            bird.Value.ControlsEnabled = enabled;
        }
    }

    private void Bird_FormClosed(object? sender, FormClosedEventArgs e)
    {
        if (sender is not Bird bird)
            return;

        Birds.Remove(bird.Color);
        if (Birds.Count == 0)
            GameOver?.Invoke(this, EventArgs.Empty);
    }
}
