namespace Features.MapObject.Production
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
                if (production.IsInProduction)
                {
                    var configs = _configContext.gameConfig.value.ProductionData.Config;
                    var woodConfig = configs.SingleOrDefault(x => x.Id == production.Building.ToString());
                    if (woodConfig != null)
                    {
                        if (production.TimeLeft > 0)
                        {
                            production.TimeLeft -= Time.deltaTime;
                            Debug.Log($"Time left for Steel {production.ProductionId} : {production.TimeLeft}");
                        }
                        else
                        {
                            _gameContext.CreateEntity().AddResourceUpdate(woodConfig.ProductionResource,
                                woodConfig.ProductionAmount);

                            production.IsInProduction = false;
                        }
                    }
                }
            }
        }
    }
}