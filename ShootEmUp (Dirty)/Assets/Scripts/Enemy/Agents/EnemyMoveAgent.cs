using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour,  
        Listeners.IGamePauseListener, 
        Listeners.IGameResumListener, 
        Listeners.IGameFinishListener, 
        Listeners.IGameFixedUpdate
    {
      
        public bool IsReached
        {
            get { return this.isReached; }
        }

        [SerializeField] private MoveComponent moveComponent;

        private Vector2 destination;

        private bool isReached;

        public void SetDestination(Vector2 endPoint)
        {
            this.destination = endPoint;
            this.isReached = false;
        }

        public void OnPause()
        {
            enabled = false;
        }

        public void OnResum()
        {
            enabled = true;
        }

        public void OnFinish()
        {
            enabled = false;
        }

        public void OnFixedUpdate(float time)
        {
            Debug.Log("1");
            if (this.isReached)
            {
                return;
            }

            Debug.Log("2");
            var vector = this.destination - (Vector2)this.transform.position;
            if (vector.magnitude <= 0.25f)
            {
                this.isReached = true;
                return;
            }
            Debug.Log("3");
            var direction = vector.normalized * Time.fixedDeltaTime;
            this.moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}