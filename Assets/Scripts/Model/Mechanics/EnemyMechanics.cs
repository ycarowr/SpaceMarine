using System.Collections.Generic;

namespace SpaceMarine.Model
{
    public class EnemyMechanics : BaseGameMechanic
    {
        public Dictionary<RoomId, List<IEnemy>> Enemies { get; }

        public EnemyMechanics(IGame game) : base(game)
        {
            Enemies = new Dictionary<RoomId, List<IEnemy>>();
        }

        public void CreateEnemies(IRoom room)
        {
            if (room.Data.Enemies == null)
                return;
            
            if (room.Data.Enemies.Length < 1)
                return;
            
            var roomId = room.Id;
            foreach (var enemySpot in room.Data.Enemies)
            {
                var enemy = enemySpot.Enemy.GetEnemy(room);
                
                //add room
                room.AddEnemy(enemy);
                
                //add global
                if (!Enemies.ContainsKey(roomId))
                    Enemies.Add(roomId, new List<IEnemy>() { enemy });
                else 
                    Enemies[roomId].Add(enemy);
            }
        }
    }
}