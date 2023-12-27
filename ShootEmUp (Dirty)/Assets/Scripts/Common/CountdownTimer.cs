using System.Collections;
using System;
using System.Collections.Generic;
using ShootEmUp;
using UnityEngine;

public class CountdownTimer : MonoBehaviour,
    IGameStartListener
{
    public event Action OnCompleted;
    public event Action OnChangeTime;
    [SerializeField] private int countdownValue;

    public void OnStart()
    {
        StartCoroutine(nameof(CountdownCoroutine));
    }

    public IEnumerator CountdownCoroutine()
    { 
        while(countdownValue > 0)
        {
            yield return new WaitForSeconds(1);
            countdownValue--;
            OnChangeTime.Invoke();
        }
        
        OnCompleted?.Invoke();
    }

    public int GetTime()
    {
        return countdownValue;
    }
}
