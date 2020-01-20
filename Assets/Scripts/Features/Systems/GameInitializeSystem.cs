namespace Features.Systems
{
    using Grid;
    using Player;

    public sealed class GameInitializeSystem : Feature
    {
        public GameInitializeSystem(Contexts contexts)
        {
            Add(new GridInitializeSystem(contexts));
            Add(new InventoryInitializeSystem(contexts));
        }
    }
}