using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Components
{
    /// <summary>
    /// Enables on-demand assignment of target Transform's world position and rotation to those of this Transform.
    /// </summary>
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