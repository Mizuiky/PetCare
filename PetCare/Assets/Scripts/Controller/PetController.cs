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
    public static event OnChangeStatus onChangeStatus;

    public delegate void OnHungryUpdate(bool canConsume);
    public static event OnHungryUpdate onHungryUpdate;

    #endregion

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        TimerController.onDecreaseStatus -= DecreaseStatus;

        BasketController.onDecreaseItemQuantity -= IncreaseHungry;

        EventClickController.onPlayerRotation -= RotatePlayer;

        this.gameObject.SetActive(false);
    }

    void Start()
    {
        this.status = new PetStatus();
        this.SetInitialStatus();

        if(onChangeStatus != null)
        {
            //Debug.Log("start to change status");
            onChangeStatus(this.status);
        }

        this.Activate();

        CheckCanConsumeItem();

        TimerController.onDecreaseStatus += DecreaseStatus;

        BasketController.onDecreaseItemQuantity += IncreaseHungry;

        EventClickController.onPlayerRotation += RotatePlayer;
    }

    // Update is called once per frame
    void Update()
    {  

    }
    void OnDisable()
    {
        this.Deactivate();
    }

    private void SetInitialStatus()
    {
        Debug.Log("setting initial status");

        this.status.maxHungry = this.maxHungry;
        this.status.maxHappiness = this.maxHappiness;

        this.status.hungry = this.initialHungry;
        this.status.happiness = this.initialHappiness;
    }

    private void DecreaseStatus()
    {
        this.DecreaseHungry();

        this.DecreaseHappiness();

        if (onChangeStatus != null)
        {
            onChangeStatus(this.status);
        }

        CheckCanConsumeItem();
    }

    private void DecreaseHungry()
    {
        this.status.hungry -= this.amount;
        this.status.hungry = Mathf.Max(0, this.status.hungry);
    }
    private void DecreaseHappiness()
    {
        this.status.happiness -= this.amount;
        this.status.happiness = Mathf.Max(0, this.status.happiness);
    }

    private void IncreaseHungry(int amount)
    {
        Debug.Log("trying to increase");
        if (CheckCanConsumeItem())    
        {
            this.status.hungry += amount;
            this.status.hungry = Mathf.Min(this.maxHungry, this.status.hungry);

            Debug.Log("increased hungry");

            CheckCanConsumeItem();

            if (onChangeStatus != null)
            {
                onChangeStatus(this.status);
            }
        }     
    }

    private bool CheckCanConsumeItem()
    {
        Debug.Log("check full hungry");
        var canConsume = true;

        if (this.status.hungry == this.maxHungry)
        {
            Debug.Log("is full hungry");
            canConsume = false;
        }

        if(onHungryUpdate != null)
        {
            Debug.Log("notify update");
            onHungryUpdate(canConsume);
        }
       
        return canConsume;      
    }

    private void IncreaseHappiness(int amount)
    {
        this.status.happiness += this.amount;
        this.status.happiness = Mathf.Min(this.maxHappiness, this.status.happiness);
    }

    #region Player Rotation
    public void RotatePlayer(bool rightSide)
    {
        if (rightSide)
        {
            this.transform.Rotate(-new Vector3(0, rotationAmount, 0));    
            Debug.Log("rotate right");
        }
        else
        {
            Debug.Log("rotate left");
            this.transform.Rotate(new Vector3(0, rotationAmount, 0));
        } 
    }

    #endregion
}
