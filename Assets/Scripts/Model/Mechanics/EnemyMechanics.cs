using System.Collections.Generic;

namespace SpaceMarine.Model
{
    public class EnemyMechanics : BaseGameMechanic
    {
        public EnemyMechanics(IGame game) : base(game) => Enemies = new List<IEnemy>();

        public List<IEnemy> Enemies { get; }

        public void CreateEnemies(IRoom room)
        {
            if (room.Data.Enemies == null)
                return;

            if (room.Data.Enemies.Length < 1)
                return;

            var roomId = room.Id;
            foreach (var enemySpot in room.Data.Enemies)
            {
                var position = enemySpot.Position;
                var enemy = enemySpot.Enemy.GetEnemy(position);

                //add room
                room.AddEnemy(enemy);

                //add global
                AddEnemy(enemy);
            }
        }

        public void AddEnemy(IEnemy enemy) => Enemies.Add(enemy);
    }
}