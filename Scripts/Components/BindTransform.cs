using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fjord.Common.Extensions;

namespace Fjord.Common.Components
{
    /// <summary>
    /// On every frame, set one transform's world position to a target transform's world position.
    /// </summary>
    [ExecuteInEditMode]
    public class BindTransform : MonoBehaviour
    {
        [SerializeField]
        private Transform _transformToBind;

        private void Update()
        {
            if (null != _transformToBind)
            {
                RectTransform rectTransform = transform as RectTransform;
                if (null == rectTransform)
                {
                    _transformToBind.transform.position = transform.position;
                }
                else
                {
                    _transformToBind.transform.position = rectTransform.position;
                }
            }
        }
    }
}