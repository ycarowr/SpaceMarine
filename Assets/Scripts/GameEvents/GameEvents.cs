using System.Collections;
using System.Collections.Generic;
using Patterns;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine
{
    public class Events
    {
        /// <summary>
        ///     Broadcast of start game for all interested listeners. 
        /// </summary>
        public interface IStartGame : ISubject
        {
            void OnStartGame(IGame runtimeGame);
        }

        /// <summary>
        ///     Broadcast of end game for all interested listeners. 
        /// </summary>
        public interface IEndGame : ISubject
        {
            void OnEndGame();
        }

        /// <summary>
        ///     Broadcast of door switcher for all interested listeners. 
        /// </summary>
        public interface IDoors : ISubject
        {
            void OnSwitchDoor(IDoor door);
        }

        /// <summary>
        ///     Broadcast of room switcher for all interested listeners. 
        /// </summary>
        public interface IRoom : ISubject
        {
            void OnEnterRoom(RoomId id);
            void OnLeaveRoom(RoomId id);
        }
        
        /// <summary>
        ///     Broadcast of elevator switcher for all interested listeners. 
        /// </summary>
        public interface IElevatorControl : ISubject
        {
            void OnSwitch(bool isEnabled);
        }
    }

    // ...
}
