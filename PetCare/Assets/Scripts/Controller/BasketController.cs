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

    void Start()
    {
        
    }

    void Update()
    {
        this.myRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(myRay, out hit))
        {
            Debug.DrawRay(myRay.origin, myRay.direction * 100, Color.blue, 100f);

            Debug.Log("entered in mouse button");

            Debug.Log(hit.transform.name);
            if (hit.collider != null)
            {

            }
        }
    }

    public void populateBasket()
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

        this.populateBasket();
        this.InitializeBasket(items);
    }


    public void InitializeBasket(Item[] items)
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

    public void OnDisable()
    {
        resetItemMaterial();
    }

    public void resetItemMaterial()
    {
        foreach (GameObject obj in content)
        {
            obj.GetComponent<Renderer>().sharedMaterial = this.originalMaterial;
        }
    }
}
