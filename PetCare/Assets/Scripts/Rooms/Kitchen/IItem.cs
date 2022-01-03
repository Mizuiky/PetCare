using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public interface IItem
    {
        public string ItemType { get; set; }
        public int Qtd { get; set; }
        public int ID { get; set; }
        public int Amount { get; set; }
    }
}

