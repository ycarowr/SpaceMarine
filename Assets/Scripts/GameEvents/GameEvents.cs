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
        ///     Broadcast of create game to all the interested listeners. Fired before IStartGame.
        /// </summary>
        public interface ICreateGame : ISubject
        {
            void OnCreateGame(IGame runtimeGame);
        }
        
        /// <summary>
        ///     Broadcast of start game to all the interested listeners. Fired after ICreateGame.
        /// </summary>
        public interface IStartGame : ISubject
        {
            void OnStartGame(IGame runtimeGame);
        }

        /// <summary>
        ///     Broadcast of end game to all the interested listeners. 
        /// </summary>
        public interface IEndGame : ISubject
        {
            void OnEndGame();
        }

        /// <summary>
        ///     Broadcast of door switcher to all the interested listeners. 
        /// </summary>
        public interface IDoors : ISubject
        {
            void OnSwitchDoor(IDoor door);
        }

        /// <summary>
        ///     Broadcast of room enter to all the interested listeners. 
        /// </summary>
        public interface IEnterRoom : ISubject
        {
            void OnEnterRoom(RoomId id);
        }
        
        /// <summary>
        ///     Broadcast of room leave to all the interested listeners. 
        /// </summary>
        public interface ILeaveRoom : ISubject
        {
            void OnLeaveRoom(RoomId id);
        }
        
        /// <summary>
        ///     Broadcast of room creation to all the interested listeners. 
        /// </summary>
        public interface ICreateRoom : ISubject
        {
            void OnCreateRoom(IRoom room);
        }
        
        /// <summary>
        ///     Broadcast of elevator control switcher to all the interested listeners. 
        /// </summary>
        public interface IElevatorControl : ISubject
        {
            void OnSwitch(bool isEnabled);
        }
        
        /// <summary>
        ///     Broadcast of die event to all the interested listeners.
        /// </summary>
        public interface IPlayerDie : ISubject
        {
            void OnDie();
        }
        
        /// <summary>
        ///     Broadcast of shoot event to all the interested listeners.
        /// </summary>
        public interface IPlayerShoot : ISubject
        {
            void OnShoot(IShooter player);
        }
        
        /// <summary>
        ///     Broadcast of reload event to all the interested listeners.
        /// </summary>
        public interface IPlayerReload : ISubject
        {
            void OnReload(IShooter player);
        }
        
        /// <summary>
        ///     Broadcast of equip event to all the interested listeners.
        /// </summary>
        public interface IPlayerEquip : ISubject
        {
            void OnEquip(IShooter player, IGunData gunData);
        }
    }

    // ...
}
