using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp
{
    public class GameCooldownLauncher : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private CountdownTimer countdownTimer;

        private void Awake()
        {
            countdownTimer.OnCompleted += StartGame;
        }

        private void StartGame()
        {
            
            gameManager.PlayingGame();
            countdownTimer.OnCompleted -= StartGame;
        }
    }
}

