using System.IO;
using UnityEditor;
using UnityEngine;

public static class ScriptableObjectUtility
{
#if UNITY_EDITOR
    /// <summary>
    //	This makes it easy to create, name and place unique new ScriptableObject asset files.
    /// </summary>
    public static T CreateAsset<T>(string path = null, bool withFocus = false, bool withSave = false)
        where T : ScriptableObject
    {
        var asset = ScriptableObject.CreateInstance<T>();

        if (path == null)
            path = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (path == "")
            path = "Assets";
        else if (Path.GetExtension(path) != "")
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");

        var assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + ".asset");
        AssetDatabase.CreateAsset(asset, assetPathAndName);

        if (withSave)
        {
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        if (withFocus)
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        return asset;
    }

    public static T CreateAssetOnSamePath<T>(Object target) where T : ScriptableObject
    {
        var path = AssetDatabase.GetAssetPath(target).Replace("/" + target.name + ".asset", "");
        var name = "/" + typeof(T);
        name = name.Replace("Hexgame", string.Empty);
        name = name.Replace("Data", string.Empty);
        name = name.Replace(".", string.Empty);
        path += name + " " + target.name;
        return CreateAsset<T>(path);
    }
#endif
}