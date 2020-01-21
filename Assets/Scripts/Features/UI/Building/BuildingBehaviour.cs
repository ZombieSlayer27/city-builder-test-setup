namespace Features.UI.Building
{
    using UnityEngine;

    public class BuildingBehaviour : MonoBehaviour, IAnyProductionPercentDoneListener,
        IAnyConstructionPercentDoneListener, IAnyConstructionDoneListener
    {
        [SerializeField] private BuildingProgressBehaviour progressBehaviourPrefab;
        [SerializeField] private Transform progressBehaviourParent;

        private GameEntity _listenerEntity;

        private IProgressBehaviour _progressBehaviour;

        private string _buildingId;

        public string BuildingId
        {
            get => _buildingId;
            set
            {
                _buildingId = value;
                _progressBehaviour.SetBuildingId(value);
            }
        }

        private void Awake()
        {
            var mainCamera = Camera.main;
            _progressBehaviour = Instantiate(progressBehaviourPrefab, progressBehaviourParent, false);
            _progressBehaviour.SetCanvasCamera(mainCamera);
            ShowProgress();
        }

        public void ShowProgress()
        {
            _progressBehaviour.Show(true);
        }

        private void OnEnable()
        {
            _listenerEntity = Contexts.sharedInstance.game.CreateEntity();
            _listenerEntity.AddAnyProductionPercentDoneListener(this);
            _listenerEntity.AddAnyConstructionPercentDoneListener(this);
            _listenerEntity.AddAnyConstructionDoneListener(this);
        }

        private void OnDisable()
        {
            if (_listenerEntity != null)
            {
                _listenerEntity.RemoveAnyProductionPercentDoneListener(this);
                _listenerEntity.RemoveAnyConstructionPercentDoneListener(this);
                _listenerEntity.RemoveAnyConstructionDoneListener(this);
            }
        }

        public void OnAnyProductionPercentDone(GameEntity entity, float value)
        {
            if (entity.hasProductionPercentDone && entity.hasBuildingId && entity.buildingId.Value == BuildingId)
            {
                _progressBehaviour.SetProductionPercent(value);
                _progressBehaviour.ShowProduction(true);
            }
        }

        public void OnAnyConstructionPercentDone(GameEntity entity, float value)
        {
            if (entity.hasConstructionPercentDone && entity.hasBuildingId && entity.buildingId.Value == BuildingId)
            {
                _progressBehaviour.SetConstructionPercent(value);
                _progressBehaviour.ShowConstruction(true);
                _progressBehaviour.ShowProduction(false);
            }
        }

        public void OnAnyConstructionDone(GameEntity entity)
        {
            if (entity.isConstructionDone && entity.hasBuildingId && entity.buildingId.Value == BuildingId)
            {
                _progressBehaviour.ShowConstruction(false);
                _progressBehaviour.Show(false);
            }
        }
    }
}