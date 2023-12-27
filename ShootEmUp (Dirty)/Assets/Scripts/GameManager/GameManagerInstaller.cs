using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(GameManager))]
    public class GameManagerInstaller : MonoBehaviour
    {
        private void Awake()
        {
            var manager = GetComponent<GameManager>();
           manager.AddListeners(gameObject);
        }
    }
}

