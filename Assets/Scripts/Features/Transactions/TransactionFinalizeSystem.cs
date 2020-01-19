namespace Features.Transactions
{
    using System.Collections.Generic;
    using Entitas;

    public sealed class TransactionFinalizeSystem : ReactiveSystem<GameEntity>
    {
        public TransactionFinalizeSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionSuccess.Added(),
                GameMatcher.TransactionFailed.Added());

        protected override bool Filter(GameEntity entity) => entity.isTransaction &&
                                                             entity.isTransactionValidated &&
                                                             (entity.isTransactionSuccess ||
                                                              entity.isTransactionFailed);

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.isTransactionDone = true;
                entity.isDestroyed = true;
            }
        }
    }
}