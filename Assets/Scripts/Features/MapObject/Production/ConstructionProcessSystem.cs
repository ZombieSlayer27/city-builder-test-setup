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

                if (constructionEntity.hasTimeLeft && constructionEntity.hasTotalTime)
                {
                    var timeLeft = constructionEntity.timeLeft.Value;
                    if (timeLeft > 0)
                    {
                        timeLeft -= Time.deltaTime;
                        constructionEntity.ReplaceTimeLeft(timeLeft);
                        constructionEntity.ReplaceConstructionPercentDone(
                            timeLeft / constructionEntity.totalTime.Value);
                    }
                    else
                    {
                        constructionEntity.isConstructionDone = true;
                    }
                }
            }
        }
    }
}