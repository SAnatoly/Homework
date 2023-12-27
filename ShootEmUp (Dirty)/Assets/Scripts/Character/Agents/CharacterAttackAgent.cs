using UnityEngine;

namespace ShootEmUp
{
    public class CharacterAttackAgent : MonoBehaviour
    {
        [SerializeField] private WeaponComponent _weapon;
        [Space]
        [SerializeField] private BulletSystem _bulletSystem;
        [SerializeField] private BulletConfig _bulletConfig;
 
        public void Shoot()
        {
            
            _bulletSystem.SpawnBullet(new BulletArgs
            {
                isPlayer = true,
                physicsLayer = (int)_bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = _weapon.position,
                velocity = _weapon.rotation * Vector3.up * _bulletConfig.speed
            });
        }
    }
}

