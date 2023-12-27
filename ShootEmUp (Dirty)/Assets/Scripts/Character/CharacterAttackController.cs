using GameInput;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterAttackController: MonoBehaviour, 
        IGameStartListener, 
        IGameFinishListener, 
        IGamePauseListener, 
        IGamePlayingListener
    {
        [SerializeField] private CharacterAttackAgent _attackAgent;
        [SerializeField] private KeyboardInput _input;
      
        
        public void OnStart()
        {
            _input.OnFire += Attack;
        }
        
        public void OnPause()
        {
            _input.OnFire -= Attack;
        }

        public void OnPlaying()
        {
            _input.OnFire += Attack;
        }

        public void OnFinish()
        {
            _input.OnFire -= Attack;
        }

        private void Attack()
        {
            _attackAgent.Shoot();
        }
    }
}