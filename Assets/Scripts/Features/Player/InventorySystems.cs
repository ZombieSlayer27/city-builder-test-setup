namespace Features.Player
{
    public sealed class InventorySystems : Feature
    {
        public InventorySystems(Contexts contexts)
        {
            Add(new InventoryUpdateSystem(contexts));
        }
    }
}