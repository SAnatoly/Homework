using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterListener : MonoBehaviour
    {
        [SerializeField] CharacterController characterController;
        private void FixedUpdate()
        {
            if (characterController.fireRequired)
            {
                characterController.OnFlyBullet();
                characterController.fireRequired = false;
            }
        }
    }
}

