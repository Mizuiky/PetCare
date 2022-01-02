using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public class PetController : MonoBehaviour
    {
        private Pet pet;

        private int amountToUpdate;

        [SerializeField]
        private Transform petLocation;

        [SerializeField]
        private Pet[] pets;

        #region Events

        public delegate void OnChangeStatus(PetData status);
        public static event OnChangeStatus onChangeStatus;

        public delegate void OnHungryUpdate(bool canConsume);
        public static event OnHungryUpdate onHungryUpdate;

        #endregion

        void Start()
        {
            InstantiatePet();

            //pegar o component pet na cena;

            if (onChangeStatus != null)
            {
                Debug.Log("start to change status");
                onChangeStatus(this.pet.Data);
            }

            CheckCanConsumeItem();

            TimerController.onDecreaseStatus += DecreaseStatus;

            BasketController.onDecreaseItemQuantity += IncreaseHungry;

            EventController.onPlayerRotation += this.pet.Rotate;
        }

        public void Deactivate()
        {
            TimerController.onDecreaseStatus -= DecreaseStatus;

            BasketController.onDecreaseItemQuantity -= IncreaseHungry;

            EventController.onPlayerRotation -= this.pet.Rotate;

            this.gameObject.SetActive(false);
        }

        void OnDisable()
        {
            this.Deactivate();
        }

        private void InstantiatePet()
        {
            this.pet = Instantiate(pets[0], this.petLocation);

            var data = LoadPetData.loadData();
        }

        private void DecreaseStatus()
        {
            this.pet.DecreaseHungry();

            this.pet.DecreaseHappiness();

            if (onChangeStatus != null)
            {
                onChangeStatus(this.pet.Data);
            }

            CheckCanConsumeItem();
        }

        public void IncreaseHungry(int amount)
        {
            Debug.Log("trying to increase");
            if (CheckCanConsumeItem())
            {
                this.pet.IncreaseHungry(amount);

                Debug.Log("increased hungry");

                CheckCanConsumeItem();

                if (onChangeStatus != null)
                {
                    onChangeStatus(this.pet.Data);
                }
            }
        }

        public bool CheckCanConsumeItem()
        {
            Debug.Log("check full hungry");
            var canConsume = true;

            if (this.pet.Data.hungry == this.pet.Data.maxHungry)
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

