using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parameters/Player")]
public class PlayerParameters : ScriptableObject
{
    [Header("Horizontal")]
    [SerializeField] [Range(1, 200)] private float speed;
    public float Speed => speed;

    [Header("Vertical")]
    [SerializeField] [Range(0.1f, 2)] private float jumpTime;
    public float JumpTime => jumpTime;


    [SerializeField] [Range(1, 200)] private float jumpSpeed;
    public float JumpSpeed => jumpSpeed;

    [SerializeField] [Range(1, 200)] private float fallSpeed;
    public float FallSpeed => -fallSpeed;
}
