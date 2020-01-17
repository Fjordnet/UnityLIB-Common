using Fjord.Common.Components;
using UnityEditor;
using UnityEngine;

namespace Fjord.Common.UnityEditor
{
    /// <summary>
    /// Provides extra methods for creating, editing and manipulating GameObjects.
    /// </summary>
    public static class GameObjectEditor
    {
        [MenuItem("GameObject/Fjord/Create Transform PlaceHolder", false, 0)]
        public static void CreatePlaceHolderObject(MenuCommand command)
        {
            GameObject gameObject = Selection.activeGameObject;
            if (null == gameObject)
            {
                Debug.LogWarning("No GameObject Selected.");
                return;
            }
            
            GameObject placeholderGameObject = new GameObject(gameObject.name + "Placeholder");
            placeholderGameObject.transform.SetParent(gameObject.transform.parent);
            placeholderGameObject.transform.SetSiblingIndex(gameObject.transform.GetSiblingIndex());
            TransformPlaceholder transformPlaceholder = placeholderGameObject.AddComponent<TransformPlaceholder>();
            transformPlaceholder.transform.position = gameObject.transform.position;
            transformPlaceholder.transform.rotation = gameObject.transform.rotation;
            SerializedObject serializedObject = new SerializedObject(transformPlaceholder);
            SerializedProperty serializedProperty = serializedObject.FindProperty("_targetTransform");
            serializedProperty.objectReferenceValue = gameObject.transform;
            serializedObject.ApplyModifiedProperties();
        }
    }
}