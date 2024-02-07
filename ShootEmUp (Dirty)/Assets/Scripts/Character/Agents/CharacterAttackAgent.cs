using UnityEngine;

namespace ShootEmUp
{
    public class CharacterAttackAgent 
    {
        [SerializeField] private WeaponComponent weapon;
        [Space]
        [SerializeField] private BulletSystem bulletSystem;
        [SerializeField] private BulletConfig bulletConfig;
 
        public void Shoot()
        {
            
            bulletSystem.SpawnBullet(new BulletArgs
            {
                isPlayer = true,
                physicsLayer = (int)bulletConfig.physicsLayer,
                color = bulletConfig.color,
                damage = bulletConfig.damage,
                position = weapon.position,
                velocity = weapon.rotation * Vector3.up * bulletConfig.speed
            });
        }
    }
}

