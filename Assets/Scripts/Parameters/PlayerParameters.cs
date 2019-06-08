using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parameters/Player")]
public class PlayerParameters : ScriptableObject
{
    [SerializeField] [Range(1, 200)] private float speed;
    public float Speed => speed;

    [SerializeField] [Range(1, 200)] private float maxSpeed;
    public float MaxSpeed => maxSpeed;

    [SerializeField] [Range(1, 200)] private float jump;
    public float Jump => jump;

    [SerializeField] [Range(1, 200)] private float maxJump;
    public float MaxJump => maxJump;
}
