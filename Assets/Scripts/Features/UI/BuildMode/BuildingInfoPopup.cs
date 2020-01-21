namespace Features.UI
{
    using Config;
    using UnityEngine;
    using UnityEngine.UI;

    public class BuildingInfoPopup : MonoBehaviour, IAnyGameModeListener
    {
        [SerializeField] private BuildingInfoBehaviour buildingInfoPrefab;
        [SerializeField] private Transform buildingInfoRoot;
        [SerializeField] private GameObject buildingPopupContainer;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button backButton;

        private GameEntity _gameModeListener;
        private bool _isSetupDone;

        private void OnEnable()
        {
            backButton.onClick.AddListener(OnClose);
            closeButton.onClick.AddListener(OnClose);
            buildingPopupContainer.SetActive(false);

            _gameModeListener = Contexts.sharedInstance.game.CreateEntity();
            _gameModeListener.AddAnyGameModeListener(this);
        }

        private void OnDisable()
        {
            backButton.onClick.RemoveListener(OnClose);
            closeButton.onClick.RemoveListener(OnClose);
            if (_gameModeListener != null)
            {
                _gameModeListener.isDestroyed = true;
            }
        }

        private void OnClose()
        {
            buildingPopupContainer.SetActive(false);
        }

        private void SetupView(Productions productions)
        {
            if (_isSetupDone)
            {
                return;
            }

            foreach (var config in productions.Config)
            {
                var buildingInfo = GetBuildingInfo();
                buildingInfo.SetupView(config);
                buildingInfo.OnBuildingSelected += OnBuildingSelected;
            }

            _isSetupDone = true;
        }

        private BuildingInfoBehaviour GetBuildingInfo()
        {
            var buildingInfo = Instantiate(buildingInfoPrefab, buildingInfoRoot, false);
            buildingInfo.gameObject.SetActive(true);
            return buildingInfo;
        }

        public void OnAnyGameMode(GameEntity entity, GameMode value)
        {
            if (value == GameMode.Build)
            {
                var configContext = Contexts.sharedInstance.config;
                if (configContext.hasGameConfig)
                {
                    var config = configContext.gameConfig.value.Productions;
                    SetupView(config);
                    buildingPopupContainer.SetActive(true);
                }
            }
        }

        private void OnBuildingSelected(MapObject mapObject)
        {
            buildingPopupContainer.SetActive(false);
            Contexts.sharedInstance.game.ReplaceMapObjectPlacement(mapObject);
        }
    }
}