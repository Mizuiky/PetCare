using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventClickController : MonoBehaviour
{
    public delegate void PlayerRotation (bool rotateToRight);
    public static event PlayerRotation OnPlayerRotated;



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
}
