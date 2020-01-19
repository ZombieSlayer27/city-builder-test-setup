namespace Features.Systems
{
    using Production;

    public sealed class ProductionSystems : Feature
    {
        public ProductionSystems(Contexts contexts)
        {
            Add(new ResidencePlacementProcessSystem(contexts));
            Add(new WoodPlacementProcessSystem(contexts));
            Add(new SteelPlacementProcessSystem(contexts));

            Add(new ResidenceProductionSystem(contexts));
            Add(new WoodProductionSystem(contexts));
            Add(new SteelProductionSystem(contexts));
        }
    }
}