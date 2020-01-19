namespace Features.Components
{
    using Config;
    using Entitas;
    using Entitas.CodeGeneration.Attributes;

    [Game]
    public class SteelProductionComponent : IComponent
    {
        public bool isInProduction;
        public float timeLeft;
        public ProductionBuilding building;
        public string productionId;
    }
}