namespace Features.Systems
{
    using MapObject.Placement;

    public sealed class DecorationSystems : Feature
    {
        public DecorationSystems(Contexts contexts)
        {
            Add(new TreePlacementProcessSystem(contexts));
            Add(new BenchPlacementProcessSystem(contexts));
        }
    }
}