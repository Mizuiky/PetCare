using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public class PetController : MonoBehaviour, IActivate
    {
        private Pet pet;

        private int amountToUpdate;

        #region Events

        public delegate void OnChangeStatus(PetData status);
        public static event OnChangeStatus onChangeStatus;

        public delegate void OnHungryUpdate(bool canConsume);
        public static event OnHungryUpdate onHungryUpdate;

        #endregion

        public void Activate()
        {
            this.gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            TimerController.onDecreaseStatus -= DecreaseStatus;

            BasketController.onDecreaseItemQuantity -= IncreaseHungry;

            EventController.onPlayerRotation -= this.pet.Rotate;

            this.gameObject.SetActive(false);
        }

        void Start()
        {
            this.pet = GetComponent<Pet>();

            //pegar o component pet na cena;

            if (onChangeStatus != null)
            {
                //Debug.Log("start to change status");
                onChangeStatus(this.pet.Status);
            }

            this.Activate();

            CheckCanConsumeItem();

            TimerController.onDecreaseStatus += DecreaseStatus;

            BasketController.onDecreaseItemQuantity += IncreaseHungry;

            EventController.onPlayerRotation += this.pet.Rotate;
        }

        void OnDisable()
        {
            this.Deactivate();
        }

        public void DecreaseStatus()
        {
            this.pet.DecreaseHungry();

            this.pet.DecreaseHappiness();

            if (onChangeStatus != null)
            {
                onChangeStatus(this.pet.Status);
            }

            CheckCanConsumeItem();
        }

       


        public void IncreaseHungry(int amount)
        {
            Debug.Log("trying to increase");
            if (CheckCanConsumeItem())
            {
                this.status.hungry += amount;
                this.status.hungry = Mathf.Min(this.maxHungry, this.status.hungry);

                Debug.Log("increased hungry");

                CheckCanConsumeItem();

                if (onChangeStatus != null)
                {
                    onChangeStatus(this.status);
                }
            }
        }

        public bool CheckCanConsumeItem()
        {
            Debug.Log("check full hungry");
            var canConsume = true;

            if (this.status.hungry == this.maxHungry)
            {
                Debug.Log("is full hungry");
                canConsume = false;
            }

            if (onHungryUpdate != null)
            {
                Debug.Log("notify update");
                onHungryUpdate(canConsume);
            }

            return canConsume;
        }
     
    }
}

