using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFloor : BaseEntity
{
    protected override void OnCollisionEnterPlayer()
    {
        MyPlayer.Attributes.IsGrounded = true;
    }

    protected override void OnCollisionExitPlayer()
    {
        MyPlayer.Attributes.IsGrounded = false;
    }
}
