using UnityEngine;

[CreateAssetMenu(menuName = "Parameters/UiPlayer")]
public class UiPlayerParameters : ScriptableObject
{
    [SerializeField] [Range(1, 200)] private float fallSpeed;


    [SerializeField] [Range(1, 200)] private float jumpSpeed;

    [Header("Vertical")] [SerializeField] [Range(0.1f, 2)]
    private float jumpTime;

    [Header("Horizontal")] [SerializeField] [Range(1, 200)]
    private float speed;

    public float Speed => speed;
    public float JumpTime => jumpTime;
    public float JumpSpeed => jumpSpeed;
    public float FallSpeed => -fallSpeed;
}