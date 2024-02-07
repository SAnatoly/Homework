using UnityEngine;
using Zenject;

namespace ShootEmUp
{
    public class CharacterMoveAgent : ITickable
    {
        public float horizontalDirection { get;  set; }
        
        [SerializeField] private MoveComponent moveComponent;

        public CharacterMoveAgent(MoveComponent _moveComponent)
        {
            moveComponent = _moveComponent;
        }
       

        public void Tick()
        {
            moveComponent.Move(new Vector2(this.horizontalDirection, 0) * Time.fixedDeltaTime);
            Debug.Log("Move component");
        }
    }
}

