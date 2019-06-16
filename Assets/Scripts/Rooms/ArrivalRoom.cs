using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceMarine.Rooms
{
    public class ArrivalRoom : BaseEntity
    {
        protected override void OnTriggerEnterPlayer()
        {
            Debug.Log("Entered arrival");
        }

        protected override void OnTriggerExitPlayer()
        {
            Debug.Log("exit arrival");
        }
    }
}