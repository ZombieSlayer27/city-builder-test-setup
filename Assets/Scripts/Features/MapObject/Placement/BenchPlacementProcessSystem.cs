namespace Features.MapObject.Placement
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using UnityEditor;
    using UnityEngine;

    public class BenchPlacementProcessSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;
        private readonly ConfigContext _configContext;

        public BenchPlacementProcessSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
            _configContext = contexts.config;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionDone);

        protected override bool Filter(GameEntity entity) => entity.isTransactionSuccess &&
                                                             entity.hasTransactionMapObject &&
                                                             entity.transactionMapObject.MapObject == MapObject.Bench;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Debug.Log($"{gameEntity.transactionMapObject.MapObject} purchased");
                var isConfigAvailable = ConfigHelper.TryGetConfig(gameEntity.transactionMapObject.MapObject,
                    out var config);
                if (isConfigAvailable)
                {
                    var asset = MapObjectHelper.GetMapObject(config);
                    asset.transform.position = new Vector3(gameEntity.mapObjectPosition.Value.x, 0f,
                        gameEntity.mapObjectPosition.Value.z);
                }
            }
        }
    }
}