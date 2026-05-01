namespace Flappy_Bird_Windows.Service.GameState;

public interface IGameStateService
{
    GameState CurrentState { get; }

    void Transition(GameState newState);

    event EventHandler<GameState>? StateChanged;
}
