namespace Features.MapObject.Placement
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using UnityEngine;

    public class WoodPlacementProcessSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public WoodPlacementProcessSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionDone);

        protected override bool Filter(GameEntity entity) => entity.isTransactionSuccess &&
                                                             entity.hasTransactionMapObject &&
                                                             entity.transactionMapObject.MapObject == MapObject.Wood;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var isConfigAvailable = ConfigHelper.TryGetConfig(gameEntity.transactionMapObject.MapObject,
                    out var config);

                if (isConfigAvailable)
                {
                    var productionEntity = _gameContext.CreateEntity();
                    var production = new ProductionData
                    {
                        MapObject = config.MapObject,
                        TimeLeft = config.ProductionDuration,
                        IsInProduction = false,
                        IsAuto = config.Auto
                    };
                    productionEntity.AddProduction(production);
                    productionEntity.AddConstruction(config.ProductionDelay);
                    
                    var asset = MapObjectHelper.GetMapObject(config);
                    asset.transform.position = new Vector3(gameEntity.mapObjectPosition.Value.x, 0f, gameEntity.mapObjectPosition.Value.z);
                }
            }
        }
    }
}