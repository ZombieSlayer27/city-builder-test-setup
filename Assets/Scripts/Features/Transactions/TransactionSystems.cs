namespace Features.Transactions
{
    public sealed class TransactionSystems : Feature
    {
        public TransactionSystems(Contexts contexts)
        {
            Add(new TransactionRequestSystem(contexts));
            Add(new TransactionMapObjectPlacementValidateSystem(contexts));
            Add(new TransactionValidateSystem(contexts));
            Add(new TransactionProcessSystem(contexts));
            Add(new TransactionFinalizeSystem(contexts));
        }
    }
}