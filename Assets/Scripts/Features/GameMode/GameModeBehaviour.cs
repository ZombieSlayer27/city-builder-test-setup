namespace Features.GameMode
{
    using Config;
    using UnityEngine;
    using UnityEngine.UI;

    public class GameModeBehaviour : MonoBehaviour
    {
        [SerializeField] private Button regularModeButton;

        [SerializeField] private Button buildModeButton;

        private void OnEnable()
        {
            regularModeButton.onClick.AddListener(OnRegularMode);
            buildModeButton.onClick.AddListener(OnBuildMode);
        }

        private void OnDisable()
        {
            regularModeButton.onClick.RemoveListener(OnRegularMode);
            buildModeButton.onClick.RemoveListener(OnBuildMode);
        }

        private void OnRegularMode()
        {
            var gameContext = Contexts.sharedInstance.game;
            gameContext.ReplaceGameMode(GameMode.Regular);
        }

        private void OnBuildMode()
        {
            var gameContext = Contexts.sharedInstance.game;
            gameContext.ReplaceGameMode(GameMode.Build);
        }
    }
}