using UnityEngine;

public class Candy : MonoBehaviour, IActivate 
{ 
    private int id;

    private Material[] sweetMaterial;

    private bool canBeSelected;

    private void Awake()
    {
        this.Deactivate();
    }

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
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    public void OnDestroy()
    {
        
    }

    public void InitializeCandy(int id, Material[] sweetMaterial)
    {
        this.ID = id;

        this.sweetMaterial = sweetMaterial;

        this.enabled = true;

        this.Activate();
    }

    public void ChangeMaterial(bool enabled)
    {
        if (enabled)
        {
            this.GetComponentInChildren<Renderer>().sharedMaterial = sweetMaterial[0];
        }
        else
        {
            this.GetComponentInChildren<Renderer>().sharedMaterial = sweetMaterial[1];
        }       
    }
}
