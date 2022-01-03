using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    [Serializable]
    public class Item : IItem
    {
        [SerializeField]
        private string item;

        [SerializeField]
        private int qtd;

        [SerializeField]
        private int id;

        [SerializeField]
        private int hungryAmount;

        public string ItemType
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



