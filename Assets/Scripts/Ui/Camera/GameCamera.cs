using Patterns;
using Patterns.GameEvents;
using SpaceMarine;
using SpaceMarine.Model;
using Tools.UI;
using UnityEngine;

public class GameCamera : SingletonMB<GameCamera>, IUiMotionHandler
{
    private const float OffsetZ = -10;
    [SerializeField] private float speed = 3;
    
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

    private void GoTo(Vector2 position)
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