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

    public delegate void ChangeButtonStatus(bool active);
    public static event ChangeButtonStatus OnChangedButtonStatus;

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
        if(OnChangedButtonStatus != null)
        {
            OnChangedButtonStatus(false);
        }

        if(OnNotifiedKitchen != null)
        {
            OnNotifiedKitchen();
        }
    }
    #endregion
}
