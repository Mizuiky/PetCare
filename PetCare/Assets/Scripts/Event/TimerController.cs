using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PetCare
{
    public class TimerController : MonoBehaviour
    {
        public delegate void OnDecreaseStatus();
        public static OnDecreaseStatus onDecreaseStatus;

        [SerializeField]
        private float timeToDecreaseStatus;

        void Start()
        {
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(2f);
            //Debug.Log("waiting until start");

            while (true)
            {
                yield return new WaitForSeconds(this.timeToDecreaseStatus);
                //Debug.Log("Time to decrease");
                
                if(onDecreaseStatus != null)
                {
                    onDecreaseStatus();
                }          
            }
        }
    }
}


