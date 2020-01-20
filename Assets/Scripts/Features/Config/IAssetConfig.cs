namespace Features.Config
{
    using System.Collections.Generic;
    using Entitas.CodeGeneration.Attributes;

    [Config, Unique, ComponentName("AssetConfig")]
    public interface IAssetConfig
    {
        List<IconAsset> IconAssets { get; }
    }
}