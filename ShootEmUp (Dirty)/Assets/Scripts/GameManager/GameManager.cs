using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField, ReadOnly] private GameState gameState;

        private List<IGameListener> _listeners = new();
        private List<IGameUpdateListener> _updateListeners = new();
        private List<IGameLateUpdateListener> _lateUpdateListeners = new();
        private List<IGameFixedUpdateListener> _fixedUpdateListeners = new();
        public void AddListener(IGameListener listener)
        {
            _listeners.Add(listener);
            if (listener is IGameUpdateListener updateListener)
            {
                _updateListeners.Add(updateListener);
            }

            if (listener is IGameLateUpdateListener lateUpdateListener)
            {
                _lateUpdateListeners.Add(lateUpdateListener);
            }

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                _fixedUpdateListeners.Add(fixedUpdateListener);
            }
        }

        public void AddListeners(GameObject parent)
        {
            IGameListener[] listeners = parent.GetComponentsInChildren<IGameListener>();

            foreach (var gameListener in listeners)
            {
                AddListener(gameListener);
            }
        }
        
        public void RemoveListener(IGameListener listener)
        {
            _listeners.Remove(listener);
            if (listener is IGameUpdateListener updateListener)
            {
                _updateListeners.Remove(updateListener);
            }

            if (listener is IGameLateUpdateListener lateUpdateListener)
            {
                _lateUpdateListeners.Remove(lateUpdateListener);
            }

            if (listener is IGameFixedUpdateListener fixedUpdateListener)
            {
                _fixedUpdateListeners.Remove(fixedUpdateListener);
            }
        }
        
        public void StartGame()
        {

            if (gameState != GameState.None)
                return;
            
            foreach(var gameListeners in _listeners)
            {
                if(gameListeners is IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }
            gameState = GameState.Start;
        }

        public void PauseGame()
        {
            if(gameState != GameState.Playing)
                return;
            
            foreach (var gameListeners in _listeners)
            {
                if (gameListeners is IGamePauseListener startListener)
                {
                    startListener.OnPause();
                }
            }
            gameState = GameState.Pause;
        }

        public void PlayingGame()
        {
            Debug.Log("Playing");
            if(gameState != GameState.Pause && gameState != GameState.Start)
                return;
            
            foreach (var gameListeners in _listeners)
            {
                if (gameListeners is IGamePlayingListener startListener)
                {
                    startListener.OnPlaying();
                }
            }
            gameState = GameState.Playing;
        }

        public void FinishGame()
        {
            if(gameState is GameState.None or GameState.Finish)
                return;
            
            foreach (var gameListeners in _listeners)
            {
                if (gameListeners is IGameFinishListener startListener)
                {
                    startListener.OnFinish();
                }
            }
            gameState = GameState.Finish;
            Time.timeScale = 0;
        }

        public void Update()
        {
            if(gameState != GameState.Playing)
                return;
            Debug.Log("Update");
            for (int i = 0; i < _updateListeners.Count; i++)
            {
                _updateListeners[i].OnUpdate(Time.deltaTime);
            }
        }

        public void LateUpdate()
        {
            if(gameState != GameState.Playing)
                return;
            
            for (int i = 0; i < _lateUpdateListeners.Count; i++)
            {
                _lateUpdateListeners[i].OnLateUpdate(Time.deltaTime);
            }
        }

        public void FixedUpdate()
        {
            if(gameState != GameState.Playing)
                return;
            
            for (int i = 0; i < _fixedUpdateListeners.Count; i++)
            {
                _fixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }
    }
}