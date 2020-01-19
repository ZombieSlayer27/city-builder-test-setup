namespace Features.Production
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
                if (production.isInProduction)
                {
                    var configs = _configContext.gameConfig.value.ProductionData.Config;
                    var residenceConfig = configs.SingleOrDefault(x => x.Id == production.building.ToString());
                    if (residenceConfig != null)
                    {
                        if (production.timeLeft > 0)
                        {
                            production.timeLeft -= Time.deltaTime;
                            Debug.Log($"Time left for Residence {production.productionId} : {production.timeLeft}");
                        }
                        else
                        {
                            //Add resource 
                            Debug.Log(
                                $"Add resource : {residenceConfig.ProductionResource} Amount {residenceConfig.ProductionAmount} ");
                            production.isInProduction = false;
                        }
                    }
                }
            }
        }
    }
}