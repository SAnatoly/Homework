using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class Listeners
    {
        public interface IGameListener
        {

        }
        public interface IGameStartListener: IGameListener
        {
            void OnStart();
        }

        public interface IGameFinishListener: IGameListener
        {
            void OnFinish();
        }

        public interface IGamePauseListener: IGameListener
        {
            void OnPause();
        }

        public interface IGameResumListener: IGameListener
        {
            void OnResum();
        }

        public interface IGameUpdate: IGameListener
        {
            void OnUpdate(float deltaTime);
        }

        public interface IGameLateUpdate: IGameListener
        {
            void OnLateUpdate(float deltaTime);
        }

        public interface IGameFixedUpdate: IGameListener
        {
            void OnFixedUpdate(float deltaTime);
        }
    }

}
