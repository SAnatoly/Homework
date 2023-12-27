using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour, 
        IGamePauseListener,
        IGamePlayingListener
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public bool IsPlayer { get; set; }
        public int Damage { get; set; }

        [SerializeField]
        private new Rigidbody2D rigidbody2D;

        [SerializeField]
        private SpriteRenderer spriteRenderer;


        private Vector2 oldVelocity;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            this.OnCollisionEntered?.Invoke(this, collision);
            
            if (!collision.transform.TryGetComponent(out TeamComponent _team))
            {
                return;
            }

            if (IsPlayer == _team.IsPlayer)
            {
                return;
            }

            if (collision.transform.TryGetComponent(out HitPointsComponent _hitPoints))
            {
                _hitPoints.TakeDamage(Damage);
            }
        }

        public void SetVelocity(Vector2 velocity)
        {
            this.rigidbody2D.velocity = velocity;
        }

        public void SetPhysicsLayer(int physicsLayer)
        {
            this.gameObject.layer = physicsLayer;
        }

        public void SetPosition(Vector3 position)
        {
            this.transform.position = position;
        }

        public void SetColor(Color color)
        {
            this.spriteRenderer.color = color;
        }

        public void OnPause()
        {
            oldVelocity = rigidbody2D.velocity;
            SetVelocity(Vector2.zero);
        }

        public void OnPlaying()
        {
            SetVelocity(oldVelocity);
        }
    }
}