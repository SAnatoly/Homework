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
        public GameManager gameManager;
        public LevelBounds levelBounds;

        private readonly Queue<Bullet> bulletPool = new();


        private void Awake()
        {
            for (var i = 0; i < this.initialCount; i++)
            {
               SpawnBullet();
            }
        }

        private Bullet SpawnBullet()
        {
            var _bullet = Instantiate(this.prefab, this.container);
            this.bulletPool.Enqueue(_bullet);
            gameManager.AddListener(_bullet);
            return _bullet;
        }
        
        public Bullet GetBullet()
        {
            if (bulletPool.TryDequeue(out Bullet bullet))
                return bullet;
            
            return SpawnBullet();
        }
        
        public void RemoveBullet(Bullet _bullet)
        {
            _bullet.transform.SetParent(this.container);
            this.bulletPool.Enqueue(_bullet);
            gameManager.RemoveListener(_bullet);
        }
    }
}

