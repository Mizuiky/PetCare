using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenController : MonoBehaviour, IActivate
{
    [SerializeField]
    private List<ItemData> kitchenItems;

    [SerializeField]
    private BasketController basket;

    [SerializeField]
    private GameObject KitchenStruture;

    private bool kitchenEnabled;

    public static bool petCanConsumeItem;

    void Start()
    {
        this.Activate();
    }

    public void EnableBasket()
    {
        if(this.kitchenEnabled)
        {
            this.KitchenStruture.SetActive(true);

            this.basket.Enable(kitchenItems);

            this.kitchenEnabled = false;
        }
        else
        {
            this.KitchenStruture.SetActive(false);

            this.basket.Disable();
            this.kitchenEnabled = true;
        }     
    }

    public void Activate()
    {
        this.kitchenEnabled = true;

        PetController.onHungryUpdate += CheckCanConsumeItem;

        EventClickController.onNotifyKitchen += EnableBasket;

        basket.Deactivate();
    }

    
    private void OnDisable()
    {
        Deactivate();
    }

    public void Deactivate()
    {
        this.kitchenEnabled = false;

        PetController.onHungryUpdate -= CheckCanConsumeItem;

        EventClickController.onNotifyKitchen -= EnableBasket;

        this.KitchenStruture.SetActive(false);
        this.basket.gameObject.SetActive(false);
    }

    public void CheckCanConsumeItem(bool canConsume)
    {
        Debug.Log($"message received  canconsume= {canConsume}");
        petCanConsumeItem = canConsume;
    }

    //kitchen get the list from another server that will open and close json and serialize it!
}
