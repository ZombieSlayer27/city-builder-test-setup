namespace Features.Input
{
    using System.Collections.Generic;
    using Entitas;
    using MapObject;
    using UnityEngine;

    public sealed class InputProcessSystem : ReactiveSystem<InputEntity>
    {
        public InputProcessSystem(Contexts contexts) : base(contexts.input)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) =>
            context.CreateCollector(InputMatcher.Input);


        protected override bool Filter(InputEntity entity) => entity.hasInput;

        protected override void Execute(List<InputEntity> entities)
        {
            var inputEntity = entities.SingleEntity();
            var input = inputEntity.input;

            //Debug.Log($"world Pos : {input.Value} gridPos:  {MapObjectHelper.ToGridPosition(input.Value)}");
        }
    }
}