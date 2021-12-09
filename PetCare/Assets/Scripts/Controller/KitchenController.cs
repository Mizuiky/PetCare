using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour
{ 
    [SerializeField]
    private Item[] items;

    [SerializeField]
    private BasketController basket;

    void Start()
    {
        
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
        this.basket.Enable(items);
    }
}
