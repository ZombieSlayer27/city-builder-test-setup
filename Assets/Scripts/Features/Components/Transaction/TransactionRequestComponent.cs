namespace Features.Components.Transaction
{
    using System.Collections.Generic;
    using Config;
    using Entitas;

    [Game]
    public sealed class TransactionRequestComponent : IComponent
    {
        public List<ResourceData> Resources;
    }
}