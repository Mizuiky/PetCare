using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public class Pet : IPet
    {
        #region Private Fields

        private float rotationAmount;

        private PetData status;

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

        public PetData Status
        {
            get
            {
                return status;
            }
            set
            {
                this.status = value;
            }
        }


        public Pet(PetData status)
        {
            this.SetInitialStatus(status);
        }

        public void SetInitialStatus(PetData status)
        {
            Debug.Log("setting initial status");

            this.status.maxHungry = status.maxHungry;
            this.status.maxHappiness = status.maxHappiness;

            this.status.hungry = status.initialHungry;
            this.status.happiness = status.initialHappiness;
        }

        public void UpdateStatus(PetData status)
        {
            Debug.Log("updating status");

            this.status.maxHungry = status.maxHungry;
            this.status.maxHappiness = status.maxHappiness;

            this.status.hungry = status.hungry;
            this.status.happiness = status.happiness;
        }

        public void DecreaseHungry()
        {
            this.status.hungry -= amountToDecrease;
            this.status.hungry = Mathf.Max(0, this.status.hungry);
        }

        public void DecreaseHappiness()
        {
            this.status.happiness -= amountToDecrease;
            this.status.happiness = Mathf.Max(0, this.status.happiness);
        }

        public void IncreaseHappiness(int amount)
        {
            this.status.happiness += amount;
            this.status.happiness = Mathf.Min(this.status.maxHappiness, this.status.happiness);
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

