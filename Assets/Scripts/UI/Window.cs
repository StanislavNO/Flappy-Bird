using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _windowGroup;
        [SerializeField] private Button _actionButton;

        protected CanvasGroup WindowGroup => _windowGroup;
        protected Button ActionButton => _actionButton;

        private void OnEnable()
        {
            _actionButton.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _actionButton.onClick.RemoveListener(OnButtonClick);
        }

        public virtual void Open()
        {
            WindowGroup.alpha = 1f;
            gameObject.SetActive(true);
            ActionButton.interactable = true;
        }

        public virtual void Close()
        {
            WindowGroup.alpha = 0f;
            gameObject.SetActive(false);
            ActionButton.interactable = false;
        }

        protected abstract void OnButtonClick();
    }
}