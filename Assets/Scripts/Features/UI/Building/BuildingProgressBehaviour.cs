namespace Features.UI
{
    using UnityEngine;
    using UnityEngine.UI;

    public class BuildingProgressBehaviour : MonoBehaviour, IProgressBehaviour
    {
        [SerializeField] private Image constructionImage;
        [SerializeField] private Image productionImage;
        [SerializeField] private GameObject constructionGameObject;
        [SerializeField] private GameObject productionGameObject;
        [SerializeField] private Button closeButton;
        [SerializeField] private Canvas canvas;

        private void OnEnable()
        {
            closeButton.onClick.AddListener(OnClose);
        }

        private void OnDisable()
        {
            closeButton.onClick.AddListener(OnClose);
        }

        public void SetConstructionPercent(float percentDone)
        {
            constructionImage.fillAmount = percentDone;
        }

        public void SetProductionPercent(float percentDone)
        {
            productionImage.fillAmount = percentDone;
        }

        public void ShowConstruction(bool canShow)
        {
            constructionGameObject.SetActive(canShow);
        }

        public void ShowProduction(bool canShow)
        {
            productionGameObject.SetActive(canShow);
        }

        public void SetCanvasCamera(Camera camera)
        {
            canvas.worldCamera = camera;
        }

        private void OnClose()
        {
            Show(false);
        }

        public void Show(bool canShow)
        {
            gameObject.SetActive(canShow);
        }
    }
}