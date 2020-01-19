namespace Features.Player
{
    using Config;
    using TMPro;
    using UnityEngine;

    public class ResourceBehaviour : MonoBehaviour, IAnyResourceUpdateListener
    {
        [SerializeField] private Resource resource;
        [SerializeField] private TextMeshProUGUI resourceAmountText;
        
        private GameEntity _resourceListenerEntity;

        private void OnEnable()
        {
            _resourceListenerEntity = Contexts.sharedInstance.game.CreateEntity();
            _resourceListenerEntity.AddAnyResourceUpdateListener(this);
        }

        private void OnDisable()
        {
            if (_resourceListenerEntity != null)
            {
                _resourceListenerEntity.isDestroyed = true;
            }
        }

        public void OnAnyResourceUpdate(GameEntity entity, Resource value, int amount)
        {
            if (resource == value)
            {
                resourceAmountText.text = amount.ToString();
            }
        }
    }
}