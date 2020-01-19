namespace Features.Components
{
    using Config;
    using Entitas;

    [Game]
    public sealed class ProductionInitComponent :IComponent
    {
        public ProductionBuilding value;
    }
}