namespace Features.Transactions
{
    using System.Collections.Generic;
    using Entitas;

    public class TransactionValidateSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public TransactionValidateSystem(Contexts context) : base(context.game)
        {
            _gameContext = context.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.TransactionValidate.Added());

        protected override bool Filter(GameEntity entity) => entity.isTransaction &&
                                                             !entity.isTransactionDone &&
                                                             entity.hasTransactionRequest;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (_gameContext.isPlayer && _gameContext.hasPlayerInventory)
                {
                    var playerInventory = _gameContext.playerEntity.playerInventory.Value.resources;
                    var requiredResources = entity.transactionRequest.Resources;
                    var requiredResourcesAmount = requiredResources.Count;
                    foreach (var resource in requiredResources)
                    {
                        if (playerInventory.ContainsKey(resource.Resource))
                        {
                            if (playerInventory[resource.Resource] >= resource.Amount)
                            {
                                requiredResourcesAmount--;
                            }
                        }
                    }

                    if (requiredResourcesAmount > 0)
                    {
                        entity.isTransactionValidate = true;
                        entity.isTransactionFailed = true;
                    }
                    else
                    {
                        entity.isTransactionValidate = true;
                        entity.isTransactionSuccess = true;
                    }
                }
            }
        }
    }
}