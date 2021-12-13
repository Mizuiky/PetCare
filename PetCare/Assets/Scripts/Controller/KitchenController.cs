using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour
{ 
    [SerializeField]
    private ItemData[] items;

    [SerializeField]
    private BasketController basket;

    void Start()
    {
        this.basket.gameObject.SetActive(false);

        EventClickController.OnNotifiedKitchen += EnableBasket;
    }
    
    void Update()
    {
       
    }

    public void EnableBasket()
    {
        if(this.enabled)
        {
            this.basket.Enable(items);
            this.enabled = false;
        }
        else
        {
            this.basket.Disable();
            this.enabled = true;
        }
        
    }
}
