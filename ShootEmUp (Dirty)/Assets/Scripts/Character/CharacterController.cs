using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject character; 
        [SerializeField] private GameManager gameManager;
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;
        [SerializeField] private CharacterAttackAgent characterAttackAgent;
        [SerializeField] private CharacterMoveAgent characterMoveAgent;


        public void Start()
        {
            characterMoveAgent.character = character;
        }

        private void Update()
        {
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

    }
}