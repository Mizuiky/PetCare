using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candie : MonoBehaviour, IActivate
{
    private int id;

    public int ID
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }
    public void Activate()
    {
        throw new System.NotImplementedException();
    }

    public void Deactivate()
    {
        throw new System.NotImplementedException();
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void InitializeCandie(int id)
    {
        this.ID = id;
    }


}
