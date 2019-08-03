using UnityEngine;

namespace SpaceMarine
{
    public partial class UiDoor
    {
        public class UiDoorAnimation
        {
            readonly int close = Animator.StringToHash("Close");
            readonly int open = Animator.StringToHash("Open");

            public UiDoorAnimation(MonoBehaviour handler)
            {
                Animator = handler.GetComponent<Animator>();
            }

            Animator Animator { get; }

            public void Open()
            {
                Animator.Play(open);
            }
        }
    }
}