namespace Features.Config
{
    using Entitas.CodeGeneration.Attributes;

    [Config, Unique, ComponentName("GameConfig")]
    public interface IGameConfig
    {
        Productions Productions { get; }
    }
}