namespace Features.Player
{
    using System.Collections.Generic;
    using Entitas;

    public sealed class InventoryCleanupSystem : ICleanupSystem
    {
        readonly IGroup<GameEntity> _group;
        readonly List<GameEntity> _buffer = new List<GameEntity>();

        public InventoryCleanupSystem(Contexts contexts)
        {
            _group = contexts.game.GetGroup(GameMatcher.ResourceUpdate);
        }

        public void Cleanup()
        {
            foreach (var e in _group.GetEntities(_buffer))
            {
                e.Destroy();
            }
        }
    }
}