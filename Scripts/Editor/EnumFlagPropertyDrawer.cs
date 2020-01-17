using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fjord.Common.Attributes;
using UnityEditor;
using UnityEngine;

namespace Fjord.Common.UnityEditor.PropertyDrawers
{
    /// <summary>
    /// Renders enum fields marked with EnumFlagAttribute as dropdown lists in the Inspector.
    /// </summary>
    [CustomPropertyDrawer(typeof(EnumFlagAttribute))]
    public class EnumFlagDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EnumFlagAttribute flagSettings = (EnumFlagAttribute)attribute;
            string[] path = property.propertyPath.Split('.');
            object targetObject = property.serializedObject.targetObject;

            // Walk through field references to get actual targetObject
            // You must walk through them in case your Enum is a field in a class composited into a monobehavior
            for (int i = 0; i < path.Length - 1; ++i)
            {
                foreach (FieldInfo field in GetAllFields(targetObject.GetType()))
                {
                    if (field.Name == path[i]) targetObject = field.GetValue(targetObject);
                }
            }

            Enum targetEnum = (Enum)fieldInfo.GetValue(targetObject);

            string propName = flagSettings.EnumName;
            if (string.IsNullOrEmpty(propName))
                propName = ObjectNames.NicifyVariableName(property.name);

            EditorGUI.BeginProperty(position, label, property);
            Enum enumNew = EditorGUI.EnumFlagsField(position, propName, targetEnum);
            property.intValue = (int)Convert.ChangeType(enumNew, targetEnum.GetType());
            EditorGUI.EndProperty();
        }

        public static IEnumerable<FieldInfo> GetAllFields(Type t)
        {
            if (t == null)
                return Enumerable.Empty<FieldInfo>();

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic |
                                 BindingFlags.Static | BindingFlags.Instance |
                                 BindingFlags.DeclaredOnly;
            return t.GetFields(flags).Concat(GetAllFields(t.BaseType));
        }
    }
}