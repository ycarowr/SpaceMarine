using System.Collections;
using System.Collections.Generic;
using Patterns;
using Patterns.GameEvents;
using SpaceMarine.Data;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine
{
    /// <summary>
    ///     Realization of the game data interface.
    /// </summary>
    public class GameData : SingletonMB<GameData>, IGameData
    {
        /// <summary>
        ///     All the static data about the rooms.
        /// </summary>
        public RoomData[] Rooms;
        
        public IGame Game { get; private set; }

        void Start()
        {
            CreateGame();   
        }
        
        public void CreateGame()
        {
            Game = new Game(Rooms);
            OnCreateGame();
        }

        public void LoadGame()
        {
            //TODO:
        }

        void OnCreateGame()
        {
            GameEvents.Instance.Notify<Events.ICreateGame>(i => i.OnCreateGame(Game));
        }
    }
}