using Entitas;
using Features.Config;
using Features.Game;
using Features.Systems;

public class GameController
{
    private readonly Systems _systems;

    public GameController(Contexts contexts, IGameConfig gameConfig, IAssetConfig assetConfig)
    {
        contexts.config.SetGameConfig(gameConfig);
        contexts.config.SetAssetConfig(assetConfig);
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