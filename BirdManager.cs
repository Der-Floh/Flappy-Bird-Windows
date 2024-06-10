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
        var bird = new Bird(color);
        bird.ControlsEnabled = ControlsEnabled;
        bird.FormClosed += Bird_FormClosed;
        Birds[color] = bird;
        bird.Show();
    }

    public void MoveBirds()
    {
        foreach (var bird in Birds)
        {
            bird.Value.MoveBird();
        }
    }

    public void CheckKeyPresses()
    {
        foreach (var bird in Birds)
        {
            bird.Value.CheckKeyPress();
        }
    }

    public void FlapBird(Color color)
    {
        if (!Birds.ContainsKey(color))
            NewBird(color);
        Birds[color].FlapBird();
    }

    public void KillBird(Color color)
    {
        if (Birds.ContainsKey(color))
            Birds[color].KillBird();
    }

    public void KillBirds()
    {
        foreach (var bird in Birds)
        {
            KillBird(bird.Key);
        }
    }

    public void EnableControl(Color color)
    {
        if (Birds.ContainsKey(color))
            Birds[color].ControlsEnabled = true;
    }

    public void DisableControl(Color color)
    {
        if (Birds.ContainsKey(color))
            Birds[color].ControlsEnabled = false;
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
        var bird = sender as Bird;
        if (bird is null)
            return;

        Birds.Remove(bird.Color);
        if (Birds.Count == 0)
            GameOver?.Invoke(this, EventArgs.Empty);
    }
}
