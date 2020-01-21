namespace Features.Transactions
{
    using System;
    using System.Collections.Generic;
    using Config;
    using Entitas;

    public sealed class TransactionMapObjectPlacementValidateSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;
        private readonly ConfigContext _configContext;

        public TransactionMapObjectPlacementValidateSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
            _configContext = contexts.config;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionBegin);

        protected override bool Filter(GameEntity entity) => entity.hasGridPosition &&
                                                             entity.isTransaction &&
                                                             !entity.isTransactionDone &&
                                                             !entity.isTransactionSuccess &&
                                                             entity.hasTransactionRequest;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var gridSize = _configContext.gameConfig.value.GridSize;
                if (ConfigHelper.TryGetConfig(entity.transactionMapObject.MapObject, out var config))
                {
                    var objectSize = config.MapObjectSize;
                    var gridPosition = entity.gridPosition.Value;
                    if (gridPosition.x + objectSize.x <= gridSize && gridPosition.x + objectSize.x >= 0 &&
                        gridPosition.y + objectSize.y <= gridSize && gridPosition.y + objectSize.y >= 0)
                    {
                        var grids = _gameContext.grid.Value;

                        for (int i = 0; i < objectSize.x; i++)
                        {
                            for (int j = 0; j < objectSize.y; j++)
                            {
                                if (grids[gridPosition.x + i, gridPosition.y + j])
                                {
                                    entity.isTransactionFailed = true;
                                    return;
                                }
                            }
                        }

                        entity.isTransactionValidate = true;
                    }
                    else
                    {
                        entity.isTransactionFailed = true;
                    }
                }
            }
        }
    }
}