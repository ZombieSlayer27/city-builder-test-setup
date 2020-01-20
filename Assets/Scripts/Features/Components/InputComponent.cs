namespace Features.Components
{
    using Entitas;
    using UnityEngine;

    [Input]
    public sealed class InputComponent : IComponent
    {
        public Vector3 Value;
    }
}