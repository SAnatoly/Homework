using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletPool : MonoBehaviour
    {

        [SerializeField]
        private int initialCount = 50;

        [SerializeField] private Transform container;
        public Bullet prefab;
        
        public LevelBounds levelBounds;

        public readonly Queue<Bullet> bulletPool = new();


        private void Awake()
        {
            for (var i = 0; i < this.initialCount; i++)
            {
                var _bullet = Instantiate(this.prefab, this.container);
                this.bulletPool.Enqueue(_bullet);
            }
        }


        public void RemoveBullet(Bullet _bullet, HashSet<Bullet> _activeBullets, BulletSystem _bulletSystem)
        {
            if (_activeBullets.Remove(_bullet))
            {
                _bullet.OnCollisionEntered -= _bulletSystem.OnBulletCollision;
                _bullet.transform.SetParent(this.container);
                this.bulletPool.Enqueue(_bullet);
            }
        }
    }
}

