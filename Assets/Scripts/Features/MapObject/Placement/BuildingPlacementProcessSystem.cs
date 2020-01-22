namespace Features.MapObject.Placement
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using Game;
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
                                                              entity.transactionMapObject.MapObject == MapObject.Steel ||
                                                              entity.transactionMapObject.MapObject == MapObject.Residence
                                                             );
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var mapObject = gameEntity.transactionMapObject.MapObject;
                var isConfigAvailable = ConfigHelper.TryGetConfig(mapObject, out var config);
                if (isConfigAvailable)
                {
                    var buildingId = $"{mapObject} {_buildingId++}";
                    var worldPosition = new Vector3(gameEntity.mapObjectPosition.Value.x, 0f,
                        gameEntity.mapObjectPosition.Value.z);
                    MapObjectHelper.SetMapObjectWithIdAt(config, buildingId, worldPosition);
                    _gameContext.CreateProductionEntity(config, buildingId);
                }
            }
        }
    }
}