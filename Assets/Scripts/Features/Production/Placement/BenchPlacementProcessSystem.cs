namespace Features.Production
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using UnityEngine;

    public class BenchPlacementProcessSystem : ReactiveSystem<GameEntity>
    {
        public BenchPlacementProcessSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.DecorationInit);

        protected override bool Filter(GameEntity entity) =>
            entity.hasDecorationInit && entity.decorationInit.value == DecorationBuilding.Bench;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Debug.Log($"{gameEntity.decorationInit.value}");
                gameEntity.isDestroyed = true;
            }
        }
    }
}