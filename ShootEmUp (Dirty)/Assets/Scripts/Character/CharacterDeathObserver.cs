using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class CharacterDeathObserver : MonoBehaviour
    {
        [SerializeField] private GameObject character;
        [SerializeField] private GameManager gameManager;
        private void OnEnable()
        {
            this.character.GetComponent<HitPointsComponent>().hpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            this.character.GetComponent<HitPointsComponent>().hpEmpty -= OnCharacterDeath;
        }

        public void OnCharacterDeath(GameObject _)
        {
            gameManager.FinishGame();
        }
    }
}

