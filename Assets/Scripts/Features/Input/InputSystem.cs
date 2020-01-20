namespace Features.Input
{
    using Entitas;
    using UnityEngine;

    public sealed class InputSystem : IExecuteSystem
    {
        private readonly Camera _camera;
        private readonly Contexts _contexts;

        public InputSystem(Contexts contexts)
        {
            _camera = Camera.main;
            _contexts = contexts;
        }

        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var mouseWorldPos = hit.point;
                    var e = _contexts.input.CreateEntity();
                    e.AddInput(mouseWorldPos);
                }
            }
        }
    }
}