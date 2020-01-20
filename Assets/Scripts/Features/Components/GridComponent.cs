namespace Features.Components
{
    using Entitas;
    using Entitas.CodeGeneration.Attributes;

    [Game, Unique]
    public sealed class GridComponent : IComponent
    {
        public bool[,] Value;
    }
}