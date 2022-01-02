using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public interface IItem
    {
        public BasketItems Item { get; set; }

        public string Name { get; set; }
        public int Qtd { get; set; }
        public int ID { get; set; }
        public int Amount { get; set; }
    }
}

