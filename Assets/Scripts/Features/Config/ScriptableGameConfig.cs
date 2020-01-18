namespace Features.Config
{
    using UnityEngine;


    [CreateAssetMenu(menuName = "CityBuilder/Game Config")]
    public class ScriptableGameConfig : ScriptableObject, IGameConfig
    {
        [SerializeField] private ProductionData _productionData;

        /// <summary>
        /// Production Data
        /// </summary>
        public ProductionData ProductionData => _productionData;
    }
}