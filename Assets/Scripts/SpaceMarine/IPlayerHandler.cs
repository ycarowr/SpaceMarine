using UnityEngine;

namespace SpaceMarine
{
    public interface IPlayer
    {
        MonoBehaviour MonoBehavior { get; }
        PlayerParameters Parameters { get; }
        PlayerMovement Movement { get; }
    }
}