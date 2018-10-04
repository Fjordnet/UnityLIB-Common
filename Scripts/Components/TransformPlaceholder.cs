using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Components
{
    public class TransformPlaceholder : MonoBehaviour
    {
        [SerializeField]
        private Transform _targetTransform;

        [ContextMenu("Set Target To This")]
        public void SetTargetToThis()
        {
            _targetTransform.position = transform.position;
            _targetTransform.rotation = transform.rotation;
        }
    }
}