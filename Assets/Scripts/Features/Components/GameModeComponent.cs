namespace Features.Components
{
    using Config;
    using Entitas;
    using Entitas.CodeGeneration.Attributes;

    [Game, Unique, Event(EventTarget.Any)]
    public sealed class GameModeComponent : IComponent
    {
        public GameMode Value;
    }
}