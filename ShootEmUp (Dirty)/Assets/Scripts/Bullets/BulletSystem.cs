using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour,
        IGameFixedUpdateListener
    {
      
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();
        [SerializeField] BulletSpawner bulletSpawner;
        [SerializeField] BulletPool bulletPool;

        public void OnFixedUpdate(float deltaTime)
        {
            this.cache.Clear();
            this.cache.AddRange(this.activeBullets);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                Bullet _bullet = this.cache[i];
                if (!bulletPool.levelBounds.InBounds(_bullet.transform.position))
                {
                    RemoveBullet(_bullet);
                }
            }
        }
        
        public void SpawnBullet(BulletArgs bulletArgs)
        {
           Bullet _bullet = bulletSpawner.SpawnBullet();

            _bullet.SetPosition(bulletArgs.position);
            _bullet.SetColor(bulletArgs.color);
            _bullet.SetPhysicsLayer(bulletArgs.physicsLayer);
            _bullet.Damage = bulletArgs.damage;
            _bullet.IsPlayer = bulletArgs.isPlayer;
            _bullet.SetVelocity(bulletArgs.velocity);

            if (activeBullets.Add(_bullet))
            {
                _bullet.OnCollisionEntered += this.OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet _bullet, Collision2D _collision)
        {
           
            RemoveBullet(_bullet);
        }

        private void RemoveBullet(Bullet _bullet)
        {
            
            if (activeBullets.Remove(_bullet))
                return;
            
            bulletPool.RemoveBullet(_bullet);
            _bullet.OnCollisionEntered -= OnBulletCollision;
            
        }
    }
}