using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UIAutosizing))]
public class UIAutosizingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if( GUILayout.Button("Autosize Borders") )
        {
            ((UIAutosizing)target).AdjustSize();
        }
    }
}

[CustomEditor(typeof(BorderAutosizing))]
public class BorderAutosizingEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Autosize Borders"))
        {
            ((BorderAutosizing)target).AdjustSize();
        }
    }
}