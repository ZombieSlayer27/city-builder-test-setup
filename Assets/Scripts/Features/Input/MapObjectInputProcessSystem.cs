namespace Features.Input
{
    using System.Collections.Generic;
    using Config;
    using Entitas;
    using MapObject;

    public sealed class MapObjectInputProcessSystem : ReactiveSystem<InputEntity>
    {
        private readonly GameContext _gameContext;

        public MapObjectInputProcessSystem(Contexts context) : base(context.input)
        {
            _gameContext = context.game;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) =>
            context.CreateCollector(InputMatcher.Input);

        protected override bool Filter(InputEntity entity) => entity.hasInput;

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                if (_gameContext.hasMapObjectPlacement && _gameContext.mapObjectPlacement.Value != MapObject.None)
                {
                    var mapGridPosition = MapObjectHelper.ToGridPosition(inputEntity.input.Value);
                    _gameContext.mapObjectPlacementEntity.ReplaceGridPosition(mapGridPosition);
                    _gameContext.mapObjectPlacementEntity.ReplaceMapObjectPosition(inputEntity.input.Value);
                }
            }
        }
    }
}