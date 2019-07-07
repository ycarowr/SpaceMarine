using Patterns.GameEvents;

namespace SpaceMarine.Model
{
    /// <summary>
    ///     A concrete player class.
    /// </summary>
    public class PlayerMechanics : BaseGameMechanic, IPlayer
    {
        public int Health { get; private set; }
        public int Ammo { get; private set; }
        public bool IsDead { get; private set; }
        public RoomId CurrentRoom { get; private set; }
        public GunId CurrentGun { get; private set; }

        public PlayerMechanics(IGame game) : base(game)
        {

        }
        

        public void EnterRoom(RoomId id)
        {
            CurrentRoom = id;
            OnEnterRoom(id);
        }

        public void LeaveRoom(RoomId id)
        {
            OnLeaveRoom(id);
        }
        
        public void TakeDamage(int amount)
        {

        }

        public void Die()
        {

        }
        
        //--------------------------------------------------------------------------------------------------------------

        void OnEnterRoom(RoomId id)
        {
            GameEvents.Instance.Notify<Events.IRoom>(i => i.OnEnterRoom(id));
        }
        
        void OnLeaveRoom(RoomId id)
        {
            GameEvents.Instance.Notify<Events.IRoom>(i => i.OnLeaveRoom(id));
        }
    }
}