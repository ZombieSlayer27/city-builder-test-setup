namespace Features.Game
{
    using Config;
    using UnityEngine;

    public class GameControllerBehaviour : MonoBehaviour
    {
        [SerializeField] private ScriptableGameConfig gameConfig;
        [SerializeField] private ScriptableIconConfig iconConfig;

        private GameController _gameController;

        private void Awake() =>
            _gameController = new GameController(Contexts.sharedInstance, gameConfig, iconConfig);

        private void Start() => _gameController.Initialize();

        private void Update() => _gameController.Execute();
    }
}