namespace Features.MapObject
{
    using Config;
    using UI.Building;
    using UnityEngine;

    public static class MapObjectHelper
    {
        private static GameObject GetMapObject(GameObject assetObject)
        {
            return GameObject.Instantiate(assetObject);
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

        public static void SetMapObjectWithIdAt(ProductionConfig config, string buildingId, Vector3 worldPosition)
        {
            var asset = GetMapObject(config.MapObjectAsset);
            var buildingDecoration = asset.GetComponent<BuildingBehaviour>();
            if (buildingDecoration != null)
            {
                buildingDecoration.BuildingId = buildingId;

                var convertedPosition = new Vector3(worldPosition.x - worldPosition.x % 10, 0,
                    worldPosition.z - worldPosition.z % 10);
                asset.transform.position = convertedPosition;
            }
        }
    }
}