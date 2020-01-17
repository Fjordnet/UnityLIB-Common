using UnityEngine;
using UnityEngine.EventSystems;

namespace Fjord.Common.Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.Transform.
    /// </summary>
    public static class TransformExtensions
    {
        public static void SetPositionRotationEqualTo(this Transform transform, Transform equalTo)
        {
            transform.position = equalTo.position;
            transform.rotation = equalTo.rotation;
        }
        
        public static void SetEqualTo(this Transform transform, Transform equalTo)
        {
            transform.position = equalTo.position;
            transform.rotation = equalTo.rotation;
            transform.localScale = equalTo.localScale;
        }
        
        public static void CopyTransform(this Transform lhs, Transform rhs, bool local = false)
        {
            if (local)
            {
                lhs.localPosition = rhs.localPosition;
                lhs.localRotation = rhs.localRotation;
            }
            else
            {
                lhs.position = rhs.position;
                lhs.rotation = rhs.rotation;
            }

            lhs.localScale = rhs.localScale;
        }
    }
}