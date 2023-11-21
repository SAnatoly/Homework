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
                var _enemy = Instantiate(this.prefab, this.container);
                this.enemyPool.Enqueue(_enemy);
            }
        }

        public void RemoveEnemy(GameObject _enemy)
        {
            _enemy.transform.SetParent(this.container);
            this.enemyPool.Enqueue(_enemy);
        }
    }
}