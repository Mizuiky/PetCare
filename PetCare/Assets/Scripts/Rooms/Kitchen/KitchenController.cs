using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public class KitchenController : MonoBehaviour, IActivate
    {
        #region Private Fields

        private List<Item> kitchenItems;

        [SerializeField]
        private BasketController basket;

        [SerializeField]
        private GameObject KitchenStruture;

        private bool kitchenEnabled;

        #endregion

        public static bool petCanConsumeItem;

        #region Events

        public delegate void OnChangeBackgroundVisibity(RoomType roomType, bool active);
        public static event OnChangeBackgroundVisibity onChangeBackgroundVisibity;

        #endregion

        void Awake()
        {
            this.Activate();
        }

        public void EnableBasket()
        {
            if (this.kitchenEnabled)
            {
                this.KitchenStruture.SetActive(true);

                if(onChangeBackgroundVisibity != null)
                {
                    onChangeBackgroundVisibity(RoomType.Backyard, false);
                    onChangeBackgroundVisibity(RoomType.Kitchen, true);
                }

                if(this.kitchenItems.Count == 0)
                {
                    this.kitchenItems = LoadData.LoadKitchenItems();
                }
               
                this.basket.Enable(this.kitchenItems);

                this.kitchenEnabled = false;
            }
            else
            {
                this.KitchenStruture.SetActive(false);

                if (onChangeBackgroundVisibity != null)
                {
                    onChangeBackgroundVisibity(RoomType.Kitchen, false);
                    onChangeBackgroundVisibity(RoomType.Backyard, true);
                }

                this.basket.Disable();

                this.kitchenItems.Clear();

                this.kitchenEnabled = true;
            }
        }

        public void Activate()
        {
            this.kitchenEnabled = true;

            this.kitchenItems = new List<Item>();

            this.kitchenItems = LoadData.LoadKitchenItems();

            PetController.onHungryUpdate += CheckCanConsumeItem;

            EventController.onNotifyKitchen += EnableBasket;

            basket.Deactivate();
        }


        private void OnDisable()
        {
            Deactivate();
        }

        public void Deactivate()
        {
            this.kitchenEnabled = false;

            PetController.onHungryUpdate -= CheckCanConsumeItem;

            EventController.onNotifyKitchen -= EnableBasket;

            this.KitchenStruture.SetActive(false);
            this.basket.gameObject.SetActive(false);
        }

        public void CheckCanConsumeItem(bool canConsume)
        {
            Debug.Log($"message received  canconsume= {canConsume}");
            petCanConsumeItem = canConsume;
        }      
    }
}


