using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public class PetController : MonoBehaviour, IActivate
    {
        private Pet pet;

        [SerializeField]
        private Transform petLocation;

        [SerializeField]
        private GameObject[] pets;

        #region Events

        public delegate void OnChangeStatus(PetData status);
        public static event OnChangeStatus onChangeStatus;

        public delegate void OnHungryUpdate(bool canConsume);
        public static event OnHungryUpdate onHungryUpdate;

        #endregion

        void Start()
        {
            InstantiatePet();

            if (onChangeStatus != null)
            {
                Debug.Log("start to change status");
                onChangeStatus(this.pet.Data);
            }

            CheckCanConsumeItem();

            Activate();
        }

        public void Activate()
        {
            TimerController.onDecreaseStatus += DecreaseStatus;

            BasketController.onDecreaseItemQuantity += IncreaseHungry;

            EventController.onPlayerRotation += RotatePet;
        }

        public void Deactivate()
        {
            TimerController.onDecreaseStatus -= DecreaseStatus;

            BasketController.onDecreaseItemQuantity -= IncreaseHungry;

            EventController.onPlayerRotation -= RotatePet;

            this.gameObject.SetActive(false);
        }

        void OnDisable()
        {
            this.Deactivate();
        }

        private void InstantiatePet()
        {
            Debug.Log("instantiate pet");

            var newObj = Instantiate(this.pets[0], this.petLocation, false);

            if(newObj != null)
            {
                this.pet = new Pet();

                this.pet = newObj.gameObject.AddComponent<Pet>();

                var petData = LoadData.LoadPetData();

                Debug.Log("instantiate pet after load data");

                if (pet != null)
                {
                    this.pet.SetInitialData(petData);
                }
            }            
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
        
        public void RotatePet(bool rightSide)
        {
            if (rightSide)
            {
                this.petLocation.Rotate(-new Vector3(0, this.pet.RotateAmount, 0));
                Debug.Log("rotate right");
            }
            else
            {
                Debug.Log("rotate left");
                this.petLocation.Rotate(new Vector3(0, this.pet.RotateAmount, 0));
            }
        }
    }
}

