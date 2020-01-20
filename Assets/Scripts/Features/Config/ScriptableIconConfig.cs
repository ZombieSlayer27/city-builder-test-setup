namespace Features.Config
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(menuName = "CityBuilder/Asset Config")]
    public class ScriptableIconConfig : ScriptableObject, IAssetConfig
    {
        [SerializeField] private List<IconAsset> _iconAssets;

        /// <summary>
        /// Assets Data
        /// </summary>
        public List<IconAsset> IconAssets => _iconAssets;
    }
}