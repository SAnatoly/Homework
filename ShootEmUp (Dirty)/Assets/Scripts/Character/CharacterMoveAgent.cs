using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveAgent : MonoBehaviour,
                                        Listeners.IGameStartListener,
                                        Listeners.IGamePauseListener,
                                        Listeners.IGameResumListener,
                                        Listeners.IGameFixedUpdate
    {
        [HideInInspector] public GameObject character;
        public float horizontalDirection { get;  set; }

        private void Awake()
        {
            enabled = false;
        }
        public void OnFixedUpdate(float deltaTime)
        {
            this.character.GetComponent<MoveComponent>().MoveByRigidbodyVelocity(new Vector2(this.horizontalDirection, 0) * Time.fixedDeltaTime);
        }

      
        public void OnStart()
        {
            enabled = true;
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

    }
}

