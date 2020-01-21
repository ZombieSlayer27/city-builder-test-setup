namespace Features.Input
{
    using Config;
    using Entitas;
    using UI.Building;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public sealed class InputSystem : IExecuteSystem
    {
        private readonly Camera _camera;
        private readonly Contexts _contexts;

        private const string BuildingTag = "Building";

        public InputSystem(Contexts contexts)
        {
            _camera = Camera.main;
            _contexts = contexts;
        }

        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject(-1))
                {
                    return;
                }

                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (_contexts.game.hasGameMode && _contexts.game.gameMode.Value == GameMode.Regular)
                    {
                        if (hit.transform.CompareTag(BuildingTag))
                        {
                            _contexts.game.CreateEntity().AddTapOnBuilding(hit.transform.gameObject);
                        }
                    }
                    else
                    {
                        var mouseWorldPos = hit.point;
                        var e = _contexts.input.CreateEntity();
                        e.AddInput(mouseWorldPos);
                    }
                }
            }
        }
    }
}