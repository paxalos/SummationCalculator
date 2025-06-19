using System.Collections.Generic;
using UnityEngine;
using Popups;
using System;

namespace Managers
{
    public class PopupsManager : MonoBehaviour
    {
        [SerializeField] GameObject popupsCamera;
        [SerializeField] Transform popupsCanvas;

        private List<PopupController> popups = new();

        public void ShowErrorMessage()
        {
            ShowPopup("Popups/ErrorWindow");
        }

        private void ShowPopup(string popupPath)
        {
            popupsCamera.SetActive(true);
            var popupPrefab = Resources.Load<PopupController>(popupPath);
            var popup = Instantiate(popupPrefab, popupsCanvas);
            popup.PopupShown += Popup_PopupShown;
            popups.Add(popup);
        }

        private void Popup_PopupShown(object sender, EventArgs e)
        {
            var popup = (PopupController)sender;
            popup.PopupShown -= Popup_PopupShown;
            popups.Remove(popup);
            Destroy(popup.gameObject);

            if (popups.Count == 0)
            {
                popupsCamera.SetActive(false);
            }
        }
    }
}