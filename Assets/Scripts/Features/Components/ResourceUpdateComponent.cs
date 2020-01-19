namespace Features.Components
{
    using Config;
    using Entitas;
    using Entitas.CodeGeneration.Attributes;

    [Game, Event(EventTarget.Any)]
    public sealed class ResourceUpdateComponent : IComponent
    {
        public Resource Value;
        public int Amount;
    }
}