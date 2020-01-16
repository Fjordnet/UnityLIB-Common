using Fjord.Common.Components;
using UnityEngine;
using UnityEditor;

namespace Fjord.Common
{
    /// <summary>
    /// Custom Editor for FitToRectTransform.
    /// </summary>
    [CustomEditor(typeof(FitToRectTransform))]
    [CanEditMultipleObjects]
    public class FitToRectTransformEditor : Editor
    {
        SerializedProperty _scaleMultiplierProperty;
        SerializedProperty _offsetProperty;
        SerializedProperty _boundsProperty;
        SerializedProperty _anchorProperty;

        private void OnEnable()
        {
            _scaleMultiplierProperty = serializedObject.FindProperty("_scaleMultiplier");
            _offsetProperty = serializedObject.FindProperty("_offset");
            _boundsProperty = serializedObject.FindProperty("_bounds");
            _anchorProperty = serializedObject.FindProperty("_cornerAchor");
        }

        public override void OnInspectorGUI()
        {
            FitToRectTransform fitToRectTransform = target as FitToRectTransform;

            serializedObject.Update();

            if (fitToRectTransform.Bounds.size == Vector3.zero)
            {
                GUI.contentColor = Color.red;
                GUILayout.Label("Bounds not set, select option below.");
                GUI.contentColor = Color.white;
            }

            EditorGUILayout.PropertyField(_offsetProperty);
            EditorGUILayout.PropertyField(_boundsProperty);

            GUILayout.Label("Gathers the bounds of all child Renderers, takes into acount local scaling.");
            if (GUILayout.Button("GatherChildRendererBounds"))
            {
                fitToRectTransform.GatherChildRendererBounds();
            }

            GUILayout.Label("Gathers the bounds of all child Meshes directly, ignoring local scaling or offsets.");
            if (GUILayout.Button("GatherChildMeshBounds"))
            {
                fitToRectTransform.GatherChildMeshBounds();
            }

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_scaleMultiplierProperty);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_anchorProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}