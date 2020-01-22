namespace Features.Grid
{
    using System.Collections.Generic;
    using Config;
    using Entitas;

    public sealed class GridUpdateSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public GridUpdateSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionDone);

        protected override bool Filter(GameEntity entity) => entity.isTransactionSuccess &&
                                                             entity.hasTransactionMapObject;


        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var isConfigAvailable = ConfigHelper.TryGetConfig(gameEntity.transactionMapObject.MapObject,
                    out var config);
                if (isConfigAvailable)
                {
                    var grids = _gameContext.grid.Value;
                    var assetSize = config.MapObjectSize;
                    var objectGridPosition = gameEntity.gridPosition.Value;

                    for (int i = 0; i < assetSize.x; i++)
                    {
                        for (int j = 0; j < assetSize.y; j++)
                        {
                            grids[objectGridPosition.x + i, objectGridPosition.y + j] = true;
                        }
                    }
                }
            }
        }
    }
}