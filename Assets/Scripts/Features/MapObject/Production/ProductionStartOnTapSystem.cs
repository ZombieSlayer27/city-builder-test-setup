namespace Features.MapObject.Production
{
    using System.Collections.Generic;
    using System.Linq;
    using Entitas;
    using UI.Building;

    public sealed class ProductionStartOnTapSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public ProductionStartOnTapSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TapOnBuilding);

        protected override bool Filter(GameEntity entity) => entity.hasTapOnBuilding;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var buildingBehaviour = gameEntity.tapOnBuilding.Value.GetComponent<BuildingBehaviour>();
                if (buildingBehaviour != null)
                {
                    buildingBehaviour.ShowProgress();
                }

                var buildingId = buildingBehaviour.BuildingId;
                var entityWithBuildingId = _gameContext
                    .GetEntities(GameMatcher.Production)
                    .SingleOrDefault(x => x.hasBuildingId && x.buildingId.Value == buildingId);
                if (entityWithBuildingId != null)
                {
                    entityWithBuildingId.production.Value.IsInProduction = true;
                }
            }
        }
    }
}