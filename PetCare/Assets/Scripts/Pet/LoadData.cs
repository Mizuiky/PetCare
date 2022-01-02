using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetCare;

public static class LoadData
{
    public static PetData LoadPetData()
    {
        Debug.Log("load data");

        PetData newData = new PetData()
        {
            hungry = 0,
            happiness = 0,

            maxHungry = 10,
            maxHappiness = 10,

            initialHungry = 8,
            initialHappiness = 5,
        };

        return newData;
    }

    public static void SavePetData(PetData petData)
    {

    }

    public static List<Item> LoadKitchenItems()
    {
        List<Item> items = new List<Item>()
        {
            new Item()
            {
                ItemType = BasketItems.Cookie,
                Name = "Cookie",
                ID = 0,
                Qtd = 5,
                Amount = 1
            },
            new Item()
            {
                ItemType = BasketItems.CupCake,
                Name = "CupCake",
                ID = 1,
                Qtd = 2,
                Amount = 3
            },
            new Item()
            {
                ItemType = BasketItems.ChocolateCake,
                Name = "Cake",
                ID = 2,
                Qtd = 3,
                Amount = 5
            },
            new Item()
            {
                ItemType = BasketItems.Donut,
                Name = "Donut",
                ID = 3,
                Qtd = 2,
                Amount = 2
            }
        };

        return items;
    }

    public static void SaveKitchenItems(List<Item> kitchenItems)
    {

    }
}


