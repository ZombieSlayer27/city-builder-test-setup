//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameModeEntity { get { return GetGroup(GameMatcher.GameMode).GetSingleEntity(); } }
    public Features.Components.GameModeComponent gameMode { get { return gameModeEntity.gameMode; } }
    public bool hasGameMode { get { return gameModeEntity != null; } }

    public GameEntity SetGameMode(Features.Config.GameMode newValue) {
        if (hasGameMode) {
            throw new Entitas.EntitasException("Could not set GameMode!\n" + this + " already has an entity with Features.Components.GameModeComponent!",
                "You should check if the context already has a gameModeEntity before setting it or use context.ReplaceGameMode().");
        }
        var entity = CreateEntity();
        entity.AddGameMode(newValue);
        return entity;
    }

    public void ReplaceGameMode(Features.Config.GameMode newValue) {
        var entity = gameModeEntity;
        if (entity == null) {
            entity = SetGameMode(newValue);
        } else {
            entity.ReplaceGameMode(newValue);
        }
    }

    public void RemoveGameMode() {
        gameModeEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Features.Components.GameModeComponent gameMode { get { return (Features.Components.GameModeComponent)GetComponent(GameComponentsLookup.GameMode); } }
    public bool hasGameMode { get { return HasComponent(GameComponentsLookup.GameMode); } }

    public void AddGameMode(Features.Config.GameMode newValue) {
        var index = GameComponentsLookup.GameMode;
        var component = (Features.Components.GameModeComponent)CreateComponent(index, typeof(Features.Components.GameModeComponent));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameMode(Features.Config.GameMode newValue) {
        var index = GameComponentsLookup.GameMode;
        var component = (Features.Components.GameModeComponent)CreateComponent(index, typeof(Features.Components.GameModeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameMode() {
        RemoveComponent(GameComponentsLookup.GameMode);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherGameMode;

    public static Entitas.IMatcher<GameEntity> GameMode {
        get {
            if (_matcherGameMode == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameMode);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameMode = matcher;
            }

            return _matcherGameMode;
        }
    }
}
