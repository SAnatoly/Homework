using System;
using ShootEmUp;
using UnityEngine;

namespace GameInput
{
    public class KeyboardInput: MonoBehaviour, IGameUpdateListener
    {
        public event Action OnFire;
        public event Action<Vector2> OnMove;
        private Vector2 diraction;
        public void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }
            
            OnMove?.Invoke(GetDiraction());
        }

        private Vector2 GetDiraction()
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow))       
                diraction = Vector2.left;
            
            if (Input.GetKeyUp(KeyCode.LeftArrow) && diraction == Vector2.left)       
                diraction = Vector2.zero;

            if(Input.GetKeyDown(KeyCode.RightArrow))
                diraction = Vector2.right;
            
            if(Input.GetKeyUp(KeyCode.RightArrow) && diraction == Vector2.right)
                diraction = Vector2.zero;

            return diraction;
        }
    }
}