using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level)), CanEditMultipleObjects]
public class MyTestEditor : Editor {

    public override void OnInspectorGUI() {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("LevelSelector"));

        Level.LevelsNames levelName = (Level.LevelsNames)serializedObject.FindProperty("LevelSelector").enumValueIndex;

        switch (levelName) {
            case Level.LevelsNames.ColorLevel:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("NumberQuestions"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("BaseQuestion"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Questions"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Colors"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("SpawnObstaclesScript"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Obstacles"));
                break;

            case Level.LevelsNames.AnimalsLevel:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("NumberQuestions"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("BaseQuestion"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Questions"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Animals"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("SpawnObstaclesScript"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Obstacles"));
                break;

            case Level.LevelsNames.ShapesLevel:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("NumberQuestions"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("BaseQuestion"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Questions"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("GeometricShapes"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("SpawnObstaclesScript"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Obstacles"));
                break;

            case Level.LevelsNames.MathsLevel:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("NumberQuestions"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Questions"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("SpawnObstaclesScript"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Obstacles"));
                break;

        }
        serializedObject.ApplyModifiedProperties();
    }
}
