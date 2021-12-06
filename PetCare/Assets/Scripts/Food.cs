using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IBaseFood, IActivate
{
    public GameObject food;
    public string foodName;
    
    public int healthAmount;
    public int FilledAmount
    { 
        get
        {
            return healthAmount;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void instantiateFood()
    {
        Debug.Log("intantiating... " + foodName);

    }

    public void Activate()
    {
        food.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        food.gameObject.SetActive(false);
    }
}
