using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem : MonoBehaviour, Listeners.IGameStartListener, Listeners.IGameFinishListener, Listeners.IGamePauseListener, Listeners.IGameResumListener, Listeners.IGameFixedUpdate
    {
      
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();
        [SerializeField] BulletSpawner bulletSpawner;
        [SerializeField] BulletPool bulletPool;

        private void Awake()
        {
            enabled = false;
        }
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

        public void OnStart()
        {
            enabled = true;
        }

        public void OnFinish()
        {
            enabled = false;
        }

        public void OnPause()
        {
            enabled = false;
        }

        public void OnResum()
        {
            enabled = true;
        }

        public void OnFixedUpdate(float deltaTime)
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