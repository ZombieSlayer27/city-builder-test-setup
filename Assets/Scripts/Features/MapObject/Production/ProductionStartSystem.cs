namespace Features.MapObject.Production
{
    using System.Collections.Generic;
    using Config;
    using Entitas;

    public sealed class ProductionStartSystem : ReactiveSystem<GameEntity>
    {
        public ProductionStartSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.ConstructionDone);

        protected override bool Filter(GameEntity entity) => entity.isConstructionDone;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.isConstruction = false;

                if (entity.hasProduction && entity.production.Value.IsAuto)
                {
                    var isConfigAvailable = ConfigHelper.TryGetConfig(entity.production.Value.MapObject,
                        out var config);
                    
                    if (isConfigAvailable)
                    {
                        entity.production.Value.IsInProduction = true;
                        entity.ReplaceTimeLeft(config.ProductionDuration);
                        entity.ReplaceTotalTime(config.ProductionDuration);
                    }
                }
            }
        }
    }
}