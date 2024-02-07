using TMPro;
using UnityEngine;

namespace ShootEmUp
{
    public class VisualisateCountdownTimer: MonoBehaviour, 
        IGameStartListener, 
        IGamePlayingListener
    {
        [SerializeField] private CountdownTimer timer;
        [SerializeField] private TMP_Text text;

        public void Awake()
        {
            timer.changeTime += UpdateText;
            text.text = timer.GetTime().ToString();
        }

        public void UpdateText()
        {
            text.text = timer.GetTime().ToString();
        }

        public void OnStart()
        {
            text.gameObject.SetActive(true);
            Debug.Log("Start time");
        }

        public void OnPlaying()
        {
            text.gameObject.SetActive(false);
        }
    }
}