namespace Features.MapObject
{
    using Config;
    using UnityEngine;

    public static class MapObjectHelper
    {
        public static GameObject GetMapObject(ProductionConfig config)
        {
            var assetPrefab = config.MapObjectAsset;
            return GameObject.Instantiate(assetPrefab);
        }

        public static Vector2Int ToGridPosition(Vector3 worldPosition)
        {
            var configContext = Contexts.sharedInstance.config;
            if (configContext.hasGameConfig)
            {
                var gridScaleFactor = configContext.gameConfig.value.GridScaleFactor;
                var row = (int) (worldPosition.x / gridScaleFactor);
                var col = (int) (worldPosition.z / gridScaleFactor);
                var gridPosition = new Vector2Int(Mathf.Abs(row), Mathf.Abs(col));
                return gridPosition;
            }

            return Vector2Int.zero;
        }
    }
}