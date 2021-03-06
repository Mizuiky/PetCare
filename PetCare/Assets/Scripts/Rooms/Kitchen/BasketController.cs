using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PetCare
{
    public class BasketController : MonoBehaviour, IActivate
    {
        #region Private Fields

        [SerializeField]
        private GameObject[] content;

        [SerializeField]
        private Material[] itemMaterial;

        [SerializeField]
        private Transform[] itemsPlace;

        private List<Item> basketDataList;

        private Dictionary<int, GameObject> itensToSpawn;

        private Ray rayPosition;
        private RaycastHit hit;

        private int layer_Mask;

        #endregion

        #region Events

        public delegate void OnDecreaseItemQuantity(int amount);
        public static event OnDecreaseItemQuantity onDecreaseItemQuantity;

        public delegate void OnQuantityTextUpdate(List<Item> item);
        public static event OnQuantityTextUpdate onQuantityTextUpdate;

        #endregion

        void Start()
        {
            this.layer_Mask = LayerMask.GetMask("Item");
        }

        void Update()
        {
            this.rayPosition = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayPosition, out hit, 50, this.layer_Mask))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider != null)
                    {
                        Debug.Log(hit.transform.name);
                        Debug.DrawRay(rayPosition.origin, rayPosition.direction * 20, Color.blue, 50f);

                        var sweet = hit.collider.GetComponent<Candy>();

                        if (sweet != null)
                        {
                            UpdateItemQuantity(sweet);
                        }
                    }
                }
            }
        }

        public void InitiateBasketData(List<Item> items)
        {
            this.itensToSpawn = new Dictionary<int, GameObject>();

            //this will receive the reference from the list in the kitchen.
            this.basketDataList = new List<Item>(items);

            for (int i = 0; i < items.Count; i++)
            {
                var item = Array.Find(this.content, content => content.name.Contains(items[i].ItemType));

                if (item != null)
                {
                    this.itensToSpawn.Add(items[i].ID, item);
                }
            }

            if (onQuantityTextUpdate != null)
            {
                onQuantityTextUpdate(this.basketDataList);
            }
        }

        public void UpdateItemQuantity(Candy item)
        {
            Debug.Log($"updatequantity  canconsume= {KitchenController.petCanConsumeItem}");

            foreach (Item data in this.basketDataList)
            {
                if (data.ID == item.ID)
                {
                    if (data.Qtd > 0 && KitchenController.petCanConsumeItem)
                    {
                        Debug.Log("Pet is not full hungry proceed with qtd--");
                        data.Qtd -= 1;

                        if (data.Qtd == 0)
                        {
                            item.ChangeMaterial(false);
                        }

                        if (onQuantityTextUpdate != null)
                        {
                            onQuantityTextUpdate(this.basketDataList);
                        }

                        //will tell the player that an updated in the hungry was done
                        if (onDecreaseItemQuantity != null)
                        {
                            onDecreaseItemQuantity(data.Amount);
                        }
                    }
                }
            }
        }

        public void Activate()
        {
            this.gameObject.SetActive(true);
        }

        public void Enable(List<Item> items)
        {
            this.ResetMaterial();
            this.InitiateBasketData(items);
            this.SpawnBasketItems();

            this.Activate();
        }
        private void OnDisable()
        {
            this.Disable();
        }

        public void Disable()
        {
            this.Deactivate();

            DespawnBasketItems();
        }

        public void Deactivate()
        {
            ResetMaterial();

            this.gameObject.SetActive(false);
        }

        public void SpawnBasketItems()
        {
            List<int> keys = this.itensToSpawn.Keys.ToList();

            for (int i = 0; i < keys.Count; i++)
            {
                var key = keys[i];

                var itemData = basketDataList.Find(x => x.ID == key);

                var clone = Instantiate(this.itensToSpawn[key], this.itemsPlace[i], false);

                clone.AddComponent(typeof(Candy));

                var candy = clone.GetComponent<Candy>();

                if (candy != null)
                {
                    candy.InitializeCandy(itemData.ID, itemData.Amount, this.itemMaterial);

                    if (itemData.Qtd <= 0)
                    {
                        candy.ChangeMaterial(false);
                    }
                }
            }
        }

        public void DespawnBasketItems()
        {         
            foreach (Transform itemTransform in this.itemsPlace)
            {
                var children = itemTransform.gameObject.GetComponentInChildren<Candy>();

                if(children != null)
                {
                    Destroy(children.gameObject);
                }              
            }
                      
            if(this.basketDataList.Count > 0)
            {
                this.basketDataList.Clear();
            }
            
            if(this.itensToSpawn.Count > 0)
            {
                this.itensToSpawn.Clear();
            }      
        }

        public void ResetMaterial()
        {
            foreach (GameObject obj in content)
            {
                obj.GetComponentInChildren<Renderer>().sharedMaterial = this.itemMaterial[0];
            }
        }
    }
}


