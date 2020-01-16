using UnityEngine;
using Fjord.Common.Components;
using UnityEditor;

namespace Fjord.Common.UnityEditor
{
    /// <summary>
    /// Custom editor for PrefabConnection.
    /// </summary>
    [System.Obsolete("Deprecated now that Unity natively includes support for nested prefabs.")]
    [CustomEditor(typeof(PrefabConnection))]
    public class PrefabConnectionEditor : Editor
    {
        private SerializedProperty _pathProperty;

        private void OnEnable()
        {
            _pathProperty = serializedObject.FindProperty("_path");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            PrefabConnection prefabConnection = target as PrefabConnection;

            EditorGUILayout.PropertyField(_pathProperty);
            if (GUILayout.Button("Set Path"))
            {
                _pathProperty.stringValue = EditorUtility.SaveFilePanelInProject("Save Prefab", target.name, "prefab", "Select where to save the Prefab.");
            }

            if (GUILayout.Button("Select Prefab"))
            {
                GameObject asset = AssetDatabase.LoadAssetAtPath<GameObject>(_pathProperty.stringValue);
                if (null != asset)
                {
                    EditorGUIUtility.PingObject(asset);
                }
            }

            if (GUILayout.Button("Write Prefab"))
            {
                GameObject asset = AssetDatabase.LoadAssetAtPath<GameObject>(_pathProperty.stringValue);
                if (null == asset)
                {
                    GameObject gameObject = PrefabUtility.CreatePrefab(_pathProperty.stringValue, prefabConnection.gameObject);
                    DestroyImmediate(gameObject.GetComponent<PrefabConnection>(), true);
                }
                else
                {
                    GameObject gameObject = PrefabUtility.ReplacePrefab(prefabConnection.gameObject, asset, ReplacePrefabOptions.ReplaceNameBased);
                    DestroyImmediate(gameObject.GetComponent<PrefabConnection>(), true);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}