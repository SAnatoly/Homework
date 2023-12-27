using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : MonoBehaviour
    {
        [SerializeField] private int countEnemy = 7;

        [Header("Pool")]
        [SerializeField]
        private Transform container;

        [SerializeField]
        private GameObject prefab;

        public readonly Queue<GameObject> enemyPool = new();
        
        private void Awake()
        {
            for (var i = 0; i < countEnemy; i++)
            {
                SpawnAndAddEnemyPool();
            }
        }

        
        public GameObject SpawnAndAddEnemyPool()
        {
            var _enemy = Instantiate(this.prefab, this.container);
            this.enemyPool.Enqueue(_enemy);
            return _enemy;
        }

        public GameObject GetEnemy()
        {
            if (enemyPool.TryDequeue(out GameObject enemy))
                return enemy;
            
            return SpawnAndAddEnemyPool();
        }
        public void RemoveEnemy(GameObject _enemy)
        {
            _enemy.transform.SetParent(this.container);
            this.enemyPool.Enqueue(_enemy);
        }
    }
}