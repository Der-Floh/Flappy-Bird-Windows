using Microsoft.Extensions.Logging;

namespace Flappy_Bird_Windows.Service.GameState;

public sealed class GameStateService(ILogger<GameStateService> logger) : IGameStateService
{
    private static readonly Dictionary<GameState, HashSet<GameState>> AllowedTransitions = new()
    {
        [GameState.Idle] = [GameState.TapToStart, GameState.Running],
        [GameState.TapToStart] = [GameState.Running, GameState.Idle, GameState.GameOver],
        [GameState.Running] = [GameState.Paused, GameState.GameOver, GameState.Idle],
        [GameState.Paused] = [GameState.Running, GameState.Idle],
        [GameState.GameOver] = [GameState.Idle],
    };

    public GameState CurrentState { get; private set; } = GameState.Idle;

    public event EventHandler<GameState>? StateChanged;

    public void Transition(GameState newState)
    {
        if (!AllowedTransitions.TryGetValue(CurrentState, out var allowed) || !allowed.Contains(newState))
            throw new InvalidOperationException($"Invalid game state transition: {CurrentState} → {newState}");

        logger.LogDebug("Game state: {From} → {To}", CurrentState, newState);
        CurrentState = newState;
        StateChanged?.Invoke(this, newState);
    }
}
