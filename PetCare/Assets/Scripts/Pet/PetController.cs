using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public class PetController : MonoBehaviour, IActivate, IPet
    {
        #region Private Fields

        [SerializeField]
        private float rotationAmount;
        private PetStatus status;

        [SerializeField]
        private int amountToUpdate;

        #endregion

        #region Properties

        [SerializeField]
        private int initialHungry;
        [SerializeField]
        private int maxHungry;

        [SerializeField]
        private int initialHappiness;
        [SerializeField]
        private int maxHappiness;

        public float RotationAmount { get => rotationAmount; }
        public int Amount { get => amountToUpdate; }

        public PetStatus Status
        {
            get
            {
                return this.status;
            }
            private set
            {
                this.status = value;
            }
        }
        public int InitialHungry
        {
            get
            {
                return this.initialHungry;
            }
            private set
            {
                this.initialHungry = value;
            }
        }
        public int MaxHungry
        {
            get
            {
                return this.maxHungry;
            }
            private set
            {
                this.maxHungry = value;
            }
        }

        public int InitialHappiness
        {
            get
            {
                return this.initialHappiness;
            }
            private set
            {
                this.initialHappiness = value;
            }
        }
        public int MaxHappiness
        {
            get
            {
                return this.maxHappiness;
            }
            private set
            {
                this.maxHappiness = value;
            }
        }

        #endregion

        #region Events

        public delegate void OnChangeStatus(PetStatus status);
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

            EventController.onPlayerRotation -= Rotate;

            this.gameObject.SetActive(false);
        }

        void Start()
        {
            this.status = new PetStatus();
            this.SetInitialStatus();

            if (onChangeStatus != null)
            {
                //Debug.Log("start to change status");
                onChangeStatus(this.status);
            }

            this.Activate();

            CheckCanConsumeItem();

            TimerController.onDecreaseStatus += DecreaseStatus;

            BasketController.onDecreaseItemQuantity += IncreaseHungry;

            EventController.onPlayerRotation += Rotate;
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnDisable()
        {
            this.Deactivate();
        }

        public void SetInitialStatus()
        {
            Debug.Log("setting initial status");

            this.status.maxHungry = this.maxHungry;
            this.status.maxHappiness = this.maxHappiness;

            this.status.hungry = this.initialHungry;
            this.status.happiness = this.initialHappiness;
        }

        public void DecreaseStatus()
        {
            this.DecreaseHungry();

            this.DecreaseHappiness();

            if (onChangeStatus != null)
            {
                onChangeStatus(this.status);
            }

            CheckCanConsumeItem();
        }

        public void DecreaseHungry()
        {
            this.status.hungry -= this.amountToUpdate;
            this.status.hungry = Mathf.Max(0, this.status.hungry);
        }
        public void DecreaseHappiness()
        {
            this.status.happiness -= this.amountToUpdate;
            this.status.happiness = Mathf.Max(0, this.status.happiness);
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

        public void IncreaseHappiness(int amount)
        {
            this.status.happiness += this.amountToUpdate;
            this.status.happiness = Mathf.Min(this.maxHappiness, this.status.happiness);
        }

        #region Player Rotation
        public void Rotate(bool rightSide)
        {
            if (rightSide)
            {
                this.transform.Rotate(-new Vector3(0, rotationAmount, 0));
                Debug.Log("rotate right");
            }
            else
            {
                Debug.Log("rotate left");
                this.transform.Rotate(new Vector3(0, rotationAmount, 0));
            }
        }

        #endregion
    }
}

