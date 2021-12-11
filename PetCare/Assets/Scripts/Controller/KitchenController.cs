using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour
{ 
    [SerializeField]
    private Item[] items;

    [SerializeField]
    private BasketController basket;

    private bool enabled;

    void Start()
    {
        this.enabled = false;
        EventClickController.OnNotifiedKitchen += EnableBasket;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.EnableBasket();
        }
    }

    public void EnableBasket()
    {
        if(!enabled)
        {
            this.basket.Enable(items);
            this.enabled = true;
        }
        else
        {
            this.basket.Disable();
            this.enabled = false;
        }
        
    }
}
