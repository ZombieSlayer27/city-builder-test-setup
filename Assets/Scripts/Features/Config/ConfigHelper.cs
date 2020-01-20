namespace Features.Config
{
    using System.Linq;

    public static class ConfigHelper
    {
        public static bool TryGetConfig(MapObject id, out ProductionConfig productionConfig)
        {
            productionConfig = null;

            var configContext = Contexts.sharedInstance.config;
            if (configContext.hasGameConfig)
            {
                var config = configContext.gameConfigEntity.gameConfig.value.Productions.Config;
                productionConfig = config.SingleOrDefault(x => x.MapObject == id);
                if (productionConfig != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}