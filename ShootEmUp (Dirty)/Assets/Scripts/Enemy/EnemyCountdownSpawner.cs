using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemyCountdownSpawner : MonoBehaviour
    {
        [SerializeField] private int waitingSeconds;
        [SerializeField] private EnemyManager enemyManager;
        public IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(waitingSeconds);
                enemyManager.SpawnEnemy();
            }
        }
    }
}

