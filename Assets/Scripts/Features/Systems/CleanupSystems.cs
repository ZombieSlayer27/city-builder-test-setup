namespace Features.Systems
{
    using Input;
    using Player;

    public sealed class CleanupSystems : Feature
    {
        public CleanupSystems(Contexts contexts)
        {
            Add(new DestroyInputSystem(contexts));
            Add(new DestroyGameSystem(contexts));
            Add(new InventoryCleanupSystem(contexts));
        }
    }
}