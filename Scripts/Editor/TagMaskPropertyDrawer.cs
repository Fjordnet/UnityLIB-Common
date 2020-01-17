using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Fjord.Common.Attributes;
using Fjord.Common.Types;
using UnityEditorInternal;

namespace Fjord.Common.UnityEditor.PropertyDrawers
{
    /// <summary>
    /// PropertyDrawer for TagMask.
    /// </summary>
    [CustomPropertyDrawer(typeof(TagMask))]
    public class TagMaskPropertyDrawer : PropertyDrawer
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
                return EditorGUIUtility.singleLineHeight * 2;
            }
            else
            {
                return (arraySize * EditorGUIUtility.singleLineHeight) + EditorGUIUtility.singleLineHeight;
            }
        }

        private void InitializeList(SerializedProperty property)
        {
            if (null == _list)
            {
                _list = new ReorderableList(
                    property.serializedObject,
                    property.FindPropertyRelative("_tags"),
                    true,
                    false,
                    true,
                    true);

                _list.headerHeight = 2;
                _list.drawElementBackgroundCallback += DrawElementBackgroundCallback;
                _list.onAddDropdownCallback += OnAddDropdownCallback;
                _list.drawElementCallback += DrawElementCallback;
            }
        }

        private void DrawElementBackgroundCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            if (_list.serializedProperty.arraySize == 0)
            {
                GUI.skin.label.alignment = TextAnchor.UpperRight;
                GUI.Label(rect, "Will interact with all tags.  ");
                GUI.skin.label.alignment = TextAnchor.UpperLeft;
            }
            else if (isFocused || isActive)
            {
                GUI.Box(rect, "");
            }
        }

        private void OnAddDropdownCallback(Rect buttonRect, ReorderableList list)
        {
            GenericMenu menu = new GenericMenu();
            string[] tags = InternalEditorUtility.tags;
            for (int i = 0; i < tags.Length; ++i)
            {
                if (!ListContainsTag(tags[i]))
                {
                    menu.AddItem(new GUIContent(tags[i]), false, AddTag, tags[i]);
                }
            }
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

        private bool ListContainsTag(string tag)
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
    }
}