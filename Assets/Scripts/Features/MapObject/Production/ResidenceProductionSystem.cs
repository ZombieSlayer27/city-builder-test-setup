namespace Features.MapObject.Production
{
    using System.Linq;
    using Entitas;
    using UnityEngine;

    public class ResidenceProductionSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly ConfigContext _configContext;
        private readonly IGroup<GameEntity> _productions;

        public ResidenceProductionSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _configContext = contexts.config;
            _productions = _gameContext.GetGroup(GameMatcher.ResidenceProduction);
        }

        public void Execute()
        {
            foreach (var productionEntity in _productions)
            {
                var production = productionEntity.residenceProduction;
                if (production.IsInProduction)
                {
                    var configs = _configContext.gameConfig.value.ProductionData.Config;
                    var residenceConfig = configs.SingleOrDefault(x => x.Id == production.Building.ToString());
                    if (residenceConfig != null)
                    {
                        if (production.TimeLeft > 0)
                        {
                            production.TimeLeft -= Time.deltaTime;
                        }
                        else
                        {
                            _gameContext.CreateEntity().AddInventoryUpdate(residenceConfig.ProductionResource,residenceConfig.ProductionAmount);
                            
                            production.IsInProduction = false;
                        }
                    }
                }
            }
        }
    }
}