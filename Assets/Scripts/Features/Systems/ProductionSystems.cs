namespace Features.Systems
{
    using MapObject.Placement;
    using MapObject.Production;

    public sealed class ProductionSystems : Feature
    {
        public ProductionSystems(Contexts contexts)
        {
            Add(new ResidencePlacementProcessSystem(contexts));
            Add(new WoodPlacementProcessSystem(contexts));
            Add(new SteelPlacementProcessSystem(contexts));

            Add(new ConstructionProcessSystem(contexts));
            Add(new ProductionStartSystem(contexts));
            Add(new ProductionProcessSystem(contexts));
        }
    }
}