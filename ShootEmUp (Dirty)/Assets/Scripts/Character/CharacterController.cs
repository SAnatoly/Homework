using UnityEngine;

namespace ShootEmUp
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private BulletPool bulletPool;
        [SerializeField] private BulletConfig bulletConfig;
        [SerializeField] private GameObject character;
        public bool fireRequired;

       

        public void OnCharacterDeath(GameObject gameManager) => this.gameManager.FinishGame();

       

        public void OnFlyBullet()
        {
            var weapon = this.character.GetComponent<WeaponComponent>();
            bulletPool.SpawnBullet(new Args
            {
                isPlayer = true,
                physicsLayer = (int) this.bulletConfig.physicsLayer,
                color = this.bulletConfig.color,
                damage = this.bulletConfig.damage,
                position = weapon.Position,
                velocity = weapon.Rotation * Vector3.up * this.bulletConfig.speed
            });
        }
    }
}