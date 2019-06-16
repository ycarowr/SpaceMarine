using UnityEngine;


namespace Dialog
{
    [CreateAssetMenu(menuName = "DialogSystem/TextPiece")]
    public class TextPiece: ScriptableObject
    {
        public string Author;
        [Multiline] public string Text;
    }
}