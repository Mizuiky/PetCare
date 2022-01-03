using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PetCare;
using System.IO;
using System;

public static class DataManager
{
    //Find %AppData% folder and follow the path: C:..\AppData\LocalLow\DefaultCompany\PetCare\PetCareSaveData
    public static string directory = Application.persistentDataPath + "/PetCareSaveData/";

    public static string petFileName = "PetDataFile.txt";
    public static string kitchenDataFileName = "KitchenDataFile.txt";

    public static void SavePetData(PetData petData)
    {
        if(!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        string json = JsonUtility.ToJson(petData, true);
        File.WriteAllText(directory + petFileName, json);
    }

    public static void SaveKitchenData(List<Item> kitchenItems)
    {
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        KitchenDataList list = new KitchenDataList(kitchenItems);

        string json = JsonUtility.ToJson(list, true);
        File.WriteAllText(directory + kitchenDataFileName, json);
    }

    public static PetData LoadPetData()
    {
        Debug.Log("load pet data");

        string fullPath = directory + petFileName;

        PetData data = new PetData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            data = JsonUtility.FromJson<PetData>(json);

            Debug.Log("Saved data into PetDataFile.txt");

            return data;
        }

        Debug.Log("Saved File doesn't exist, creating a default configuration");

        PetData newData = new PetData()
        {
            hungry = 0,
            happiness = 0,

            maxHungry = 15,
            maxHappiness = 15,

            initialHungry = 6,
            initialHappiness = 12,
        };

        return newData;
    }

    public static List<Item> LoadKitchenItems()
    {
        string fullPath = directory + kitchenDataFileName;

        List<Item> items = new List<Item>();

        if (File.Exists(fullPath))
        {
            KitchenDataList kitchenList = new KitchenDataList(items);

            string json = File.ReadAllText(fullPath);
            kitchenList = JsonUtility.FromJson<KitchenDataList>(json);

            Debug.Log("Saved data into kitchenDataFile.txt");

            return kitchenList.kitchenItems;
        }

        Debug.Log("Saved File doesn't exist, creating a default configuration");

        items = new List<Item>()
        {
            new Item()
            {
                ItemType = Enum.GetName(typeof(BasketItems), 1),
                ID = 0,
                Qtd = 5,
                Amount = 1
            },
            new Item()
            {
                ItemType = Enum.GetName(typeof(BasketItems), 0),
                ID = 1,
                Qtd = 2,
                Amount = 3
            },
            new Item()
            {
                ItemType = Enum.GetName(typeof(BasketItems), 4),
                ID = 2,
                Qtd = 3,
                Amount = 5
            },
            new Item()
            {
                ItemType = Enum.GetName(typeof(BasketItems), 2),
                ID = 3,
                Qtd = 2,
                Amount = 2
            },
            new Item()
            {
                ItemType = Enum.GetName(typeof(BasketItems), 3),
                ID = 4,
                Qtd = 1,
                Amount = 4
            }
        };

        return items;
    }
}


