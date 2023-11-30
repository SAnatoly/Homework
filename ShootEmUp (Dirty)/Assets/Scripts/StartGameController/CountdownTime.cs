using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTime : MonoBehaviour
{
    [SerializeField] private int countdownValue;
    public bool timeIsOn;
    public IEnumerator Countdown()
    { 
        while(countdownValue > 0)
        {
            yield return new WaitForSeconds(1);
            countdownValue--;
        }
        timeIsOn = true;
    }
}
