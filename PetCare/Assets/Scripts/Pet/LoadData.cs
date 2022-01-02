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

    public static List<ItemData> LoadKitchenItems()
    {
        List<ItemData> items = new List<ItemData>()
        {
            new ItemData()
            {
                Item = BasketItems.Cookie,
                Name = "Cookie",
                ID = 0,
                Qtd = 5,
                Amount = 1
            },
            new ItemData()
            {
                Item = BasketItems.CupCake,
                Name = "CupCake",
                ID = 1,
                Qtd = 2,
                Amount = 3
            },
            new ItemData()
            {
                Item = BasketItems.ChocolateCake,
                Name = "Cake",
                ID = 2,
                Qtd = 3,
                Amount = 5
            },
            new ItemData()
            {
                Item = BasketItems.Donut,
                Name = "Donut",
                ID = 3,
                Qtd = 2,
                Amount = 2
            }
        };

        return items;
    }
}


