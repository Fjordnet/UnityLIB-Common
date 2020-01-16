using System.Collections;
using System.Collections.Generic;
using Fjord.Common.Data;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Fjord.Common.UnityEditor
{
    /// <summary>
    /// Custom editor for CustomTagMaskDatum.
    /// </summary>
    [CustomEditor(typeof(CustomTagMaskDatum))]
    public class CustomTagMaskDatumEditor : Editor
    {
        private ReorderableList _list;
        
        private void OnEnable() {
            _list = new ReorderableList(serializedObject, 
                serializedObject.FindProperty("_tags"), 
                true, true, true, true);
            
            _list.drawElementCallback += DrawElementCallback;
            _list.drawHeaderCallback += DrawHeaderCallback;
        }
        
        public override void OnInspectorGUI() {
            serializedObject.Update();
            _list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
        
        private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty property = _list.serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(rect, property);
        }
        
        private void DrawHeaderCallback(Rect rect)
        {
            GUI.Label(rect, "Tags");
        }
    }
}