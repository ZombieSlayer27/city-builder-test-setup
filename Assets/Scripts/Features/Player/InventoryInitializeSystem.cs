namespace Features.Player
{
    using Components;
    using Config;
    using Entitas;

    public class InventoryInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;

        public InventoryInitializeSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Initialize()
        {
            _gameContext.isPlayer = true;
            _gameContext.CreateEntity().AddInventoryUpdate(Resource.Wood, 1000);
            _gameContext.CreateEntity().AddInventoryUpdate(Resource.Steel, 1000);
            _gameContext.CreateEntity().AddInventoryUpdate(Resource.Gold, 1000);
        }
    }
}