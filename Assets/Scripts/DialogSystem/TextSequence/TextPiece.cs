using UnityEngine;
using UnityEngine.Events;

namespace Dialog
{
    [CreateAssetMenu(menuName = "DialogSystem/TextPiece")]
    public class TextPiece: ScriptableObject
    {
        public string Author;
        [Multiline] public string Text;
        public DialogSystem.DialogAutoAction OnPressNext = DialogSystem.DialogAutoAction.Next;
        public UnityEvent OnNext = new UnityEvent();
    }
}