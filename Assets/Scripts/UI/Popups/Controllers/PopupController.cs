using System;
using UnityEngine;

namespace Popups
{
    [RequireComponent(typeof(PopupView))]
    public class PopupController : MonoBehaviour
    {
        public event EventHandler PopupShown;

        private PopupView view;

        private void Awake()
        {
            view = GetComponent<PopupView>();
        }

        private void OnEnable()
        {
            SubscribeToViewEvents();
        }

        private void OnDisable()
        {
            UnsubscribeFromViewEvents();
        }

        protected virtual void SubscribeToViewEvents()
        {
            view.CloseButtonClicked += View_CloseButtonClicked;
        }

        protected virtual void UnsubscribeFromViewEvents()
        {
            view.CloseButtonClicked -= View_CloseButtonClicked;
        }

        private void View_CloseButtonClicked()
        {
            OnPopupShown();
        }

        protected virtual void OnPopupShown()
        {
            var handler = PopupShown;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}