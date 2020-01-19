namespace Features.MapObject.Placement
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using UnityEngine;

    public class ResidencePlacementProcessSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public ResidencePlacementProcessSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionDone);

        protected override bool Filter(GameEntity entity) => entity.isTransactionSuccess &&
                                                             entity.hasTransactionMapObject &&
                                                             entity.transactionMapObject.MapObject ==
                                                             MapObject.Residence;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Debug.Log($"{gameEntity.transactionMapObject.MapObject} purchased");

                gameEntity.isDestroyed = true;
            }
        }
    }
}