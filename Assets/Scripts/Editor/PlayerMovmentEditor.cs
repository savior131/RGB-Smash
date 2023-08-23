using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(PlayerMovment))]
public class PlayerMovmentEditor : Editor
{
    #region SerializedPropertys
    SerializedProperty speed;
    SerializedProperty decelaration;
    SerializedProperty accelration;
    SerializedProperty dashSpeed;
    SerializedProperty dashTime;
    SerializedProperty coolTimeDash;
    SerializedProperty control;

    bool playerSpeedGroub = false , playerdash = false;
    #endregion

    private void OnEnable()
    {
        speed = serializedObject.FindProperty("speed");
        decelaration = serializedObject.FindProperty("decelaration");
        accelration = serializedObject.FindProperty("accelration");
        dashSpeed = serializedObject.FindProperty("dashSpeed");
        dashTime = serializedObject.FindProperty("dashTime");
        coolTimeDash = serializedObject.FindProperty("coolTimeDash");
        control = serializedObject.FindProperty("control");
        
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(control);
        playerSpeedGroub = EditorGUILayout.BeginFoldoutHeaderGroup(playerSpeedGroub, "player speed");
        if(playerSpeedGroub)
        {
            EditorGUILayout.PropertyField(speed);
            EditorGUILayout.PropertyField(decelaration);
            EditorGUILayout.PropertyField(accelration);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        playerdash = EditorGUILayout.BeginFoldoutHeaderGroup(playerdash, "player dash");
        if(playerdash)
        {
            EditorGUILayout.PropertyField(dashSpeed);
            EditorGUILayout.PropertyField(dashTime);
            EditorGUILayout.PropertyField(coolTimeDash);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        serializedObject.ApplyModifiedProperties();
    }
}
