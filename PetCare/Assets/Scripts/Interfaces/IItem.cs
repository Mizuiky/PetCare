using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    public string Name { get; }
    public int Qtd { get;  }
    public int ID { get; }
    public int Amount { get; }
}
