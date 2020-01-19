namespace Features.Components
{
    using Config;
    using Entitas;

    [Game]
    public sealed class ProductionComponent : IComponent
    {
        public ProductionData Value;
    }
}