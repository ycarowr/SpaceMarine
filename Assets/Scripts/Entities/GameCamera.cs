using SpaceMarine;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    private const float OffsetZ = -10;
    private float CachedY { get; set; }
    private IPlayer MyPlayer => Player.Instance;

    private void Update()
    {
    }

    private void FollowSpaceCraft()
    {
    }

    private void FollowPlayer()
    {
        if (CachedY == 0)
            CachedY = MyPlayer.MonoBehavior.transform.position.y;
        transform.position = new Vector3(MyPlayer.MonoBehavior.transform.position.x, CachedY, OffsetZ);
    }
}