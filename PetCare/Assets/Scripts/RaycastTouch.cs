using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTouch : MonoBehaviour
{
    void Start()
    {
       
    }
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

}
