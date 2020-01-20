namespace Features.Components
{
    using Entitas;
    using UnityEngine;

    [Game]
    public sealed class MapObjectPosition : IComponent
    {
        public Vector3 Value;
    }
}