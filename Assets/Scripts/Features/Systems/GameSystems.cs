namespace Features.Systems
{
    using Input;
    using Player;
    using Transactions;

    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new GameInitializeSystem(contexts));
            Add(new InputSystems(contexts));
            Add(new TransactionSystems(contexts));
            Add(new InventorySystems(contexts));
            Add(new ProductionSystems(contexts));
            Add(new DecorationSystems(contexts));
            Add(new GameEventSystems(contexts));
            Add(new CleanupSystems(contexts));
        }
    }
}