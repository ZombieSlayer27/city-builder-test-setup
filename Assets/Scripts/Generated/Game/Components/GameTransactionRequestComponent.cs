//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Features.Components.Transaction.TransactionRequestComponent transactionRequest { get { return (Features.Components.Transaction.TransactionRequestComponent)GetComponent(GameComponentsLookup.TransactionRequest); } }
    public bool hasTransactionRequest { get { return HasComponent(GameComponentsLookup.TransactionRequest); } }

    public void AddTransactionRequest(System.Collections.Generic.List<Features.Config.ResourceData> newResources) {
        var index = GameComponentsLookup.TransactionRequest;
        var component = (Features.Components.Transaction.TransactionRequestComponent)CreateComponent(index, typeof(Features.Components.Transaction.TransactionRequestComponent));
        component.Resources = newResources;
        AddComponent(index, component);
    }

    public void ReplaceTransactionRequest(System.Collections.Generic.List<Features.Config.ResourceData> newResources) {
        var index = GameComponentsLookup.TransactionRequest;
        var component = (Features.Components.Transaction.TransactionRequestComponent)CreateComponent(index, typeof(Features.Components.Transaction.TransactionRequestComponent));
        component.Resources = newResources;
        ReplaceComponent(index, component);
    }

    public void RemoveTransactionRequest() {
        RemoveComponent(GameComponentsLookup.TransactionRequest);
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

    static Entitas.IMatcher<GameEntity> _matcherTransactionRequest;

    public static Entitas.IMatcher<GameEntity> TransactionRequest {
        get {
            if (_matcherTransactionRequest == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TransactionRequest);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTransactionRequest = matcher;
            }

            return _matcherTransactionRequest;
        }
    }
}
