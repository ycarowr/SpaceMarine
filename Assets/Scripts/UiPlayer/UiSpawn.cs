using UnityEngine;

namespace SpaceMarine
{
    public class UiSpawn
    {
        private Transform SpawnPoint { get; }
        private IUiPlayer UiPlayer { get; }
        
        public UiSpawn(IUiPlayer uiPlayer, Transform spawnPoint)
        {
            UiPlayer = uiPlayer;
            SpawnPoint = spawnPoint;
        }

        public void Respawn()
        {
            UiPlayer.MonoBehavior.transform.position = SpawnPoint.position;
        }
    }
}