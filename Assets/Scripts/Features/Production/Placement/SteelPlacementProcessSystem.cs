namespace Features.Production
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using UnityEngine;

    public class SteelPlacementProcessSystem:ReactiveSystem<GameEntity>
    {
        public SteelPlacementProcessSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.ProductionInit);

        protected override bool Filter(GameEntity entity) =>
            entity.hasProductionInit && entity.productionInit.value == ProductionBuilding.Steel;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Debug.Log($"{gameEntity.productionInit.value}");
                gameEntity.isDestroyed = true;
            }
        }
    }
}