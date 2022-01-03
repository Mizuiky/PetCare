using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public class KitchenDataList
    {
        public List<Item> kitchenItems;

        public KitchenDataList(List<Item> items)
        {
            this.kitchenItems = new List<Item>(items);
        }
    }
}

