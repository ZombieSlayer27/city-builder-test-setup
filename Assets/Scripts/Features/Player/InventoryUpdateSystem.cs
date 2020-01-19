namespace Features.Player
{
    using System.Collections.Generic;
    using Components;
    using Entitas;

    public sealed class InventoryUpdateSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public InventoryUpdateSystem(Contexts context) : base(context.game)
        {
            _gameContext = context.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.InventoryUpdate);

        protected override bool Filter(GameEntity entity) => entity.hasInventoryUpdate;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (_gameContext.isPlayer)
                {
                    if (_gameContext.playerEntity.hasPlayerInventory)
                    {
                        var playerInventory = _gameContext.playerEntity.playerInventory.Value.resources;
                        if (playerInventory.ContainsKey(entity.inventoryUpdate.Resource))
                        {
                            playerInventory[entity.inventoryUpdate.Resource] += entity.inventoryUpdate.Amount;
                        }
                        else
                        {
                            playerInventory.Add(entity.inventoryUpdate.Resource, entity.inventoryUpdate.Amount);
                        }
                    }
                    else
                    {
                        var inventory = new Inventory();
                        inventory.resources.Add(entity.inventoryUpdate.Resource, entity.inventoryUpdate.Amount);

                        _gameContext.playerEntity.AddPlayerInventory(inventory);
                    }

                    var updatedInventory = _gameContext.playerEntity.playerInventory.Value.resources;
                    var resourceUpdated = entity.inventoryUpdate.Resource;
                    
                    _gameContext.CreateEntity().AddResourceUpdate(resourceUpdated, updatedInventory[resourceUpdated]);
                }

                entity.isDestroyed = true;
            }
        }
    }
}