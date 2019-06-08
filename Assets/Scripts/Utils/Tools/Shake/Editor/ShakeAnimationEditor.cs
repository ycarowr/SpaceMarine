using Tools;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShakeAnimation))]
public class ShakeAnimationEditor : Editor
{
    private ShakeAnimation Target => target as ShakeAnimation;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Application.isPlaying)
        {
            if (GUILayout.Button("Shake!"))
                Target.Shake();

            if (Target.IsShaking && GUILayout.Button("Stop!"))
                Target.StopShaking();
        }
    }
}