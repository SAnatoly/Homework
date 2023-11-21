using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveAgent : MonoBehaviour
    {
        [HideInInspector] public GameObject character;
        public float horizontalDirection { get;  set; }

        private void FixedUpdate()
        {
            this.character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(this.horizontalDirection, 0) * Time.fixedDeltaTime);
        }
    }
}

