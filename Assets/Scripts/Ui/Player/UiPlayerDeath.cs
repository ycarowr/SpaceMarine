using Tools.Patterns.GameEvents;
using UnityEngine;

namespace SpaceMarine
{
    public class UiPlayerDeath : UiGameEventListener, GameEvent.IPlayerDie
    {
        void GameEvent.IPlayerDie.OnDie() => Application.LoadLevel("Game");
    }
}