namespace Features.Game
{
    using Config;

    public static class GameContextExtensions
    {
        public static GameEntity CreateProductionEntity(this GameContext gameContext, ProductionConfig config,
            string buildingId)
        {
            var productionEntity = gameContext.CreateConstructionEntity(config, buildingId);
            var production = new ProductionData
            {
                MapObject = config.MapObject,
                IsInProduction = false,
                IsAuto = config.Auto
            };
            productionEntity.ReplaceProduction(production);
            return productionEntity;
        }

        public static GameEntity CreateConstructionEntity(this GameContext gameContext, ProductionConfig config,
            string buildingId)
        {
            var productionEntity = gameContext.CreateEntity();
            productionEntity.isConstruction = true;
            productionEntity.ReplaceTimeLeft(config.ProductionDelay);
            productionEntity.ReplaceTotalTime(config.ProductionDelay);
            productionEntity.AddBuildingId(buildingId);
            return productionEntity;
        }
    }
}