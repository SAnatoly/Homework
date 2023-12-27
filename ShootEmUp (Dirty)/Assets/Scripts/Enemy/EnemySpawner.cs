using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject character;

        [Header("Spawn")]
        [SerializeField] private EnemyPositions enemyPositions;
        [SerializeField] private Transform worldTransform;
        [SerializeField] private EnemyPool enemyPool;
        
        public GameObject SpawnEnemy()
        {
            var _enemy = enemyPool.GetEnemy();
            _enemy.transform.SetParent(this.worldTransform);

            var _spawnPosition = this.enemyPositions.RandomSpawnPosition();
            _enemy.transform.position = _spawnPosition.position;

            var _attackPosition = this.enemyPositions.RandomAttackPosition();
            _enemy.GetComponent<EnemyMoveAgent>().SetDestination(_attackPosition.position);

            _enemy.GetComponent<EnemyAttackAgent>().SetTarget(this.character);
            return _enemy;
        }
    }
}

