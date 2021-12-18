using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private HUD hud;

    [SerializeField]
    private GameObject[] UIButtons;

    private void Awake()
    {
        PetController.OnChangedStatus += this.UpdateHud;
        EventClickController.OnChangedButtonStatus += this.UpdateButtonActiveStatus;
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void UpdateHud(PetStatus status)
    {
        //Debug.Log("updateHUD");

        //update this when player gain level on happiness and hungry, create an initial method to set the initial max status
        this.hud.UpdateMaxStatusBar(status);

        this.hud.UpdateStatusBar(status);
    }

    private void OnDisable()
    {
        PetController.OnChangedStatus -= this.UpdateHud;
        EventClickController.OnChangedButtonStatus -= this.UpdateButtonActiveStatus;
    }

    public void UpdateButtonActiveStatus()
    {
        Debug.Log("test 1");
        bool active = false;

        foreach(GameObject button in UIButtons)
        {      
            active = button.activeInHierarchy ? false : true;
            
            button.SetActive(active);
        }
    }
}
