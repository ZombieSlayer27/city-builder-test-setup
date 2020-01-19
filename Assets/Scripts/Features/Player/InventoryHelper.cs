namespace Features.Player
{
    using System.Linq;

    public static class InventoryHelper
    {
        public static bool IsInventoryAvailable(string mapObjectId)
        {
            var gameContext = Contexts.sharedInstance.game;
            var configContext = Contexts.sharedInstance.config;
            if (configContext.hasGameConfig && gameContext.isPlayer &&
                gameContext.playerEntity.hasPlayerInventory)
            {
                var config = configContext.gameConfigEntity.gameConfig.value.Productions.Config;
                var productionConfig = config.SingleOrDefault(x => x.Id.ToString() == mapObjectId);
                var inventory = gameContext.playerEntity.playerInventory.Value.resources;
                if (productionConfig != null)
                {
                    var resourcesRequired = productionConfig.ProductionCostData.Count;
                    foreach (var resourceData in productionConfig.ProductionCostData)
                    {
                        if (inventory.ContainsKey(resourceData.Resource))
                        {
                            if (inventory[resourceData.Resource] >= resourceData.Amount)
                            {
                                resourcesRequired--;
                            }
                        }
                    }

                    return resourcesRequired <= 0;
                }
            }

            return false;
        }
    }
}