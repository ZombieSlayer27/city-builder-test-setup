namespace Features.UI
{
    using System;
    using Config;
    using TMPro;
    using UnityEditor.VersionControl;
    using UnityEngine;
    using UnityEngine.UI;

    public class BuildingInfoBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform costItemRoot;
        [SerializeField] private CostItemBehaviour costItemBehaviourPrefab;
        [SerializeField] private TextMeshProUGUI buildingNameText;
        [SerializeField] private Button selectionButton;

        public event Action<MapObject> OnBuildingSelected;

        private MapObject _mapObjectId;

        private void OnEnable()
        {
            selectionButton.onClick.AddListener(OnSelected);
        }

        private void OnDisable()
        {
            selectionButton.onClick.RemoveListener(OnSelected);
        }

        private void OnSelected()
        {
            Debug.Log(_mapObjectId);
            OnBuildingSelected?.Invoke(_mapObjectId);
        }

        public void SetupView(ProductionConfig config)
        {
            _mapObjectId = config.MapObject;
            buildingNameText.text = config.Id;
            var resources = config.ProductionCostData;
            foreach (var resource in resources)
            {
                var costItem = GetCostItem();
                costItem.SetView(AssetIconHelper.GetSpriteForResource(resource.Resource), resource.Amount);
            }
        }

        private CostItemBehaviour GetCostItem()
        {
            var costItemBehaviour = Instantiate(costItemBehaviourPrefab, costItemRoot, false);
            return costItemBehaviour;
        }
    }
}