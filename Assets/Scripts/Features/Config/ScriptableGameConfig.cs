namespace Features.Config
{
    using UnityEngine;


    [CreateAssetMenu(menuName = "CityBuilder/Game Config")]
    public class ScriptableGameConfig : ScriptableObject, IGameConfig
    {
        [SerializeField] private Productions productions;

        /// <summary>
        /// Production Data
        /// </summary>
        public Productions Productions => productions;
    }
}