using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    #region private Fields

    [SerializeField]
    private Slider hungrySlider;
    [SerializeField]
    private Slider playSlider;

    #endregion

    public void UpdateStatusBar(PetStatus status)
    {
        this.hungrySlider.value = status.hungry;
        this.playSlider.value = status.happiness;
    }

    public void UpdateMaxStatusBar(PetStatus status)
    {
        this.hungrySlider.maxValue = status.maxHungry;
        this.playSlider.maxValue = status.maxHappiness;
    }

}
