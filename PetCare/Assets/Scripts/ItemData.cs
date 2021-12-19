using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData : IItem
{
    [SerializeField]
    BasketItems item;

    [SerializeField]
    private int qtd;

    [SerializeField]
    private int id;

    [SerializeField]
    private int hungryAmount;

    public string Name
    {
        get
        {
            return this.item.ToString();
        }
    }

    public int Qtd
    {
        get
        {
            return this.qtd;
        }
        set
        {
            this.qtd = value;
        }
    }

    public int ID
    {
        get
        {
            return this.id;
        }
    }

    public int Amount
    {
        get
        {
            return this.hungryAmount;
        }
    }
}

