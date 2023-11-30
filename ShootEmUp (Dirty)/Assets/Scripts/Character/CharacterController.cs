using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour, Listeners.IGamePauseListener, Listeners.IGameResumListener, Listeners.IGameStartListener, Listeners.IGameFinishListener, Listeners.IGameUpdate
    {
        [SerializeField] private GameObject character; 
        [SerializeField] private GameManager gameManager;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;
        [SerializeField] private CharacterAttackAgent characterAttackAgent;
        [SerializeField] private CharacterMoveAgent characterMoveAgent;

        private void Awake()
        {
            enabled = false;
        }

        public void OnUpdate(float deltaTime)
        {
            Debug.Log("Update");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterAttackAgent.OnFlyBullet(character, bulletSystem, bulletConfig);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                characterMoveAgent.horizontalDirection = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                characterMoveAgent.horizontalDirection = 1;
            }
            else
            {
                characterMoveAgent.horizontalDirection = 0;
            }
        }

        public void OnPause()
        {
            enabled = false;
        }

        public void OnResum()
        {
            enabled = true;
        }

        public void OnStart()
        {

            enabled = true;
            characterMoveAgent.character = character;
        }

        public void OnFinish()
        {
            enabled = false;
        }
    }
}