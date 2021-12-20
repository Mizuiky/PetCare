using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventClickController : MonoBehaviour
{
    public delegate void PlayerRotation (bool rotateToRight);
    public static event PlayerRotation OnPlayerRotated;

    public delegate void NotifyKitchen();
    public static event NotifyKitchen OnNotifiedKitchen;

    public delegate void ChangeButtonStatus();
    public static event ChangeButtonStatus OnChangedButtonStatus;

    public delegate void OnChangeStatus(PetStatus status);
    public static event OnChangeStatus OnChangedStatus;

    public delegate void OnNotifyHungryUpdate(bool canConsume);
    public static event OnNotifyHungryUpdate OnNotifyUpdatedHungry;

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
        Debug.Log("start apply rotation event");

        if(OnPlayerRotated != null)
        {
            Debug.Log("!= null");
            OnPlayerRotated(rotateToRight);
        }  
    }

    #endregion

    #region Kitchen Notification

    public void OpenKitchen()
    {
        if(OnNotifiedKitchen != null)
        {
            OnNotifiedKitchen();
        }
    }
    #endregion

    #region UI Notification

    public void NotifyUI()
    {
        if (OnChangedButtonStatus != null)
        {
            OnChangedButtonStatus();
        }
    }

    #endregion
}
