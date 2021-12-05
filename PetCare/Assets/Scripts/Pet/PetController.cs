using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    #region Private Fields

    [SerializeField]
    private float rotationAmount;

    #endregion

    private void OnDisable()
    {
        EventClickController.OnPlayerRotated -= RotatePlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        EventClickController.OnPlayerRotated += RotatePlayer;
    }

    // Update is called once per frame
    void Update()
    {   
               
    }

    #region Player Rotation
    void RotatePlayer(bool rightSide)
    {
        Debug.Log("RotatePlayer called");
        if (!rightSide)
        {
            this.transform.Rotate(- new Vector3(0, rotationAmount, 0));
        }
        else
        {
            this.transform.Rotate(new Vector3(0, rotationAmount, 0));
        } 
    }


    #endregion
}
