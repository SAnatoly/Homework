using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp
{
    public class StartButtonListener: MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private GameManager gameManager;

        private void Awake()
        {
            startButton.onClick.AddListener(StartTimer);
        }

        private void StartTimer()
        {
            //timer.StartCountdown();
            gameManager.StartGame();
            startButton.gameObject.SetActive(false);
            startButton.onClick.RemoveListener(StartTimer);
            
        }
    }
}