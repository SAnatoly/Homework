using GameInput;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterMoveController: MonoBehaviour, 
        IGameStartListener, 
        IGameFinishListener, 
        IGamePauseListener, 
        IGamePlayingListener
    {
        [SerializeField] private CharacterMoveAgent _moveAgent;
        [SerializeField] private KeyboardInput _input;
        public void OnStart()
        {
            _input.OnMove += Move;
        }

        public void OnPause()
        {
            _input.OnMove -= Move;
        }

        public void OnPlaying()
        {
            _input.OnMove += Move;
        }
        
        public void OnFinish()
        {
            _input.OnMove -= Move;
        }

        private void Move(Vector2 diraction)
        {
            _moveAgent.HorizontalDirection = diraction.x;
        }
    }
    
}