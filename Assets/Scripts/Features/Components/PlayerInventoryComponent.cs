namespace Features.Components
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using Entitas.CodeGeneration.Attributes;

    [Game, Unique]
    public sealed class PlayerInventoryComponent : IComponent
    {
        public Inventory Value;
    }

    public sealed class Inventory
    {
        public Dictionary<Resource, int> resources = new Dictionary<Resource, int>();
    }
}