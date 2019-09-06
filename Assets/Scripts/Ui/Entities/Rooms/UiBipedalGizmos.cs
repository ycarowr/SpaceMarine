using SpaceMarine.Data;
using Tools;
using UnityEngine;

namespace SpaceMarine.Rooms
{
    public class UiBipedalGizmos : UiRoomGizmos
    {
        public BipedalData[] bipedals;
        
        protected override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
            
            foreach(var bipData in bipedals)
            {
                Gizmos.DrawWireSphere((Vector3)bipData.PointA + transform.position, 0.2f);
                Gizmos.DrawWireSphere((Vector3)bipData.PointB + transform.position, 0.2f);
            }
        }
    }
}