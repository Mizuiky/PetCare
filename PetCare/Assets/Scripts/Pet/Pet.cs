using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public class Pet : MonoBehaviour, IPet
    {
        #region Private Fields

        private float rotationAmount;

        private PetData data;

        private int amountToDecrease;
        #endregion

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


        public Pet(PetData status)
        {
            this.SetInitialStatus(status);
        }

        public void SetInitialStatus(PetData status)
        {
            Debug.Log("setting initial status");

            this.data.maxHungry = status.maxHungry;
            this.data.maxHappiness = status.maxHappiness;

            this.data.hungry = status.initialHungry;
            this.data.happiness = status.initialHappiness;
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

        #region Pet Rotation
        public void Rotate(bool rightSide)
        {
            if (rightSide)
            {
                this.transform.Rotate(-new Vector3(0, this.rotationAmount, 0));
                Debug.Log("rotate right");
            }
            else
            {
                Debug.Log("rotate left");
                this.transform.Rotate(new Vector3(0, this.rotationAmount, 0));
            }
        }
        #endregion
    }
}

