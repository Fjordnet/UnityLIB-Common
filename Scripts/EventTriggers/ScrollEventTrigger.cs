using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Fjord.Common.UnityEvents;

namespace Fjord.Common.EventTriggers
{
    /// <summary>
    /// Captures mouse scroll and forwards a scaled value.
    /// </summary>
    public class ScrollEventTrigger : MonoBehaviour, IScrollHandler
    {
        [SerializeField]
        private Vector2 _scale = Vector2.one;

        [SerializeField]
        private Vector2UnityEvent _scrolled = new Vector2UnityEvent();

        void IScrollHandler.OnScroll(PointerEventData eventData)
        {
            _scrolled.Invoke(Vector2.Scale(eventData.scrollDelta, _scale));
        }
    }
}