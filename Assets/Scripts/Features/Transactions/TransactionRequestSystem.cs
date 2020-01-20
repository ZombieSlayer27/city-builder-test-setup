namespace Features.Transactions
{
    using System.Collections.Generic;
    using Config;
    using Entitas;

    public sealed class TransactionRequestSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public TransactionRequestSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.GridPosition);

        protected override bool Filter(GameEntity entity) => entity.hasMapObjectPlacement && entity.hasGridPosition;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var mapObjectId = gameEntity.mapObjectPlacement.Value;

                if (ConfigHelper.TryGetConfig(mapObjectId, out var config))
                {
                    var transactionEntity = _gameContext.CreateEntity();
                    transactionEntity.isTransaction = true;
                    transactionEntity.isTransactionBegin = true;
                    transactionEntity.AddTransactionMapObject(gameEntity.mapObjectPlacement.Value);
                    transactionEntity.AddTransactionRequest(config.ProductionCostData);
                    transactionEntity.AddGridPosition(gameEntity.gridPosition.Value);
                    transactionEntity.AddMapObjectPosition(gameEntity.mapObjectPosition.Value);
                }
                _gameContext.ReplaceMapObjectPlacement(MapObject.None);
                gameEntity.isDestroyed = true;
            }
        }
    }
}