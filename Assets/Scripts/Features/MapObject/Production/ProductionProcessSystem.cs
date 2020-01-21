namespace Features.MapObject.Production
{
    using Config;
    using Entitas;
    using UnityEngine;

    public class ProductionProcessSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IGroup<GameEntity> _productions;

        public ProductionProcessSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _productions = _gameContext.GetGroup(GameMatcher.Production);
        }

        public void Execute()
        {
            foreach (var productionEntity in _productions)
            {
                var production = productionEntity.production.Value;
                if (production.IsInProduction && productionEntity.isConstructionDone && productionEntity.hasTimeLeft && productionEntity.hasTotalTime)
                {
                    var isConfigAvailable = ConfigHelper.TryGetConfig(production.MapObject, out var config);
                    if (isConfigAvailable)
                    {
                        if (productionEntity.timeLeft.Value > 0)
                        {
                            var timeLeft = productionEntity.timeLeft.Value- Time.deltaTime;
                            productionEntity.ReplaceTimeLeft(timeLeft);
                            productionEntity.ReplaceProductionPercentDone(timeLeft/productionEntity.totalTime.Value);
                        }
                        else
                        {
                            _gameContext.CreateEntity().AddInventoryUpdate(config.ProductionResource, config.ProductionAmount);
                            productionEntity.ReplaceTimeLeft(config.ProductionDuration);
                            productionEntity.ReplaceProductionPercentDone(1);
                            production.IsInProduction = true;
                        }
                    }
                }
            }
        }
    }
}