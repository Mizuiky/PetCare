using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PetCare
{
    public class UIController : MonoBehaviour, IActivate
    {
        [SerializeField]
        private HUD hud;

        [SerializeField]
        private GameObject[] UIButtons;

        [SerializeField]
        private GameObject basketQuantity;

        [SerializeField]
        private GameObject[] roomsBackground;

        private List<Transform> itemQuantityText;

        void Awake()
        {
            this.Activate();
        }
        public void Activate()
        {
            this.GetChildrenTextComponent();

            PetController.onChangeStatus += UpdateHud;
            EventController.onChangeButtonStatus += UpdateButtonActiveStatus;
            BasketController.onQuantityTextUpdate += UpdateQuantityTextField;
            KitchenController.onChangeBackgroundVisibity += ChangeRoomBackgroundVisibility;
            KitchenController.onShowUIQuantity += SetTextVisibility;
        }

        private void UpdateHud(PetData status)
        {
            Debug.Log("updateHUD");

            this.hud.UpdateMaxStatusBar(status);

            this.hud.UpdateStatusBar(status);
        }

        private void OnDisable()
        {
            this.Deactivate();
        }

        public void Deactivate()
        {
            PetController.onChangeStatus -= this.UpdateHud;
            EventController.onChangeButtonStatus -= this.UpdateButtonActiveStatus;
            BasketController.onQuantityTextUpdate -= UpdateQuantityTextField;
            KitchenController.onChangeBackgroundVisibity -= ChangeRoomBackgroundVisibility;
            KitchenController.onShowUIQuantity -= SetTextVisibility;
        }

        public void UpdateButtonActiveStatus()
        {
            bool active = false;

            foreach (GameObject button in UIButtons)
            {
                active = button.activeInHierarchy ? false : true;

                button.SetActive(active);
            }
        }

        public void UpdateQuantityTextField(List<Item> items)
        {
            Text currentText;

            if (!this.basketQuantity.gameObject.activeInHierarchy)
            {
                this.basketQuantity.SetActive(true);
            }

            for (int i = 0; i < items.Count; i++)
            {
                currentText = this.itemQuantityText[i].GetComponentInChildren<Text>();
                currentText.text = items[i].Qtd.ToString();
                this.itemQuantityText[i].gameObject.SetActive(true);
            }
        }

        private void GetChildrenTextComponent()
        {
            var textComponents = this.basketQuantity.GetComponentsInChildren<Transform>();

            this.itemQuantityText = new List<Transform>();

            if (textComponents != null)
            {
                foreach (Transform text in textComponents)
                {
                    if (text.gameObject.CompareTag("Qtd"))
                    {
                        this.itemQuantityText.Add(text);
                    }
                }
            }

            this.SetTextVisibility(false);
        }

        private void SetTextVisibility(bool visible)
        {
            this.itemQuantityText.ForEach(x => x.gameObject.SetActive(visible));
        }

        private void ChangeRoomBackgroundVisibility(RoomType roomType, bool active)
        {
            foreach (GameObject room in this.roomsBackground)
            {
                if (room.name.Contains(roomType.ToString()))
                {
                    room.SetActive(active);
                }
            }
        }
    }
}
