using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField, ReadOnly] private GameState gameState;

        private List<IGameListener> iListeners = new();
        private List<IGameUpdateListener> iUpdateListeners = new();
        private List<IGameLateUpdateListener> iLateUpdateListeners = new();
        private List<IGameFixedUpdateListener> iFixedUpdateListeners = new();
        public void AddListener(IGameListener _listener)
        {
            iListeners.Add(_listener);
            if (_listener is IGameUpdateListener _updateListener)
            {
                iUpdateListeners.Add(_updateListener);
            }

            if (_listener is IGameLateUpdateListener _lateUpdateListener)
            {
                iLateUpdateListeners.Add(_lateUpdateListener);
            }

            if (_listener is IGameFixedUpdateListener _fixedUpdateListener)
            {
                iFixedUpdateListeners.Add(_fixedUpdateListener);
            }
        }

        public void AddListeners(GameObject _parent)
        {
            IGameListener[] iListeners = _parent.GetComponentsInChildren<IGameListener>();

            foreach (var gameListener in iListeners)
            {
                AddListener(gameListener);
            }
        }
        
        public void RemoveListener(IGameListener _iListener)
        {
            iListeners.Remove(_iListener);
            if (_iListener is IGameUpdateListener updateListener)
            {
                iUpdateListeners.Remove(updateListener);
            }

            if (_iListener is IGameLateUpdateListener lateUpdateListener)
            {
                iLateUpdateListeners.Remove(lateUpdateListener);
            }

            if (_iListener is IGameFixedUpdateListener fixedUpdateListener)
            {
                iFixedUpdateListeners.Remove(fixedUpdateListener);
            }
        }
        
        public void StartGame()
        {

            if (gameState != GameState.None)
                return;
            
            foreach(var gameListeners in iListeners)
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
            
            foreach (var gameListeners in iListeners)
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
            
            foreach (var gameListeners in iListeners)
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
            
            foreach (var gameListeners in iListeners)
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
            for (int i = 0; i < iUpdateListeners.Count; i++)
            {
                iUpdateListeners[i].OnUpdate(Time.deltaTime);
            }
        }

        public void LateUpdate()
        {
            if(gameState != GameState.Playing)
                return;
            
            for (int i = 0; i < iLateUpdateListeners.Count; i++)
            {
                iLateUpdateListeners[i].OnLateUpdate(Time.deltaTime);
            }
        }

        public void FixedUpdate()
        {
            if(gameState != GameState.Playing)
                return;
            
            for (int i = 0; i < iFixedUpdateListeners.Count; i++)
            {
                iFixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
            }
        }
    }
}