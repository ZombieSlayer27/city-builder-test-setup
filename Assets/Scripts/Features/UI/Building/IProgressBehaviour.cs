namespace Features.UI
{
    using UnityEngine;

    public interface IProgressBehaviour
    {
        void SetConstructionPercent(float percentDone);
        void SetProductionPercent(float percentDone);

        void ShowConstruction(bool canShow);
        void ShowProduction(bool canShow);

        void SetCanvasCamera(Camera camera);
        void Show(bool canShow);
    }
}