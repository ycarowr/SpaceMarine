using System.Collections.Generic;

namespace SpaceMarine.Model
{
    public interface IGame
    {
        IPlayer Player { get; }
        ElevatorMechanics ElevatorMechanics { get; }
        IRoomMechanics RoomMechanics { get; }
        EnemyMechanics EnemyMechanics { get; }
        IDoorMechanics DoorsMechanics { get; }
    }

    public interface IPlayer : IAttackable
    {
        int Health { get; }
        int Ammo { get; }
        bool IsDead { get; }
        RoomId CurrentRoom { get; }
        GunId CurrentGun { get; }
        void EnterRoom(RoomId id);
        void LeaveRoom(RoomId id);
    }

    public interface IAttackable
    {
        bool IsDead { get; }
        int Health { get; }
        void TakeDamage(int amount);
        void Die();
    }

    public interface IElevatorControl
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
}