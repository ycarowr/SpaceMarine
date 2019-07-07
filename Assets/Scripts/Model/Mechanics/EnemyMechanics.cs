using System.Collections.Generic;

namespace SpaceMarine.Model
{
    public class EnemyMechanics : BaseGameMechanic
    {
        public List<IEnemy> Enemies { get; }

        public EnemyMechanics(IGame game) : base(game)
        {
            Enemies = new List<IEnemy>();
        }
    }
}