namespace Features.MapObject.Production
{
    using System.Linq;
    using Entitas;
    using UnityEngine;

    public class SteelProductionSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly ConfigContext _configContext;
        private readonly IGroup<GameEntity> _productions;

        public SteelProductionSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _configContext = contexts.config;
            _productions = _gameContext.GetGroup(GameMatcher.SteelProduction);
        }

        public void Execute()
        {
            foreach (var productionEntity in _productions)
            {
                var production = productionEntity.steelProduction;
                if (production.IsInProduction)
                {
                    var configs = _configContext.gameConfig.value.ProductionData.Config;
                    var steelConfig = configs.SingleOrDefault(x => x.Id == production.Building.ToString());
                    if (steelConfig != null)
                    {
                        if (production.TimeLeft > 0)
                        {
                            production.TimeLeft -= Time.deltaTime;
                            Debug.Log($"Time left for Steel {production.ProductionId} : {production.TimeLeft}");
                        }
                        else
                        {
                            _gameContext.CreateEntity().AddResourceUpdate(steelConfig.ProductionResource,
                                steelConfig.ProductionAmount);

                            production.IsInProduction = false;
                        }
                    }
                }
            }
        }
    }
}