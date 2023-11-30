using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace ShootEmUp
{

    public enum GameState
    {
        None,
        Start,
        Pause,
        Resume,
        Finish
    }

    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField, ReadOnly] private GameState gameState;

        public List<Listeners.IGameListener> listeners = new();
        private List<Listeners.IGameUpdate> updateListeners = new();
        private List<Listeners.IGameLateUpdate> lateUpdateListeners = new();
        private List<Listeners.IGameFixedUpdate> fixedUpdateListeners = new();
        public void AddListtteners(Listeners.IGameListener listener)
        {
            listeners.Add(listener);
            Debug.Log("Update");
            if (listener is Listeners.IGameUpdate updateListener)
            {
                updateListeners.Add(updateListener);
                Debug.Log("Update");
            }

            if (listener is Listeners.IGameLateUpdate lateUpdateListener)
            {
                lateUpdateListeners.Add(lateUpdateListener);
                Debug.Log("Late");
            }

            if (listener is Listeners.IGameFixedUpdate fixedUpdateListener)
            {
                fixedUpdateListeners.Add(fixedUpdateListener);
                Debug.Log("Fixed");
            }
        }

        
        public void OnStart()
        {
            foreach(var gameListeners in listeners)
            {
                if(gameListeners is Listeners.IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }
            gameState = GameState.Start;
        }

        public void OnPause()
        {
            foreach (var gameListeners in listeners)
            {
                if (gameListeners is Listeners.IGamePauseListener startListener)
                {
                    Debug.Log("Pause");
                    startListener.OnPause();
                }
            }
            gameState = GameState.Pause;
        }

        public void OnResum()
        {
            foreach (var gameListeners in listeners)
            {
                if (gameListeners is Listeners.IGameResumListener startListener)
                {
                    startListener.OnResum();
                }
            }
            gameState = GameState.Resume;
        }

        public void OnFinish()
        {
            foreach (var gameListeners in listeners)
            {
                if (gameListeners is Listeners.IGameFinishListener startListener)
                {
                    startListener.OnFinish();
                }
            }
            gameState = GameState.Finish;
        }

        
        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

        public void Update()
        {
            for (int i = 0; i < updateListeners.Count; i++)
            {
                updateListeners[i].OnUpdate(Time.deltaTime);
               
            }
        }

        public void LateUpdate()
        {
            for (int i = 0; i < lateUpdateListeners.Count; i++)
            {
                lateUpdateListeners[i].OnLateUpdate(Time.deltaTime);
            }
        }

        public void FixedUpdate()
        {
            for (int i = 0; i < fixedUpdateListeners.Count; i++)
            {
                fixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
                
            }
        }
    }
}