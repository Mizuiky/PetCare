using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PetCare
{
    public class EventController: MonoBehaviour
    {
        #region Game Events

        public delegate void OnPlayerRotation(bool rotateToRight);
        public static event OnPlayerRotation onPlayerRotation;

        public delegate void OnNotifyKitchen();
        public static event OnNotifyKitchen onNotifyKitchen;

        public delegate void OnChangeButtonStatus();
        public static event OnChangeButtonStatus onChangeButtonStatus;

        public delegate void OnHungryUpdate(bool canConsume);
        public static event OnHungryUpdate onHungryUpdate;

        #endregion

        #region Scene Events

        public void ChangeScene(string currentlyScene)
        {
            SceneManager.LoadScene(currentlyScene);
        }

        #endregion

        #region Application Events

        public void QuitGame()
        {
            Application.Quit();
        }
        #endregion

        #region Player Notification

        public void ApplyRotation(bool rotateToRight)
        {
            if (onPlayerRotation != null)
            {
                onPlayerRotation(rotateToRight);
            }
        }

        #endregion

        #region Kitchen Notification

        public void OpenKitchen()
        {
            if (onNotifyKitchen != null)
            {
                onNotifyKitchen();
            }
        }
        #endregion

        #region UI Notification

        public void NotifyUI()
        {
            if (onChangeButtonStatus != null)
            {
                onChangeButtonStatus();
            }
        }

        #endregion
    }
}


