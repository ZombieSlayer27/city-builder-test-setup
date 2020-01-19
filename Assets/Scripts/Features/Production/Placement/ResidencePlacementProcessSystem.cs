namespace Features.Production
{
    using Config;
    using Entitas;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public class ResidencePlacementProcessSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;
        private readonly ConfigContext _configContext;
        private int productionId;
        public ResidencePlacementProcessSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
            _configContext = contexts.config;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.ProductionInit);

        protected override bool Filter(GameEntity entity) =>
            entity.hasProductionInit && entity.productionInit.value == ProductionBuilding.Residence;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Debug.Log($"{gameEntity.productionInit.value}");
                var config = _configContext.gameConfig.value.ProductionData.Config;
                var residenceConfig = config.SingleOrDefault(x => x.Id == ProductionBuilding.Residence.ToString());
                if (residenceConfig != null)
                {
                    var productionEntity = _gameContext.CreateEntity();
                    productionEntity.AddResidenceProduction(true, residenceConfig.ProductionDuration,
                        ProductionBuilding.Residence, "Residence " + productionId);
                    productionId++;
                }

                gameEntity.isDestroyed = true;
            }
        }
    }
}