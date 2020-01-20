namespace Features.Config
{
    using UnityEngine;


    [CreateAssetMenu(menuName = "CityBuilder/Game Config")]
    public class ScriptableGameConfig : ScriptableObject, IGameConfig
    {
        [SerializeField] private int gridSize;

        [SerializeField] private int gridScaleFactor;

        [SerializeField] private Productions productions;

        /// <summary>
        /// Production Data
        /// </summary>
        public Productions Productions => productions;

        /// <summary>
        /// Grid Size
        /// </summary>
        public int GridSize => gridSize;

        /// <summary>
        /// Scale ratio of grid to convert world co ordinates to grid
        /// </summary>
        public int GridScaleFactor => gridScaleFactor;
    }
}