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
    SerializedProperty mobileUiActive;
    SerializedProperty dashSpeed;
    SerializedProperty dashTime;
    SerializedProperty coolTimeDash;

    bool playerSpeedGroub = false , playerdash = false;
    #endregion

    private void OnEnable()
    {
        speed = serializedObject.FindProperty("speed");
        decelaration = serializedObject.FindProperty("decelaration");
        accelration = serializedObject.FindProperty("accelration");
        mobileUiActive = serializedObject.FindProperty("mobileUiActive");
        dashSpeed = serializedObject.FindProperty("dashSpeed");
        dashTime = serializedObject.FindProperty("dashTime");
        coolTimeDash = serializedObject.FindProperty("coolTimeDash");

        
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();
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
        EditorGUILayout.PropertyField(mobileUiActive);
        serializedObject.ApplyModifiedProperties();
    }
}
