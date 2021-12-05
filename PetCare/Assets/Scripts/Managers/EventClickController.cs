using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventClickController : MonoBehaviour
{
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
}
