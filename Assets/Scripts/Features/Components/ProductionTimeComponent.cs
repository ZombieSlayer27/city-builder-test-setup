namespace Features.Components
{
    using Entitas;
    using Entitas.CodeGeneration.Attributes;

    [Game]
    public sealed class ProductionTimeComponent : IComponent
    {
        public float TimeLeft;
        public float PercentDone;
    }
}