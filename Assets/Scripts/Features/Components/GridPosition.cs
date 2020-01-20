namespace Features.Components
{
    using Entitas;
    using UnityEngine;

    [Game]
    public sealed class GridPosition : IComponent
    {
        public Vector2Int Value;
    }
}