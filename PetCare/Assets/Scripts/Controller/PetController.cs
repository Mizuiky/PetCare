using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour, IActivate
{
    #region Private Fields

    [SerializeField]
    private float rotationAmount;
    private PetStatus status;

    [SerializeField]
    private int amount;

    #endregion


    #region Test Fields

    [SerializeField]
    private int initialHungry;
    [SerializeField]
    private int maxHungry;

    [SerializeField]
    private int initialHappiness;  
    [SerializeField]
    private int maxHappiness;

    #endregion

    #region Public Fields


    #endregion


    #region Events

    public delegate void OnChangeStatus (PetStatus status);
    public static event OnChangeStatus OnChangedStatus;

    #endregion

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);
    }

    void Start()
    {
        this.status = new PetStatus();
        this.SetInitialStatus();

        if(OnChangedStatus != null)
        {
            //Debug.Log("start to change status");
            OnChangedStatus(this.status);
        }
        
        TimerController.OnDecreasedStatus += ModifyStatus;

        EventClickController.OnPlayerRotated += RotatePlayer;

        this.Activate();       
    }

    // Update is called once per frame
    void Update()
    {  

    }
    void OnDisable()
    {
        TimerController.OnDecreasedStatus -= ModifyStatus;

        EventClickController.OnPlayerRotated -= RotatePlayer;
        this.Deactivate();
    }

    private void SetInitialStatus()
    {
        this.status.maxHungry = this.maxHungry;
        this.status.maxHappiness = this.maxHappiness;

        this.status.hungry = this.initialHungry;
        this.status.happiness = this.initialHappiness;
    }

    private void ModifyStatus()
    {
        this.DecreaseStatus(this.amount);

        if (OnChangedStatus != null)
        {
            OnChangedStatus(this.status);
        }
    }

    private void IncreaseStatus(int amount)
    {
        this.status.hungry += amount;
        this.status.happiness += amount;
        
        this.status.hungry = Mathf.Min(this.maxHungry, this.status.hungry);
        this.status.happiness = Mathf.Min(this.maxHappiness, this.status.happiness);
    }

    private void DecreaseStatus(int amount)
    {
        this.status.hungry -= amount;
        this.status.happiness -= amount;

        this.status.hungry = Mathf.Max(0, this.status.hungry);
        this.status.happiness = Mathf.Max(0, this.status.happiness);
    }

    #region Player Rotation
    public void RotatePlayer(bool rightSide)
    {
        if (!rightSide)
        {
            this.transform.Rotate(- new Vector3(0, rotationAmount, 0));
        }
        else
        {
            this.transform.Rotate(new Vector3(0, rotationAmount, 0));
        } 
    }

    #endregion
}
