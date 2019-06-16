using UnityEngine;


namespace Dialog
{
    public partial class DialogSystem
    {
        private class DialogAnimation : DialogSubComponent
        {
            int ShowHash { get; }
            int HideHash { get; }
            Animator Animator { get; }

            public DialogAnimation(IDialogSystem system) : base(system)
            {
                ShowHash = Animator.StringToHash("Show");
                HideHash = Animator.StringToHash("Hide");
                Animator = DialogSystem.Monobehavior.GetComponentInChildren<Animator>();
            }

            public void Show()
            {
                if (!DialogSystem.IsOpened)
                    Animator.Play(ShowHash);
            }

            public void Hide()
            {
                if (DialogSystem.IsOpened)
                    Animator.Play(HideHash);
            }
        }
    }
}