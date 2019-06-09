using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloor : BaseEntity
{
    protected override void OnCollisionEnterPlayer()
    {
        Player.Attributes.IsGrounded = true;
    }

    protected override void OnCollisionExitPlayer()
    {
        Player.Attributes.IsGrounded = false;
    }
}
