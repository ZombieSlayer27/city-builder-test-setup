namespace Features.Game
{
    using Systems;
    using Production;

    public sealed class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new ProductionSystems(contexts));
            Add(new DecorationSystems(contexts));
            Add(new GameCleanupSystems(contexts));
        }
    }
}