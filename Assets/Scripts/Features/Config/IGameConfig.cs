namespace Features.Config
{
    using Entitas.CodeGeneration.Attributes;
    using UnityEngine;

    [Config, Unique, ComponentName("GameConfig")]
    public interface IGameConfig
    {
        int GridSize { get; }
        int GridScaleFactor { get; }
        Productions Productions { get; }
    }
}