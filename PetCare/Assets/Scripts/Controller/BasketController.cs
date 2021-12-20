using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasketController : MonoBehaviour, IActivate
{
    #region Private Fields

    [SerializeField]
    private GameObject[] content;

    [SerializeField]
    private Material[] itemMaterial;

    [SerializeField]
    private Transform[] itemsPlace;

    private List<ItemData> basketDataList;

    private Dictionary<int, GameObject> itensToSpawn;

    private Ray rayPosition;
    private RaycastHit hit;

    private int layer_Mask;

    private bool canConsumeItem;

    #endregion

    #region Events

    public delegate void OnNotifyDecreaseItemQuantity(int amount);
    public static event OnNotifyDecreaseItemQuantity OnNotifyItemQuantityDecreased;

    #endregion

    void Start()
    {
        this.layer_Mask = LayerMask.GetMask("Item");

        PetController.OnNotifyUpdatedHungry += CheckCanConsumeItem;
    }

    void Update()
    {
        this.rayPosition = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayPosition, out hit, 50, this.layer_Mask))
        {      
            if(Input.GetMouseButtonDown(0))
            {
                if (hit.collider != null)
                {
                    Debug.Log(hit.transform.name);
                    Debug.DrawRay(rayPosition.origin, rayPosition.direction * 20, Color.blue, 50f);

                    var sweet = hit.collider.GetComponent<Candy>();

                    if (sweet != null)
                    {
                        Debug.Log("clicking on the sweet");
                        UpdateItemQuantity(sweet);
                    }           
                }
            }     
        }
    }

    public void InitiateBasketData(List<ItemData> items)
    {
        this.itensToSpawn  = new Dictionary<int, GameObject>();

        //this will receive the reference from the list in the kitchen.
        this.basketDataList = new List<ItemData>(items);

        for (int i = 0; i < items.Count; i++)
        {
            var item = Array.Find(this.content, content => content.name.Contains(items[i].Name));

            if(item != null)
            {
                this.itensToSpawn.Add(items[i].ID, item);
            }   
        }
    }

    public void UpdateItemQuantity(Candy item)
    {
        Debug.Log($"updatequantity  canconsume= {this.canConsumeItem}");
        foreach (ItemData data in this.basketDataList)
        {
            if(data.ID == item.ID)
            {
                if(data.Qtd > 0 && this.canConsumeItem)
                {
                    Debug.Log("Pet is not full health presseg with qtd--");
                    data.Qtd -= 1;

                    if (data.Qtd == 0)
                    {
                        item.ChangeMaterial(false);
                    }

                    //will tell the player that an updated in the health was done
                    if (OnNotifyItemQuantityDecreased != null)
                    {
                        Debug.Log("Message to the player");
                        OnNotifyItemQuantityDecreased(data.Amount);
                    }
                }                
            }
        }
    }

    /*public List<string> getItemList(ItemData[] items)
    {
        var itemList = new List<string>();

        foreach(ItemData item in items)
        {
            itemList.Add(item.Name);
        }

        return itemList;
    }*/

    public void CheckCanConsumeItem(bool canConsume)
    {
        Debug.Log($"message received  canconsume= {canConsume}");
        this.canConsumeItem = canConsume;
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    public void Enable(List<ItemData> items)
    {
        this.Activate();

        this.ResetMaterial();
        this.InitiateBasketData(items);
        this.SpawnBasketItems();
    }

    public void Disable()
    {
        this.Deactivate();

        ResetMaterial();

        //DespawnBasketItems();
    }

    public void SpawnBasketItems()
    {
        List<int> keys = this.itensToSpawn.Keys.ToList();

        for(int i = 0; i < keys.Count; i++)
        {
            var key = keys[i];

            var itemData = basketDataList.Find(x => x.ID == key);

            var clone = Instantiate(this.itensToSpawn[key], itemsPlace[i], false);
            
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
        
    }

    public void ResetMaterial()
    {
        foreach (GameObject obj in content)
        {
            obj.GetComponentInChildren<Renderer>().sharedMaterial = this.itemMaterial[0];
        }      
    }
}
