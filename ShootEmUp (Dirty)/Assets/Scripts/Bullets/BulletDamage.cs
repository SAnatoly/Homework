using UnityEngine;

namespace ShootEmUp
{
    internal static class BulletDamage
    {
        internal static void DealDamage(Bullet _bullet, GameObject _other)
        {
            if (!_other.TryGetComponent(out TeamComponent _team))
            {
                return;
            }

            if (_bullet.isPlayer == _team.IsPlayer)
            {
                return;
            }

            if (_other.TryGetComponent(out HitPointsComponent _hitPoints))
            {
                _hitPoints.TakeDamage(_bullet.damage);
            }
        }
    }
}