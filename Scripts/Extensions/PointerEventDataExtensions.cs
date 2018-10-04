using UnityEngine;
using UnityEngine.EventSystems;

namespace Fjord.Common.Extensions
{
    public static class PointerEventdataExtensions
    {
        /// <summary>
        /// Gets world position of pointer when pressed. Exists because pointerEventData.pointPressRaycast.worldPosition seems to not work.
        /// </summary>
        public static Vector3 PointerPressWorldPosition(this PointerEventData pointerEventData)
        {
            Ray ray = pointerEventData.pressEventCamera.ScreenPointToRay(pointerEventData.pointerPressRaycast.screenPosition);
            Vector3 worldPosition = ray.GetPoint(
                pointerEventData.pointerPressRaycast.distance - pointerEventData.pressEventCamera.nearClipPlane);
            return worldPosition;
        }

        /// <summary>
        /// Gets world position of current pointer. Exists because pointerEventData.pointerCurrentRaycast.worldPosition seems to not work.
        /// </summary>
        public static Vector3 PointerCurrentWorldPosition(this PointerEventData pointerEventData)
        {
            Ray ray = pointerEventData.enterEventCamera.ScreenPointToRay(pointerEventData.pointerCurrentRaycast.screenPosition);
            Vector3 worldPosition = ray.GetPoint(
                pointerEventData.pointerCurrentRaycast.distance - pointerEventData.enterEventCamera.nearClipPlane);
            return worldPosition;
        }

        /// <summary>
        /// Is this current interacting with the same surface that it was interacting with
        /// when it first started?
        /// </summary>
        public static bool OverSameSurace(this PointerEventData pointerEventData)
        {
            bool sameObject = pointerEventData.pointerCurrentRaycast.gameObject == pointerEventData.pointerCurrentRaycast.gameObject;
            return sameObject && pointerEventData.pointerCurrentRaycast.gameObject != null;
        }
    }
}