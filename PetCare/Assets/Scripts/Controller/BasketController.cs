using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasketController : MonoBehaviour, IActivate
{
    [SerializeField]
    private GameObject[] content;

    [SerializeField]
    private Material emptyContent;

    [SerializeField]
    private Material originalMaterial;

    [SerializeField]
    private Transform[] itemsPlace;

    private Dictionary<int, GameObject> spawnItems;

    private Ray myRay;
    private RaycastHit hit;

    private int layer_Mask;

    void Start()
    {
        this.layer_Mask = LayerMask.GetMask("Item");
    }

    void Update()
    {
        this.myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(myRay, out hit, 50, this.layer_Mask))
        {      
            if(Input.GetMouseButtonDown(0))
            {
                if (hit.collider != null)
                {
                    Debug.Log(hit.transform.name);
                    Debug.DrawRay(myRay.origin, myRay.direction * 20, Color.blue, 50f);
                }
            }     
        }
    }

    public void InitiateBasketData(ItemData[] items)
    {
        this.spawnItems  = new Dictionary<int, GameObject>();

        for (int i = 0; i < items.Length; i++)
        {
            var item = Array.Find(this.content, content => content.name.Contains(items[i].Name));

            if(item != null)
            {
                this.spawnItems.Add(items[i].ID, item);
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

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    public void Enable(ItemData[] items)
    {
        this.Activate();

        this.resetMaterial();
        this.InitiateBasketData(items);
        this.SpawnBasketItems(items);
    }

    public void Disable()
    {
        this.Deactivate();

        resetMaterial();

        //DespawnBasketItems();
    }

    public void SpawnBasketItems(ItemData[] items)
    {
        List<int> keys = this.spawnItems.Keys.ToList();

        for(int i = 0; i < keys.Count; i++)
        {
            var key = keys[i];
            var itemData = Array.Find(items, x => x.ID == key);

            var clone = Instantiate(this.spawnItems[key], itemsPlace[i], false);

            if (itemData.Qtd <= 0)
            {
                clone.GetComponentInChildren<BoxCollider>().enabled = false;
                clone.GetComponentInChildren<Renderer>().sharedMaterial = this.emptyContent;
            }
            
            clone.AddComponent(typeof(Candie));

            var candy = clone.GetComponent<Candie>();

            if (candy != null)
            {
                candy.InitializeCandie(key);
            }      
        }

        //a partir dos dados enviados da cozinha podemos selecionar qual dos itens estarão presentes na cesta, 
        //se houver items com qtd 0 vamos desabilitar o collider dele para que nao seja possivel seleciona-lo alem de mudar sua cor para mais opaco
    }

    public void DespawnBasketItems()
    {
        
    }

    public void resetMaterial()
    {
        foreach (GameObject obj in content)
        {
            obj.GetComponentInChildren<Renderer>().sharedMaterial = this.originalMaterial;
            obj.GetComponentInChildren<BoxCollider>().enabled = true;
        }      
    }
}
