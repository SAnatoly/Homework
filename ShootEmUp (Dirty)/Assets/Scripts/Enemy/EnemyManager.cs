using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{

    public sealed class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner enemySpawner;
        [SerializeField] private EnemyPool enemyPool;

        [SerializeField]
        private BulletSystem bulletSystem;
        
        private readonly HashSet<GameObject> activeEnemies = new();

        public void SpawnEnemy()
        {
            var _enemy = enemySpawner.SpawnEnemy();
            if (_enemy != null)
            {
                if (this.activeEnemies.Add(_enemy))
                {
                    _enemy.GetComponent<HitPointsComponent>().hpEmpty += this.OnDestroyed;
                    _enemy.GetComponent<EnemyAttackAgent>().OnFire += this.OnFire;
                }
            }
        }
        private void OnDestroyed(GameObject _enemy)
        {
            if (activeEnemies.Remove(_enemy))
            {
                _enemy.GetComponent<HitPointsComponent>().hpEmpty -= this.OnDestroyed;
                _enemy.GetComponent<EnemyAttackAgent>().OnFire -= this.OnFire;

                enemyPool.RemoveEnemy(_enemy);
            }
        }

        private void OnFire(GameObject _enemy, Vector2 _position, Vector2 _direction)
        {
            bulletSystem.SpawnBullet(new Args
            {
                isPlayer = false,
                physicsLayer = (int) PhysicsLayer.ENEMY,
                color = Color.red,
                damage = 1,
                position = _position,
                velocity = _direction * 2.0f
            });
        }
    }
}