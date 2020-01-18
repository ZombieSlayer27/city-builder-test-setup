namespace Features.Config
{
    using Entitas.CodeGeneration.Attributes;

    [Config, Unique, ComponentName("GameConfig")]
    public interface IGameConfig
    {
        ProductionData ProductionData { get; }
    }
}