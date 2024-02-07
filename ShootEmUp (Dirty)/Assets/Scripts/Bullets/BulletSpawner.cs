using UnityEngine;

namespace ShootEmUp
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Transform worldTransform;
        [SerializeField] private BulletPool bulletPool;
        public Bullet SpawnBullet()
        {
            Bullet bullet = bulletPool.GetBullet();
            bullet.transform.SetParent(this.worldTransform);
            return bullet;
        } 
    }
}

