using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveAgent : MonoBehaviour,
        IGameFixedUpdateListener
    {
        public float HorizontalDirection { get;  set; }
        
        [SerializeField] private MoveComponent moveComponent;
        public void OnFixedUpdate(float deltaTime)
        {
            moveComponent.Move(new Vector2(this.HorizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}

