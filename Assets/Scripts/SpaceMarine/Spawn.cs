using UnityEngine;

namespace SpaceMarine
{
    public class Spawn
    {
        private Transform SpawnPoint { get; }
        private IPlayer Player { get; }
        
        public Spawn(IPlayer player, Transform spawnPoint)
        {
            Player = player;
            SpawnPoint = spawnPoint;
        }

        public void Respawn()
        {
            Player.MonoBehavior.transform.position = SpawnPoint.position;
        }
    }
}