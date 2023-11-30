using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour, 
        Listeners.IGamePauseListener, 
        Listeners.IGameResumListener, 
        Listeners.IGameFinishListener, 
        Listeners.IGameFixedUpdate
    {
        public delegate void FireHandler(GameObject enemy, Vector2 position, Vector2 direction);

        public event FireHandler OnFire;

        [SerializeField] private WeaponComponent weaponComponent;
        [SerializeField] private EnemyMoveAgent moveAgent;
        [SerializeField] private float countdown;

        private GameObject target;
        private float currentTime;

        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        public void Reset()
        {
            this.currentTime = this.countdown;
        }

        private void Fire()
        {
            var startPosition = this.weaponComponent.position;
            var vector = (Vector2) this.target.transform.position - startPosition;
            var direction = vector.normalized;
            this.OnFire?.Invoke(this.gameObject, startPosition, direction);
        }

        public void OnFixedUpdate(float deltaTime)
        {
            if (!this.moveAgent.IsReached)
            {
                return;
            }

            if (!this.target.GetComponent<HitPointsComponent>().IsHitPointsExists())
            {
                return;
            }

            this.currentTime -= Time.fixedDeltaTime;
            if (this.currentTime <= 0)
            {
                this.Fire();
                this.currentTime += this.countdown;
            }
        }

        public void OnFinish()
        {
            enabled = false;
        }

        public void OnResum()
        {
            enabled = true;
        }

        public void OnPause()
        {
            enabled = false;
        }
    }
}