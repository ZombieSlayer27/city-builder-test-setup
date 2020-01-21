namespace Features.MapObject.Placement
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using UI.Building;
    using UnityEngine;

    public class BuildingPlacementProcessSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;
        private int _buildingId;

        public BuildingPlacementProcessSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionDone);

        protected override bool Filter(GameEntity entity) => entity.isTransactionSuccess &&
                                                             entity.hasTransactionMapObject &&
                                                             (entity.transactionMapObject.MapObject == MapObject.Wood ||
                                                              entity.transactionMapObject.MapObject ==
                                                              MapObject.Steel ||
                                                              entity.transactionMapObject.MapObject ==
                                                              MapObject.Residence
                                                             );

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var isConfigAvailable = ConfigHelper.TryGetConfig(gameEntity.transactionMapObject.MapObject,
                    out var config);
                if (isConfigAvailable)
                {
                    var buildingId = $"{config.MapObject} {_buildingId++}";
                    var asset = MapObjectHelper.GetMapObject(config);
                    var buildingBehaviour = asset.GetComponent<BuildingBehaviour>();
                    if (buildingBehaviour != null)
                    {
                        buildingBehaviour.BuildingId = buildingId;
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

                    CreateProductionEntity(config, buildingId);
                }
            }
        }

        private void CreateProductionEntity(ProductionConfig config, string buildingId)
        {
            var productionEntity = _gameContext.CreateEntity();
            var production = new ProductionData
            {
                MapObject = config.MapObject,
                IsInProduction = false,
                IsAuto = config.Auto
            };
            productionEntity.isConstruction = true;
            productionEntity.ReplaceProduction(production);
            productionEntity.ReplaceTimeLeft(config.ProductionDelay);
            productionEntity.ReplaceTotalTime(config.ProductionDelay);
            productionEntity.AddBuildingId(buildingId);
        }
    }
}