using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : Bullet
    {
      
        [SerializeField] private LevelBounds levelBounds;

        public BulletPool bulletPool;
        private void FixedUpdate()
        {
            for (int i = 0, count = bulletPool.m_cache.Count; i < count; i++)
            {
                var bullet = bulletPool.m_cache[i];
                if (!this.levelBounds.InBounds(bullet.transform.position))
                {
                    bulletPool.RemoveBullet(bullet);
                }
            }
        }


        public void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            BulletUtils.DealDamage(bullet, collision.gameObject);
            bulletPool.RemoveBullet(bullet);
        }  
    }
}