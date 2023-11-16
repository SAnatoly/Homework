using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterObserver : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private CharacterController characterController;

        private void OnEnable()
        {
            this.character.GetComponent<HitPointsComponent>().hpEmpty += characterController.OnCharacterDeath;
        }

        private void OnDisable()
        {
            this.character.GetComponent<HitPointsComponent>().hpEmpty -= characterController.OnCharacterDeath;
        }
    }
}
