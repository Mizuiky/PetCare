using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour, IActivate
{
    [SerializeField]
    private List<ItemData> kitchenItems;

    [SerializeField]
    private BasketController basket;

    void Start()
    {
        EventClickController.OnNotifiedKitchen += EnableBasket;
        basket.Deactivate();
    }

    public void EnableBasket()
    {
        if(this.enabled)
        {
            this.basket.Enable(kitchenItems);
            this.enabled = false;
        }
        else
        {
            this.basket.Disable();
            this.enabled = true;
        }     
    }

    public void Activate()
    {
        
    }

    public void Deactivate()
    {
        EventClickController.OnNotifiedKitchen -= EnableBasket;
    }

    //kitchen get the list from another server that will open and cloe json and serialize it!
}
