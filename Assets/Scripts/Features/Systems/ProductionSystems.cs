namespace Features.Systems
{
    using MapObject.Placement;
    using MapObject.Production;

    public sealed class ProductionSystems : Feature
    {
        public ProductionSystems(Contexts contexts)
        {
            Add(new BuildingPlacementProcessSystem(contexts));
            
            Add(new ProductionStartOnTapSystem(contexts));

            Add(new ConstructionProcessSystem(contexts));
            Add(new ProductionStartSystem(contexts));
            Add(new ProductionProcessSystem(contexts));
        }
    }
}