using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterAttackAgent : MonoBehaviour
    {
        public void OnFlyBullet(GameObject _character, BulletSystem _bulletSystem, BulletConfig _bulletConfig)
        {
            var weapon = _character.GetComponent<WeaponComponent>();
            _bulletSystem.SpawnBullet(new Args
            {
                isPlayer = true,
                physicsLayer = (int)_bulletConfig.physicsLayer,
                color = _bulletConfig.color,
                damage = _bulletConfig.damage,
                position = weapon.position,
                velocity = weapon.rotation * Vector3.up * _bulletConfig.speed
            });
        }
    }
}

