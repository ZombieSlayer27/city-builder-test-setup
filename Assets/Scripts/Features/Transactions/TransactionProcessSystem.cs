namespace Features.Transactions
{
    using System.Collections.Generic;
    using Entitas;

    public sealed class TransactionProcessSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public TransactionProcessSystem(Contexts context) : base(context.game)
        {
            _gameContext = context.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionValidated);

        protected override bool Filter(GameEntity entity) => entity.isTransactionValidated &&
                                                             entity.isTransaction &&
                                                             !entity.isTransactionDone &&
                                                             entity.isTransactionSuccess &&
                                                             entity.hasTransactionRequest;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var requiredResources = entity.transactionRequest.Resources;
                foreach (var requiredResource in requiredResources)
                {
                    var inventoryUpdateEntity = _gameContext.CreateEntity();
                    inventoryUpdateEntity.AddInventoryUpdate(requiredResource.Resource, -requiredResource.Amount);
                }
            }
        }
    }
}