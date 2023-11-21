using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Transform worldTransform;

        public Bullet SpawnBullet(Bullet _prefab, HashSet<Bullet> _activeBullets, BulletPool _bulletPool)
        {
            if (_bulletPool.bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(this.worldTransform);
            }
            else
            {
                bullet = Instantiate(_prefab, this.worldTransform);
            }

            return bullet;
        } 
    }
}

