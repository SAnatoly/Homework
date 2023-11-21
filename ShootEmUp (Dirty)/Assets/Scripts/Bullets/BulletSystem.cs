using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour
    {
      
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();
        [SerializeField] BulletSpawner bulletSpawner;
        [SerializeField] BulletPool bulletPool;
        
        public void SpawnBullet(Args _args)
        {
           Bullet _bullet = bulletSpawner.SpawnBullet(bulletPool.prefab, activeBullets, bulletPool);

            _bullet.SetPosition(_args.position);
            _bullet.SetColor(_args.color);
            _bullet.SetPhysicsLayer(_args.physicsLayer);
            _bullet.damage = _args.damage;
            _bullet.isPlayer = _args.isPlayer;
            _bullet.SetVelocity(_args.velocity);

            if (activeBullets.Add(_bullet))
            {
                _bullet.OnCollisionEntered += this.OnBulletCollision;
            }
        }

       
        
        public void OnBulletCollision(Bullet _bullet, Collision2D _collision)
        {
            BulletDamage.DealDamage(_bullet, _collision.gameObject);
            bulletPool.RemoveBullet(_bullet, activeBullets, this);
        }

        private void FixedUpdate()
        {
            this.cache.Clear();
            this.cache.AddRange(this.activeBullets);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var _bullet = this.cache[i];
                if (!bulletPool.levelBounds.InBounds(_bullet.transform.position))
                {
                    bulletPool.RemoveBullet(_bullet, activeBullets, this);
                }
            }
        }


    }

    public struct Args
    {
        public Vector2 position;
        public Vector2 velocity;
        public Color color;
        public int physicsLayer;
        public int damage;
        public bool isPlayer;
    }
}