using System;
using UnityEngine;
using UnityEngine.UI;

namespace Popups
{
    public class PopupView : MonoBehaviour
    {
        public event Action CloseButtonClicked;

        [SerializeField] private Button closeButton;

        private void Awake()
        {
            closeButton.onClick.AddListener(CloseButton_Clicked);
        }

        private void CloseButton_Clicked()
        {
            CloseButtonClicked?.Invoke();
        }
    }
}