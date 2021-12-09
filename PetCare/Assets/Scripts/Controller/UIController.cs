using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private HUD hud;

    private void Awake()
    {
        PetController.OnChangedStatus += this.UpdateHud;
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
}
