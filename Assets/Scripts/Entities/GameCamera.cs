using Patterns;
using SpaceMarine;
using Tools.UI;
using UnityEngine;

public class GameCamera : SingletonMB<GameCamera>, IUiMotionHandler
{
    private const float OffsetZ = -10;
    
    public UiMotion Motion { get; private set; }
    public MonoBehaviour MonoBehaviour => this;

    protected override void OnAwake()
    {
        Motion = new UiMotion(this);
    }

    private void Update()
    {
        Motion?.Update();
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