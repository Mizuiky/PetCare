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
        private GameObject kitchenStruture;

        private bool kitchenEnabled;

        #endregion

        public static bool petCanConsumeItem;

        #region Events

        public delegate void OnChangeBackgroundVisibity(RoomType roomType, bool active);
        public static event OnChangeBackgroundVisibity onChangeBackgroundVisibity;

        public delegate void OnShowUIQuantity(bool hide);
        public static event OnShowUIQuantity onShowUIQuantity;


        #endregion

        void Awake()
        {
            this.Activate();
        }

        public void EnableBasket()
        {
            if (this.kitchenEnabled)
            {
                this.kitchenStruture.SetActive(true);

                if(onChangeBackgroundVisibity != null)
                {
                    onChangeBackgroundVisibity(RoomType.Backyard, false);
                    onChangeBackgroundVisibity(RoomType.Kitchen, true);
                }                
               
                this.basket.Enable(this.kitchenItems);

                if (onShowUIQuantity != null)
                {
                    onShowUIQuantity(true);                   
                }

                this.kitchenEnabled = false;
            }
            else
            {
                this.kitchenStruture.SetActive(false);

                if (onChangeBackgroundVisibity != null)
                {
                    onChangeBackgroundVisibity(RoomType.Kitchen, false);
                    onChangeBackgroundVisibity(RoomType.Backyard, true);
                }

                this.basket.Disable();

                if (onShowUIQuantity != null)
                {
                    onShowUIQuantity(false);
                }           

                this.kitchenEnabled = true;
            }
        }

        public void Activate()
        {
            this.kitchenEnabled = true;

            this.kitchenItems = new List<Item>();

            this.kitchenItems = DataManager.LoadKitchenItems();

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

            DataManager.SaveKitchenData(this.kitchenItems);

            this.kitchenItems.Clear();

            this.kitchenStruture.SetActive(false);
            this.basket.gameObject.SetActive(false);
        }

        public void CheckCanConsumeItem(bool canConsume)
        {
            Debug.Log($"message received  canconsume= {canConsume}");
            petCanConsumeItem = canConsume;
        }      
    }
}


