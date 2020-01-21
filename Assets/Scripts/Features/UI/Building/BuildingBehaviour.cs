namespace Features.UI.Building
{
    using UnityEngine;

    public class BuildingBehaviour : MonoBehaviour, IAnyProductionPercentDoneListener,
        IAnyConstructionPercentDoneListener
    {
        [SerializeField] private BuildingProgressBehaviour progressBehaviourPrefab;

        private GameEntity _productionPercentListener;
        private GameEntity _constructionPercentListener;

        private IProgressBehaviour _progressBehaviour;
        public string BuildingId { get; set; }

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
        }

        private void OnDisable()
        {
            if (_productionPercentListener != null)
            {
                _productionPercentListener.isDestroyed = true;
            }

            if (_constructionPercentListener != null)
            {
                _constructionPercentListener.isDestroyed = true;
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
    }
}