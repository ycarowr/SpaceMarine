using Patterns;
using Tools.UI;
using UnityEngine;

public class UiCamera : SingletonMB<UiCamera>, IUiMotionHandler
{
    const float OffsetZ = -10;
    [SerializeField] float speed = 3;

    public UiMotion Motion { get; private set; }
    public MonoBehaviour MonoBehaviour => this;

    protected override void OnAwake()
    {
        Motion = new UiMotion(this);
    }

    void Update()
    {
        Motion?.Update();
    }

    void GoTo(Vector2 position)
    {
        Motion.MoveToWithZ(position, speed, OffsetZ);
    }

    //------------------------------------------------------------------------------------------------------------------

    #region Test

    [Button]
    void GoZero()
    {
        Motion.MoveToWithZ(Vector3.zero, 10, -10);
    }

    [Button]
    void Go1010()
    {
        Motion.MoveToWithZ(new Vector2(10, 10), 40, -10);
    }

    #endregion
}