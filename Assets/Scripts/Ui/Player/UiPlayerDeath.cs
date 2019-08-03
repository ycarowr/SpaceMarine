using Patterns.GameEvents;
using UnityEngine;

namespace SpaceMarine
{
    public class UiPlayerDeath : UiGameEventListener, GameEvent.IPlayerDie
    {
        void GameEvent.IPlayerDie.OnDie()
        {
            //TODO: Implement a proper Game Over Screen
            Application.LoadLevel("Game");
        }
    }
}