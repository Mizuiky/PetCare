using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public class Pet : IPet
    {
        #region Private Fields

        private int rotationAmount = 10;

        private PetData data;

        private int amountToDecrease = 2;
        #endregion

        public int RotateAmount
        {
            get
            {
                return this.rotationAmount;
            }
            set
            {
                this.rotationAmount = value;
            }
        }

        public int Amount
        {
            get
            {
                return this.amountToDecrease;
            }
            set
            {
                this.amountToDecrease = value;
            }
        }

        public PetData Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        } 

        public void SetInitialData(PetData newData)
        {
            Debug.Log("setting initial status");
            this.data = new PetData();
;
            this.data.maxHungry = newData.maxHungry;
            this.data.maxHappiness = newData.maxHappiness;

            this.data.hungry = newData.initialHungry;
            this.data.happiness = newData.initialHappiness;

            Debug.Log("initial status setted");
        }

        public void UpdateStatus(PetData status)
        {
            Debug.Log("updating status");

            this.data.maxHungry = status.maxHungry;
            this.data.maxHappiness = status.maxHappiness;

            this.data.hungry = status.hungry;
            this.data.happiness = status.happiness;
        }

        public void DecreaseHungry()
        {
            this.data.hungry -= amountToDecrease;
            this.data.hungry = Mathf.Max(0, this.data.hungry);
        }

        public void DecreaseHappiness()
        {
            this.data.happiness -= amountToDecrease;
            this.data.happiness = Mathf.Max(0, this.data.happiness);
        }

        public void IncreaseHappiness(int amount)
        {
            this.data.happiness += amount;
            this.data.happiness = Mathf.Min(this.data.maxHappiness, this.data.happiness);
        }

        public void IncreaseHungry(int amount)
        {
            this.data.hungry += amount;
            this.data.hungry = Mathf.Min(this.data.maxHungry, this.data.hungry);
        }
    }
}

