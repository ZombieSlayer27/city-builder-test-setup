namespace Features.Components
{
    using Entitas;
    using Entitas.CodeGeneration.Attributes;

    [Game, Event(EventTarget.Any)]
    public sealed class ProductionPercentDoneComponent : IComponent
    {
        public float Value;
    }
}