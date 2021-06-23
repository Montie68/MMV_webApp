using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(swooshMenu))]
public class SwooshMenuEditor : Editor
{
    swooshMenu _swooshMenu;

    private void OnEnable()
    {
        _swooshMenu = (swooshMenu)target;
    }

    public override void OnInspectorGUI()
    {

        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script:", MonoScript.FromMonoBehaviour((swooshMenu)target), typeof(swooshMenu), false);
        GUI.enabled = true;

        EditorGUILayout.LabelField("New Position");

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.LabelField("Left", GUILayout.MinWidth(25), GUILayout.ExpandWidth(true));
        EditorGUILayout.LabelField("Top",  GUILayout.MinWidth(25), GUILayout.ExpandWidth(true));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        _swooshMenu._newPos.left = EditorGUILayout.FloatField(_swooshMenu._newPos.left,  GUILayout.MinWidth(25), GUILayout.ExpandWidth(true));
        _swooshMenu._newPos.top = EditorGUILayout.FloatField(_swooshMenu._newPos.top,  GUILayout.MinWidth(25), GUILayout.ExpandWidth(true));
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.LabelField("Right",  GUILayout.MinWidth(25), GUILayout.ExpandWidth(true));
        EditorGUILayout.LabelField("Bottom",  GUILayout.MinWidth(25), GUILayout.ExpandWidth(true));
        EditorGUILayout.EndHorizontal();
       
        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        _swooshMenu._newPos.right = EditorGUILayout.FloatField(_swooshMenu._newPos.right,  GUILayout.MinWidth(25), GUILayout.ExpandWidth(true));
            _swooshMenu._newPos.bottom = EditorGUILayout.FloatField(_swooshMenu._newPos.bottom,  GUILayout.MinWidth(25), GUILayout.ExpandWidth(true));
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(20);

        _swooshMenu._transitionTime = EditorGUILayout.FloatField("Transition Time", _swooshMenu._transitionTime);

    }
}
