namespace Features.Components
{
    using Config;
    using Entitas;

    [Game]
    public sealed class InventoryUpdateComponent: IComponent
    {
        public Resource Resource;
        public int Amount;
    }
}