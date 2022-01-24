using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CreateDay))]
public class CreateDaySOInstance : Editor
{
    public override void OnInspectorGUI()
    {
        CreateDay myTarget = (CreateDay) target;

        if (GUILayout.Button("Create Day_ScriptableObject instance"))
        {
            SO_Day asset = CreateInstance<SO_Day>();
            asset.Day = myTarget.Day;
            asset.Date = myTarget.Date;
            AssetDatabase.CreateAsset(asset, $"Assets/Scripts/Scriptable Object Instances/Days/{myTarget.Day}-{myTarget.Date}.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}