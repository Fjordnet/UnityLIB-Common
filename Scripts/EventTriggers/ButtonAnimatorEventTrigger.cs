using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Fjord.Common.EventTriggers
{
    /// <summary>
    /// Fires the standard Normal, Highlighted, Pressed, Disabled triggers
    /// on an animator that a UI button would fire, but allows you to specify
    /// an Animator which is on a different GameObject.
    /// </summary>
    public class ButtonAnimatorEventTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [ContextMenuItem("Get Child Animator", "GetChildAnimator")]
        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private string _normal = "Normal";

        [SerializeField]
        private string _highlighted = "Highlighted";

        [SerializeField]
        private string _pressed = "Pressed";

        [SerializeField]
        private string _disabled = "Disabled";

        private void Awake()
        {
            if (null == _animator)
            {
                _animator = GetComponent<Animator>();
            }        
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            _animator.SetTrigger(_highlighted);
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            _animator.SetTrigger(_normal);
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            _animator.SetTrigger(_pressed);
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            _animator.SetTrigger(_highlighted);
        }

        private void GetChildAnimator()
        {
            _animator = GetComponentInChildren<Animator>();
        }
    }
}