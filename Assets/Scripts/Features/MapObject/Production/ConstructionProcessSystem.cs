namespace Features.MapObject.Production
{
    using Entitas;
    using UnityEngine;

    public sealed class ConstructionProcessSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _constructions;

        public ConstructionProcessSystem(Contexts contexts)
        {
            _constructions = contexts.game.GetGroup(GameMatcher.Construction);
        }

        public void Execute()
        {
            foreach (var constructionEntity in _constructions)
            {
                if (constructionEntity.isConstructionDone)
                {
                    continue;
                }

                var timeLeft = constructionEntity.construction.TimeLeft;
                if (timeLeft > 0)
                {
                    timeLeft -= Time.deltaTime;
                    constructionEntity.ReplaceConstruction(timeLeft);
                }
                else
                {
                    constructionEntity.isConstructionDone = true;
                }
            }
        }
    }
}