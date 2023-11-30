using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class TimerManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private CountdownTime countdownTime;
        private bool canStart;
        // Start is called before the first frame update
        void Start()
        {

        }

        public void StartTimer()
        {
            StartCoroutine(countdownTime.Countdown());
        }

        // Update is called once per frame
        void Update()
        {
            if(countdownTime.timeIsOn == true)
            {
                countdownTime.timeIsOn = false;
                gameManager.OnStart();
            }
        }
    }
}

