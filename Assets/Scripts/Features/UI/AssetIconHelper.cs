namespace Features.UI
{
    using System.Linq;
    using Config;
    using UnityEngine;

    public static class AssetIconHelper
    {
        public static Sprite GetSpriteForResource(Resource resource)
        {
            var config = Contexts.sharedInstance.config;
            if (config.hasAssetConfig)
            {
                var iconAsset = config.assetConfig.value.IconAssets.SingleOrDefault(x => x.Key == resource);
                if (iconAsset != null)
                {
                    return iconAsset.Value;
                }
            }

            return null;
        }
    }
}