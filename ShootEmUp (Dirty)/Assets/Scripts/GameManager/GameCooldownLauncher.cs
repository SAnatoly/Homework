using UnityEngine;

namespace ShootEmUp
{
    public class GameCooldownLauncher : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private CountdownTimer countdownTimer;

        private void Awake()
        {
            countdownTimer.completed += StartGame;
        }

        private void StartGame()
        {
            
            gameManager.PlayingGame();
            countdownTimer.completed -= StartGame;
        }
    }
}

