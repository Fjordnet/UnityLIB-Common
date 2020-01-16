using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fjord.Common.Enums;

namespace Fjord.Common.Components
{
    /// <summary>
    /// Fit a Transform to the bounds of its parent RectTransform.
    /// </summary>
    public class FitToRectTransform : MonoBehaviour
    {
        [Header("Offset")]
        [SerializeField]
        private Vector3 _offset;
        
        [Header("Bounds by which to calculate scaling.")]
        [SerializeField]
        private Bounds _bounds;

        [Header("Multiply final scale by this amount.")]
        [SerializeField]
        private Vector3 _scaleMultiplier = Vector3.one;

        [Header("Corner Anchor")]
        [SerializeField]
        private Anchor2D _cornerAchor;

        private RectTransform _parentRectTransform;

        public Bounds Bounds { get { return _bounds; } }

        private void Awake()
        {           
            _parentRectTransform = transform.parent.GetComponent<RectTransform>();
        }

        private void Update()
        {
            transform.localScale = new Vector3(
                _parentRectTransform.sizeDelta.x / _bounds.size.x,
                _parentRectTransform.sizeDelta.y / _bounds.size.y,
                1f);
            transform.localScale = Vector3.Scale(transform.localScale, _scaleMultiplier);
                        
            switch (_cornerAchor)
            {
                case Anchor2D.None:
                    break;
                case Anchor2D.UpperLeft:
                    transform.localPosition = new Vector3(
                        (-_parentRectTransform.sizeDelta.x / 2) + _offset.x,
                        (_parentRectTransform.sizeDelta.y / 2) + _offset.z,
                        _offset.z);
                    break;
                case Anchor2D.Upper:
                    transform.localPosition = new Vector3(
                        _offset.x,
                        (_parentRectTransform.sizeDelta.y / 2) + _offset.y,
                        _offset.z);
                    break;
                case Anchor2D.UpperRight:
                    transform.localPosition = new Vector3(
                        (_parentRectTransform.sizeDelta.x / 2) + _offset.x,
                        (_parentRectTransform.sizeDelta.y / 2) + _offset.y,
                        _offset.z);
                    break;
                case Anchor2D.Left:
                    transform.localPosition = new Vector3(
                        (-_parentRectTransform.sizeDelta.x / 2) + _offset.x,
                        _offset.y,
                        _offset.z);
                    break;
                case Anchor2D.Center:
                    transform.localPosition = new Vector3(
                        _offset.x,
                        _offset.y,
                        _offset.z);
                    break;
                case Anchor2D.Right:
                    transform.localPosition = new Vector3(
                        (_parentRectTransform.sizeDelta.x / 2) + _offset.x,
                        _offset.y,
                        _offset.z);
                    break;
                case Anchor2D.Lowerleft:
                    transform.localPosition = new Vector3(
                        (-_parentRectTransform.sizeDelta.x / 2) + _offset.x,
                        (-_parentRectTransform.sizeDelta.y / 2) + _offset.y,
                        _offset.z);
                    break;
                case Anchor2D.Lower:
                    transform.localPosition = new Vector3(
                        _offset.x,
                        (-_parentRectTransform.sizeDelta.y / 2) + _offset.y,
                        _offset.z);
                    break;
                case Anchor2D.LowerRight:
                    transform.localPosition = new Vector3(
                        (_parentRectTransform.sizeDelta.x / 2) + _offset.x,
                        (-_parentRectTransform.sizeDelta.y / 2) + _offset.y,
                        _offset.z);
                    break;
            }
        }

        [ContextMenu("GatherChildRendererBounds")]
        public void GatherChildRendererBounds()
        {
            transform.localScale = Vector3.one;
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            if (renderers.Length > 0)
            {
                _bounds.center = renderers[0].bounds.center;
                _bounds.size = Vector3.zero;
                for (int i = 0; i < renderers.Length; ++i)
                {
                    _bounds.Encapsulate(renderers[i].bounds);
                }
            }
        }

        [ContextMenu("GatherChildMeshBounds")]
        public void GatherChildMeshBounds()
        {
            MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();
            if (filters.Length > 0)
            {
                _bounds.center = Vector3.zero;
                _bounds.size = Vector3.zero;
                for (int i = 0; i < filters.Length; ++i)
                {
                    _bounds.Encapsulate(filters[i].sharedMesh.bounds);
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (_bounds.size.sqrMagnitude != 0 && enabled)
            {
                Awake();
                Update();
            }
        }
    }
}
