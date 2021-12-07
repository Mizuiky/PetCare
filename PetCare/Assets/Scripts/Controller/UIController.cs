using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private HUD hud;

    void Start()
    {
        PetController.OnChangedStatus += UpdateHud;
    }

    
    void Update()
    {
        
    }

    private void UpdateHud(PetStatus status)
    {
        this.hud.UpdateStatusBar(status);

        //update this when player gain level on happiness and hungry
        this.hud.UpdateMaxStatusBar(status);
    }
}
