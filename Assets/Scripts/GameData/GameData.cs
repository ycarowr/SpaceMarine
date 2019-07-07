using System.Collections;
using System.Collections.Generic;
using Patterns;
using SpaceMarine.Model;
using UnityEngine;

namespace SpaceMarine
{
    /// <summary>
    ///     Realization of the game data interface.
    /// </summary>
    public class GameData : SingletonMB<GameData>, IGameData
    {
        public IGame RuntimeGame { get; private set; }
        
        protected override void OnAwake()
        {
            CreateGame();   
        }
        
        public void CreateGame()
        {
            RuntimeGame = new Game();
        }

        public void LoadGame()
        {
            //TODO:
        }
    }
}