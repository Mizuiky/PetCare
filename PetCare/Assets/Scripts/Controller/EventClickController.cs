using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventClickController : MonoBehaviour
{
    public delegate void OnPlayerRotation (bool rotateToRight);
    public static event OnPlayerRotation onPlayerRotation;

    public delegate void OnNotifyKitchen();
    public static event OnNotifyKitchen onNotifyKitchen;

    public delegate void OnChangeButtonStatus();
    public static event OnChangeButtonStatus onChangeButtonStatus;

    public delegate void OnChangeStatus(PetStatus status);
    public static event OnChangeStatus onChangeStatus;

    public delegate void OnHungryUpdate(bool canConsume);
    public static event OnHungryUpdate onHungryUpdate;

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

        if(onPlayerRotation != null)
        {
            Debug.Log("!= null");
            onPlayerRotation(rotateToRight);
        }  
    }

    #endregion

    #region Kitchen Notification

    public void OpenKitchen()
    {
        Debug.Log("Open Kitchen");

        if (onNotifyKitchen != null)
        {
            Debug.Log("Open Kitchen != null");
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
