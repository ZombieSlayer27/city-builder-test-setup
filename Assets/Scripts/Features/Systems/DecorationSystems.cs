namespace Features.Systems
{
    using Production;

    public sealed class DecorationSystems : Feature
    {
        public DecorationSystems(Contexts contexts)
        {
            Add(new TreePlacementProcessSystem(contexts));
            Add(new BenchPlacementProcessSystem(contexts));
        }
    }
}