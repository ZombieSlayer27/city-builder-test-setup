namespace Features.Systems
{
    public sealed class GameCleanupSystems : Feature
    {
        public GameCleanupSystems(Contexts contexts)
        {
            Add(new DestroyGameSystem(contexts));
        }
    }
}