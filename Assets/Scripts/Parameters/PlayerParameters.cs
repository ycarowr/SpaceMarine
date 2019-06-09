using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parameters/Player")]
public class PlayerParameters : ScriptableObject
{
    [Header("Horizontal")]
    [SerializeField] [Range(1, 200)] private float speed;
    public float Speed => speed;

    [SerializeField] [Range(1, 200)] private float maxSpeed;
    public float MaxSpeed => maxSpeed;

    [Header("Vertical")]
    [SerializeField] [Range(1, 200)] private float jump;
    public float Jump => jump;

    [SerializeField] [Range(0.01f, 2)] private float maxJumpTime;
    public float MaxJump => maxJumpTime;

    [SerializeField] [Range(1, 200)] private float gravity;
    public float Gravity => -gravity;
}
