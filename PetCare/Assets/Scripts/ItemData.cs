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
    }

    public int ID
    {
        get
        {
            return this.id;
        }
    }
}
