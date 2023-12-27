using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Transform worldTransform;
        [SerializeField] private BulletPool _bulletPool;
        public Bullet SpawnBullet()
        {
            Bullet bullet = _bulletPool.GetBullet();
            bullet.transform.SetParent(this.worldTransform);
            return bullet;
        } 
    }
}

