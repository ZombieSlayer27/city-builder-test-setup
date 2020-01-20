namespace Features.Systems
{
    using Input;

    public sealed class CleanupSystems : Feature
    {
        public CleanupSystems(Contexts contexts)
        {
            Add(new DestroyInputSystem(contexts));
            Add(new DestroyGameSystem(contexts));
        }
    }
}