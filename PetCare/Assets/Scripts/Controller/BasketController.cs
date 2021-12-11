using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour, IActivate
{
    [SerializeField]
    private GameObject[] content;

    [SerializeField]
    private Material emptyContent;

    [SerializeField]
    private Material originalMaterial;

    private Dictionary<int, GameObject> spawItems;

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

    public void InitiateBasketData()
    {
        spawItems = new Dictionary<int, GameObject>();

        var myEnum = Enum.GetValues(typeof(BasketItems));

        for (int i = 0; i < myEnum.Length; i++)
        {
            var enumItem = (int)myEnum.GetValue(i);

            spawItems.Add(enumItem, this.content[i]);
        }
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    public void Enable(Item[] items)
    {
        this.Activate();

        this.InitiateBasketData();
        this.SpawnBasketItems(items);
    }

    public void Disable()
    {
        this.Deactivate();

        resetMaterial();
    }


    public void SpawnBasketItems(Item[] items)
    {
        for (int i = 0; i < items.Length; i++)
        {
            GameObject itemToSpaw = this.spawItems[items[i].Id];
            this.originalMaterial = itemToSpaw.GetComponent<Renderer>().sharedMaterial;

            if (itemToSpaw != null)
            {
                if (items[i].Qtd <= 0)
                {
                    itemToSpaw.GetComponent<BoxCollider>().enabled = false;
                    itemToSpaw.GetComponent<Renderer>().sharedMaterial = this.emptyContent;
                }
     
                Instantiate(itemToSpaw);
            }
        }

        //a partir dos dados enviados da cozinha podemos selecionar qual dos itens estarão presentes na cesta, 
        //se houver items com qtd 0 vamos desabilitar o collider dele para que nao seja possivel seleciona-lo alem de mudar sua cor para mais opaco

    }

    public void resetMaterial()
    {
        foreach (GameObject obj in content)
        {
            obj.GetComponent<Renderer>().sharedMaterial = this.originalMaterial;
            obj.GetComponent<BoxCollider>().enabled = true;
        }      
    }
}
