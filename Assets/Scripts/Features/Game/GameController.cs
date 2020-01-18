using Entitas;
using Features.Config;
using Features.Game;

public class GameController
{
    private readonly Systems _systems;

    public GameController(Contexts contexts, IGameConfig gameConfig)
    {
        contexts.config.SetGameConfig(gameConfig);
        _systems = new GameSystems(contexts);
    }

    public void Initialize()
    {
        _systems.Initialize();
    }

    public void Execute()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}