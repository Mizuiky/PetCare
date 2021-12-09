using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : IItem
{
    [SerializeField]
    BasketItems item;

    [SerializeField]
    private int qtd;     

    public int Id
    {
        get
        {
            return (int)this.item;
        }
    }

    public int Qtd
    {
        get
        {
            return this.qtd;
        }
    }
}
