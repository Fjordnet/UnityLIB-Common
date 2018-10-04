using System;
using UnityEditor;

namespace Fjord.Common
{
    public static class EditorExtensionMethods
    {
        public static T enumValue<T>(this SerializedProperty serializedProperty)
        {
            return (T) Enum.ToObject(typeof (T), serializedProperty.enumValueIndex);
        }
    }
}