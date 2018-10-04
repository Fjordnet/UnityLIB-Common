using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Components
{
    public class SetActiveOnAwake : MonoBehaviour
    {
        [Header("Will set GameObject to this state in Editor.")]
        [SerializeField]
        private bool _activeStateEditor;
        
        [Header("Will set GameObject to this state in Build.")]
        [SerializeField]
        private bool _activeStateBuild;
        
        private void Awake()
        {
            if (Application.isEditor)
            {
                gameObject.SetActive(_activeStateEditor);
            }
            else
            {
                gameObject.SetActive(_activeStateBuild);
            }
        }
    }
}