namespace Features.Game
{
    using Config;
    using UnityEngine;

    public class GameControllerBehaviour : MonoBehaviour
    {
        [SerializeField] private ScriptableGameConfig gameConfig;
            
        private GameController _gameController;

        private void Awake() =>
            _gameController = new GameController(Contexts.sharedInstance, gameConfig);

        private void Start() => _gameController.Initialize();

        private void Update() => _gameController.Execute();
    }
}