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
        ///     Broadcast of door damage to all the interested listeners. 
        /// </summary>
        public interface IDoorTakeDamage : ISubject
        {
            void OnTakeDamage(IDoor door, int damage);
        }
        
        /// <summary>
        ///     Broadcast of door destroy door to all the interested listeners. 
        /// </summary>
        public interface IDestroyDoor : ISubject
        {
            void OnDestroyDoor(IDoor door);
        }
        
        /// <summary>
        ///     Broadcast of quick first door to all the interested listeners. 
        /// </summary>
        public interface IQuickFirstDoor : ISubject
        {
            void OnQuickFirstDoor();
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
        ///     Broadcast of elevator control switcher to all the interested listeners. 
        /// </summary>
        public interface IOnSwitchElevator : ISubject
        {
            void OnSwitch(bool isEnabled);
        }
        
        /// <summary>
        ///     Broadcast of elevator change room event to all the interested listeners. 
        /// </summary>
        public interface IOnElevatorChangeRoom : ISubject
        {
            void OnChangeRoom(RoomId id);
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
        
          
        /// <summary>
        ///     Broadcast of disembark event to all the interested listeners.
        /// </summary>
        public interface IPlayerDisembark : ISubject
        {
            void OnDisembark(IElevator elevator, IPlayer player);
        }
        
          
        /// <summary>
        ///     Broadcast of embark event to all the interested listeners.
        /// </summary>
        public interface IPlayerEmbark : ISubject
        {
            void OnEmbark(IElevator elevator, IPlayer player);
        }
    }

    // ...
}
