using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyCountdownSpawner : MonoBehaviour, Listeners.IGameStartListener, Listeners.IGamePauseListener, Listeners.IGameResumListener, Listeners.IGameFinishListener
    {
        [SerializeField] private int waitingSeconds;
        [SerializeField] private EnemyManager enemyManager;
        private void Awake()
        {
            enabled = false;
        }

        public void OnFinish()
        {
            enabled = false;
        }

        public void OnPause()
        {
            enabled = false;
        }

        public void OnResum()
        {
            enabled = true;
        }

        public void OnStart()
        {
            enabled = true;
            StartCoroutine(Spawn());
        }

        public IEnumerator Spawn()
        {
            while (true)
            {

                yield return new WaitForSeconds(waitingSeconds);
                enemyManager.SpawnEnemy();
            }
        }
    }
}

