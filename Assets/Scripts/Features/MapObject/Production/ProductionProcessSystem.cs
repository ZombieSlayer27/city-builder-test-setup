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
                if (production.IsInProduction && productionEntity.isConstructionDone)
                {
                    var isConfigAvailable = ConfigHelper.TryGetConfig(production.MapObject.ToString(), out var config);
                    if (isConfigAvailable)
                    {
                        if (production.TimeLeft > 0)
                        {
                            production.TimeLeft -= Time.deltaTime;
                        }
                        else
                        {
                            _gameContext.CreateEntity().AddInventoryUpdate(config.ProductionResource,
                                config.ProductionAmount);
                            production.TimeLeft = config.ProductionDuration;
                            production.IsInProduction = true;
                        }
                    }
                }
            }
        }
    }
}