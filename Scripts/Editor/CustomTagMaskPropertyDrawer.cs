using System;
using Fjord.Common.Data;
using Fjord.Common.Types;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Fjord.Common.UnityEditor.PropertyDrawers
{
    /// <summary>
    /// PropertyDrawer for CustomTagMaskDatum.
    /// </summary>
    [CustomPropertyDrawer(typeof(CustomTagMask))]
    public abstract class CustomTagMaskPropertyDrawer : PropertyDrawer
    {
        private ReorderableList _list;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            InitializeList(property);

            EditorGUI.BeginProperty(position, label, property);
            _list.DoList(position);
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int arraySize = property.FindPropertyRelative("_tags").arraySize;
            if (arraySize == 0)
            {
                return EditorGUIUtility.singleLineHeight * 4;
            }
            else
            {
                return (arraySize * EditorGUIUtility.singleLineHeight) + EditorGUIUtility.singleLineHeight * 3;
            }
        }

        protected abstract string MultiTagDatumPath();

        protected abstract void DrawHeaderCallback(Rect rect);

        private void InitializeList(SerializedProperty property)
        {
            if (null == _list)
            {
                _list = new ReorderableList(
                    property.serializedObject,
                    property.FindPropertyRelative("_tags"),
                    true,
                    true,
                    true,
                    true);

                _list.drawElementCallback += DrawElementCallback;
                _list.drawHeaderCallback += DrawHeaderCallback;
                _list.onAddDropdownCallback += OnAddDropdownCallback;
            }
        }

        private void OnAddDropdownCallback(Rect buttonRect, ReorderableList list)
        {
            GenericMenu menu = new GenericMenu();
            CustomTagMaskDatum maskDatum = AssetDatabase.LoadAssetAtPath<CustomTagMaskDatum>(MultiTagDatumPath());
            int elementsAdded = 0;
            if (null != maskDatum)
            {
                for (int i = 0; i < maskDatum.Tags.Count; ++i)
                {
                    if (!ContainsTag(maskDatum.Tags[i]))
                    {
                        menu.AddItem(new GUIContent(maskDatum.Tags[i]), false, AddTag, maskDatum.Tags[i]);
                        elementsAdded++;
                    }
                }
            }

            menu.AddSeparator("");
            menu.AddItem(new GUIContent("Add Tags"), false, GoToMultiTagData);
            menu.ShowAsContext();
        }

        private void AddTag(object userData)
        {
            int index = _list.serializedProperty.arraySize;
            _list.serializedProperty.arraySize++;
            _list.index = index;
            SerializedProperty element = _list.serializedProperty.GetArrayElementAtIndex(index);
            element.stringValue = userData as string;
            _list.serializedProperty.serializedObject.ApplyModifiedProperties();
        }

        private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            SerializedProperty property = _list.serializedProperty.GetArrayElementAtIndex(index);
            GUI.Label(rect, property.stringValue);
        }

        private bool ContainsTag(string tag)
        {
            for (int i = 0; i < _list.serializedProperty.arraySize; ++i)
            {
                if (_list.serializedProperty.GetArrayElementAtIndex(i).stringValue == tag)
                {
                    return true;
                }
            }

            return false;
        }

        private void GoToMultiTagData()
        {
            Selection.activeObject = AssetDatabase.LoadAssetAtPath<CustomTagMaskDatum>(MultiTagDatumPath());
        }
    }
}