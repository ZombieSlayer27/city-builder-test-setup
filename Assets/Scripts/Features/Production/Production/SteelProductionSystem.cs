namespace Features.Production
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
                if (production.isInProduction)
                {
                    var configs = _configContext.gameConfig.value.ProductionData.Config;
                    var steelConfig = configs.SingleOrDefault(x => x.Id == production.building.ToString());
                    if (steelConfig != null)
                    {
                        if (production.timeLeft > 0)
                        {
                            production.timeLeft -= Time.deltaTime;
                            Debug.Log($"Time left for Steel {production.productionId} : {production.timeLeft}");
                        }
                        else
                        {
                            //Add resource 
                            Debug.Log(
                                $"Add resource : {steelConfig.ProductionResource} Amount {steelConfig.ProductionAmount} ");
                            production.isInProduction = false;
                        }
                    }
                }
            }
        }
    }
}