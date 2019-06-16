using UnityEngine;

namespace Dialog
{
    [CreateAssetMenu(menuName = "DialogSystem/TextSequence")]
    public class TextSequence : ScriptableObject
    {
        public TextPiece[] Sequence;
    }
}