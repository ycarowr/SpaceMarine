using UnityEngine;

namespace SpaceMarine
{
    public partial class UiDoor
    {
        public class UiDoorAnimation
        {
            readonly int open = Animator.StringToHash("Open");
            readonly int close = Animator.StringToHash("Close");    
            Animator Animator { get; }

            public UiDoorAnimation(MonoBehaviour handler)
            {
                Animator = handler.GetComponent<Animator>();
            }

            public void Open()
            {
                Animator.Play(open);
            }
        }
    }
}