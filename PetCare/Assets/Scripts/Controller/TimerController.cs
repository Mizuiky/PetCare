using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public delegate void DecreaseStatus();
    public static DecreaseStatus OnDecreasedStatus;

    [SerializeField]
    private float timeToDecreaseStatus;

    void Start()
    {
        StartCoroutine(Timer());
    }

    
    void Update()
    {
        
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("waiting until start began");

        while (true)
        {
            yield return new WaitForSeconds(this.timeToDecreaseStatus);
            Debug.Log("Time to decrease");
            OnDecreasedStatus();
        }     
    }
}
