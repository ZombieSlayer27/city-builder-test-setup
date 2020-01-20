namespace Features.Transactions
{
    using System.Collections.Generic;
    using Entitas;

    public sealed class TransactionMapObjectPlacementValidateSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public TransactionMapObjectPlacementValidateSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionBegin);

        protected override bool Filter(GameEntity entity) => entity.hasGridPosition &&
                                                             entity.isTransaction &&
                                                             !entity.isTransactionDone &&
                                                             !entity.isTransactionSuccess &&
                                                             entity.hasTransactionRequest;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.isTransactionValidate = true;
            }
        }
    }
}