using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    [System.Serializable]
    public class Item : IItem
    {
        private BasketItems item;

        private string name;

        private int qtd;

        private int id;

        private int hungryAmount;

        public BasketItems ItemType
        {
            get
            {
                return this.item;
            }
            set
            {
                this.item = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
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
            set
            {
                this.id = value;
            }
        }

        public int Amount
        {
            get
            {
                return this.hungryAmount;
            }
            set
            {
                this.hungryAmount = value;
            }
        }
    }
}



