namespace Features.Grid
{
    using Entitas;

    public sealed class GridInitializeSystem : IInitializeSystem
    {
        private readonly GameContext _gameContext;
        private readonly ConfigContext _configContext;

        public GridInitializeSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _configContext = contexts.config;
        }

        public void Initialize()
        {
            if (_configContext.hasGameConfig)
            {
                var gridSize = _configContext.gameConfig.value.GridSize;
                _gameContext.ReplaceGrid(new bool[gridSize, gridSize]);
            }
        }
    }
}