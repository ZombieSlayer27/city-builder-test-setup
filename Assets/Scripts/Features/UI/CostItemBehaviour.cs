namespace Features.UI
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class CostItemBehaviour : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI amountText;
        [SerializeField] private Image icon;

        public void SetView(Sprite sprite, int amount)
        {
            icon.sprite = sprite;
            amountText.text = amount.ToString();
        }
    }
}