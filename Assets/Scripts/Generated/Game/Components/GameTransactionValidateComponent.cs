//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Features.Components.Transaction.TransactionValidateComponent transactionValidateComponent = new Features.Components.Transaction.TransactionValidateComponent();

    public bool isTransactionValidate {
        get { return HasComponent(GameComponentsLookup.TransactionValidate); }
        set {
            if (value != isTransactionValidate) {
                var index = GameComponentsLookup.TransactionValidate;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : transactionValidateComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherTransactionValidate;

    public static Entitas.IMatcher<GameEntity> TransactionValidate {
        get {
            if (_matcherTransactionValidate == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TransactionValidate);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTransactionValidate = matcher;
            }

            return _matcherTransactionValidate;
        }
    }
}