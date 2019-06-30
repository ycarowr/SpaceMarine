using Tools;
using UnityEngine;

namespace SpaceMarine
{
    public class Elevator : StateEntity
    {
        [SerializeField] Window pressENotification;

        protected override void OnStartProcessing()
        {
            pressENotification.Show();         
        }

        protected override void OnFinishProcessing()
        {
            pressENotification.Hide();
        }
    }
}