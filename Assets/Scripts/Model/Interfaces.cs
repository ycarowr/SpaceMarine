using System.Collections.Generic;
using SpaceMarine.Data;
using UnityEngine;

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
        bool IsInsideElevator { get; set; }
        RoomId CurrentRoom { get; }
        void EnterRoom(RoomId id);
        void LeaveRoom(RoomId id);
    }

    public interface IShooter
    {
        IGunData CurrentGun { get; }
        int Ammo { get; }
        void Equip(IGunData gun);
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
        RoomId CurrentRoom { get; }
        bool IsLocked { get; }
        void Lock();
        void UnLock();
        void Switch();
        void GoTo(RoomId id);
    }

    public interface IEnemy : IAttackable
    {
        EnemyId Id { get; }
        EnemyData Data { get; }
        Vector3 StartLocalPosition { get; }
    }

    public interface IRoom
    {
        RoomData Data { get; }
        RoomId Id { get; }
        List<IEnemy> Enemies { get; }
        List<IDoor> Doors { get; }
        void AddEnemy(IEnemy enemy);
        void AddDoor(IDoor door);
    }

    public interface IDoor : IAttackable
    {
        DoorData Data { get; }
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