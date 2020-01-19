namespace Features.Production
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using UnityEngine;

    public class TreePlacementProcessSystem : ReactiveSystem<GameEntity>
    {
        public TreePlacementProcessSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.DecorationInit);

        protected override bool Filter(GameEntity entity) =>
            entity.hasDecorationInit && entity.decorationInit.value == DecorationBuilding.Tree;

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