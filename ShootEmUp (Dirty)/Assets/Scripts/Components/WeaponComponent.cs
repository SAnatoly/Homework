using UnityEngine;

namespace ShootEmUp
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public Vector2 position
        {
            get { return this.firePoint.position; }
        }

        public Quaternion rotation
        {
            get { return this.firePoint.rotation; }
        }

        [SerializeField]
        private Transform firePoint;
    }
}