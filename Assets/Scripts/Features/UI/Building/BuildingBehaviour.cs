namespace Features.UI.Building
{
    using UnityEngine;

    public class BuildingBehaviour : MonoBehaviour, IAnyProductionPercentDoneListener,
        IAnyConstructionPercentDoneListener, IAnyConstructionDoneListener
    {
        [SerializeField] private BuildingProgressBehaviour progressBehaviourPrefab;

        private GameEntity _productionPercentListener;
        private GameEntity _constructionPercentListener;
        private GameEntity _constructionDoneListener;

        private IProgressBehaviour _progressBehaviour;

        private string _buildingId;

        public string BuildingId
        {
            private get { return _buildingId; }
            set
            {
                _buildingId = value;
                _progressBehaviour.SetBuildingId(value);
            }
        }

        private void Awake()
        {
            var mainCamera = Camera.main;
            _progressBehaviour = Instantiate(progressBehaviourPrefab, this.transform, false);
            _progressBehaviour.SetCanvasCamera(mainCamera);
            _progressBehaviour.Show(true);
        }

        private void OnEnable()
        {
            _productionPercentListener = Contexts.sharedInstance.game.CreateEntity();
            _productionPercentListener.AddAnyProductionPercentDoneListener(this);

            _constructionPercentListener = Contexts.sharedInstance.game.CreateEntity();
            _constructionPercentListener.AddAnyConstructionPercentDoneListener(this);

            _constructionDoneListener = Contexts.sharedInstance.game.CreateEntity();
            _constructionDoneListener.AddAnyConstructionDoneListener(this);
        }

        private void OnDisable()
        {
            if (_productionPercentListener != null)
            {
                _productionPercentListener.RemoveAnyProductionPercentDoneListener(this);
                _productionPercentListener.isDestroyed = true;
            }

            if (_constructionPercentListener != null)
            {
                _constructionPercentListener.RemoveAnyConstructionPercentDoneListener(this);
                _constructionPercentListener.isDestroyed = true;
            }

            if (_constructionDoneListener != null)
            {
                _constructionDoneListener.RemoveAnyConstructionDoneListener(this);
                _constructionDoneListener.isDestroyed = true;
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