using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTouch : MonoBehaviour
{
    [SerializeField]
    private GameObject[] food;

    private Vector3 touchPosWorld;

    private TouchPhase touchPhase = TouchPhase.Ended;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("entered in mouse button");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {
                    Food touchedFood = hit.transform.gameObject.GetComponent<Food>();                 
                    touchedFood.instantiateFood();
                }
            }
        }
    }

    public void InstantiateFood(Collider food)
    {
       
    }
}
