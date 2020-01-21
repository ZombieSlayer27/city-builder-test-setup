namespace Features.MapObject.Placement
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using UI;
    using UI.Building;
    using UnityEngine;

    public class DecorationPlacementProcessSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;
        private int _decorationId;

        public DecorationPlacementProcessSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionDone);

        protected override bool Filter(GameEntity entity) => entity.isTransactionSuccess &&
                                                             entity.hasTransactionMapObject &&
                                                             (entity.transactionMapObject.MapObject ==
                                                              MapObject.Bench ||
                                                              entity.transactionMapObject.MapObject == MapObject.Tree);

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var isConfigAvailable = ConfigHelper.TryGetConfig(gameEntity.transactionMapObject.MapObject,
                    out var config);
                if (isConfigAvailable)
                {
                    var buildingId = $"{gameEntity.transactionMapObject.MapObject} {_decorationId++}";
                    var asset = MapObjectHelper.GetMapObject(config);
                    var buildingDecoration = asset.GetComponent<BuildingBehaviour>();
                    if (buildingDecoration != null)
                    {
                        buildingDecoration.BuildingId = buildingId;
                    }

                    var worldPosition = new Vector3(gameEntity.mapObjectPosition.Value.x, 0f,
                        gameEntity.mapObjectPosition.Value.z);
                    var convertedPosition = new Vector3(worldPosition.x - worldPosition.x % 10, 0,
                        worldPosition.z - worldPosition.z % 10);
                    asset.transform.position = convertedPosition;

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

                    CreateConstructionEntity(config, buildingId);
                }
            }
        }

        private void CreateConstructionEntity(ProductionConfig config, string buildingId)
        {
            var productionEntity = _gameContext.CreateEntity();
            productionEntity.isConstruction = true;
            productionEntity.ReplaceTimeLeft(config.ProductionDelay);
            productionEntity.ReplaceTotalTime(config.ProductionDelay);
            productionEntity.AddBuildingId(buildingId);
        }
    }
}