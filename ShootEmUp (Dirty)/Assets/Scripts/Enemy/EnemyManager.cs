using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{

    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner enemySpawner;
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private GameManager manager;
        [SerializeField] private BulletSystem bulletSystem;
        
        private readonly HashSet<GameObject> activeEnemies = new();

        public void SpawnEnemy()
        {
            var _enemy = enemySpawner.SpawnEnemy();
            
            if (this.activeEnemies.Add(_enemy)) 
            { 
                _enemy.GetComponent<HitPointsComponent>().OnHpEmpty += this.OnDestroyed;
                manager.AddListener(_enemy.GetComponent<EnemyMoveAgent>());
                manager.AddListener(_enemy.GetComponent<EnemyAttackAgent>());
                _enemy.GetComponent<EnemyAttackAgent>().GetBulletSystem(bulletSystem);
            }
            
        }
        private void OnDestroyed(GameObject _enemy)
        {
            if (activeEnemies.Remove(_enemy))
            {
                _enemy.GetComponent<HitPointsComponent>().OnHpEmpty -= this.OnDestroyed;

                enemyPool.RemoveEnemy(_enemy);
                manager.RemoveListener(_enemy.GetComponent<EnemyMoveAgent>());
                manager.RemoveListener(_enemy.GetComponent<EnemyAttackAgent>());
            }
        }

    }
}