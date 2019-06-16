using UnityEngine;


namespace Dialog
{
    [CreateAssetMenu(menuName = "DialogSystem/Parameters")]
    public class Parameters : ScriptableObject
    {
        [SerializeField] [Tooltip("Characters per second.")][Range(50, 2000)] int speed = 300;

        //------------------------------------------------------------------------------------------------------------
        public int Speed => speed;

    }
}