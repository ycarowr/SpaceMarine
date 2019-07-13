using System.Collections.Generic;
using SpaceMarine.Data;

namespace SpaceMarine.Model
{
    public interface IGame
    {
        IPlayer Player { get; }
        GameAttributes Attributes { get; }
        ElevatorMechanics ElevatorMechanics { get; }
        IRoomMechanics RoomMechanics { get; }
        EnemyMechanics EnemyMechanics { get; }
        IDoorMechanics DoorsMechanics { get; }
    }

    public interface IPlayer : IAttackable, IShooter
    {
        RoomId CurrentRoom { get; }
        void EnterRoom(RoomId id);
        void LeaveRoom(RoomId id);
    }

    public interface IShooter
    {
        IGunData CurrentGun { get; }
        void Equip(IGunData gun);
        int Ammo { get; }
        bool CanShoot();
        void Shoot();
    }

    public interface IAttackable
    {
        bool IsDead { get; }
        int Health { get; }
        void TakeDamage(int amount);
        void Die();
    }

    public interface IElevator
    {
        bool IsLocked { get; }
        void Lock();
        void UnLock();
        void Switch();
    }

    public interface IEnemy : IAttackable
    {
    }

    public interface IRoom
    {
        RoomData Data { get; }
        RoomId Id { get; }
        List<IEnemy> Enemies { get; }
        List<IDoor> Doors { get; }
    }

    public interface IDoor
    {
        DoorId Id { get; }
        bool IsLocked { get; }
        void Lock();
        void UnLock();
    }

    public interface IRoomMechanics
    {
        void CreateRooms(RoomData[] roomData);
        IRoom Get(RoomId id);
        void PlayerEnter(RoomId id);
        void PlayerLeave(RoomId id);
    }
}