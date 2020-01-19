namespace Features.Production
{
    using System.Linq;
    using Entitas;
    using UnityEngine;

    public class WoodProductionSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly ConfigContext _configContext;
        private readonly IGroup<GameEntity> _productions;

        public WoodProductionSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _configContext = contexts.config;
            _productions = _gameContext.GetGroup(GameMatcher.WoodProduction);
        }

        public void Execute()
        {
            foreach (var productionEntity in _productions)
            {
                var production = productionEntity.woodProduction;
                if (production.isInProduction)
                {
                    var configs = _configContext.gameConfig.value.ProductionData.Config;
                    var woodConfig = configs.SingleOrDefault(x => x.Id == production.building.ToString());
                    if (woodConfig != null)
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
                                $"Add resource {production.productionId}: {woodConfig.ProductionResource} Amount {woodConfig.ProductionAmount} ");
                            production.isInProduction = false;
                        }
                    }
                }
            }
        }
    }
}