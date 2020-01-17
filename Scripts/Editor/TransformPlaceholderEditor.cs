using Fjord.Common.Components;
using UnityEngine;
using UnityEditor;

namespace Fjord.Common.UnityEditor
{

    /// <summary>
    /// Custom editor for TransformPlaceholder.
    /// </summary>
    [CustomEditor(typeof(TransformPlaceholder))]
    [CanEditMultipleObjects]
    public class TransformPlaceholderEditor : Editor
    {
        SerializedProperty _targetTransformProperty;

        private void OnEnable()
        {
            _targetTransformProperty = serializedObject.FindProperty("_targetTransform");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (GUILayout.Button("Set Target To This"))
            {
                TransformPlaceholder transformPlaceholder = target as TransformPlaceholder;
                transformPlaceholder.SetTargetToThis();
            }
            
            EditorGUILayout.PropertyField(_targetTransformProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}