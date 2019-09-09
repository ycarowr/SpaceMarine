using Patterns.GameEvents;

namespace SpaceMarine.Model
{
    /// <summary>
    ///     A concrete player class.
    /// </summary>
    public class PlayerMechanics : BaseGameMechanic, IPlayer
    {
        public PlayerMechanics(IGame game) : base(game)
        {
        }

        public int Health { get; private set; }
        public int Ammo { get; private set; }
        public bool IsDead { get; private set; }
        public RoomId CurrentRoom { get; private set; }
        public IGunData CurrentGun { get; private set; }
        public bool IsInsideElevator { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        #region Rooms

        public void EnterRoom(RoomId id)
        {
            CurrentRoom = id;
            OnEnterRoom(id);
        }

        public void LeaveRoom(RoomId id)
        {
            OnLeaveRoom(id);
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Damage

        public void TakeDamage(int amount)
        {
        }

        public void Destroy()
        {
            OnDie();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Shooting

        public void Shoot()
        {
            OnShoot();
        }

        public bool CanShoot()
        {
            return Ammo > 0;
        }

        public void Reload()
        {
            if (CurrentGun == null)
                return;

            Ammo = CurrentGun.ClipAmmo;
            OnReload();
        }

        public void Equip(IGunData gunData)
        {
            if (gunData == null)
                return;

            CurrentGun = gunData;
            OnEquip();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Events

        void OnEnterRoom(RoomId id)
        {
            GameEvents.Instance.Notify<GameEvent.IEnterRoom>(i => i.OnEnterRoom(id));
        }

        void OnLeaveRoom(RoomId id)
        {
            GameEvents.Instance.Notify<GameEvent.ILeaveRoom>(i => i.OnLeaveRoom(id));
        }

        void OnDie()
        {
            GameEvents.Instance.Notify<GameEvent.IPlayerDie>(i => i.OnDie());
        }

        void OnShoot()
        {
            GameEvents.Instance.Notify<GameEvent.IPlayerShoot>(i => i.OnShoot(this));
        }

        void OnReload()
        {
            GameEvents.Instance.Notify<GameEvent.IPlayerReload>(i => i.OnReload(this));
        }

        void OnEquip()
        {
            GameEvents.Instance.Notify<GameEvent.IPlayerEquip>(i => i.OnEquip(this, CurrentGun));
        }

        #endregion
    }
}