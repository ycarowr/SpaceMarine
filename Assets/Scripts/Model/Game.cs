using System.Collections;
using System.Collections.Generic;
using SpaceMarine.Data;
using UnityEngine;

namespace SpaceMarine.Model
{
    /// <summary>
    ///     Concrete game class.
    /// </summary>
    public class Game : IGame
    {
        #region Mechanics
        public IPlayer Player { get; }
        public ElevatorMechanics ElevatorMechanics { get; }
        public IRoomMechanics RoomMechanics { get; }
        public EnemyMechanics EnemyMechanics { get; }
        public IDoorMechanics DoorsMechanics { get; }
        public GameAttributes Attributes { get; }
        
        #endregion
        
        
        public Game(RoomData[] roomData)
        {
            RoomMechanics = new RoomMechanics(this, roomData);
            ElevatorMechanics = new ElevatorMechanics(this);
            EnemyMechanics = new EnemyMechanics(this);
            DoorsMechanics = new DoorMechanics(this);
            Attributes = new GameAttributes(this);
            Player = new PlayerMechanics(this);
        }
    }
}