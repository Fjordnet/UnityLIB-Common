using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Fjord.Common.EventTriggers
{
    /// <summary>
    /// Fires the standard Normal, Highlighted, Pressed, Disabled triggers
    /// on an animator that a UI Toggle would fire, but allows you to specify
    /// an Animator which is on a different GameObject. Will also keep the Animator
    /// in the 'Pressed' state based on whether or not the Toggle is on or off.
    /// </summary>
    public class ToggleAnimatorEventTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

        private Toggle _toggle;

        private void Awake()
        {
            if (null == _animator)
            {
                _animator = GetComponent<Animator>();
            }
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(ToggleValueChanged);
            if (_toggle.isOn)
            {
                _animator.SetTrigger(_pressed);
            }
        }

        public void SetNormalImmediate()
        {
            _animator.ResetTrigger(_highlighted);
            _animator.ResetTrigger(_pressed);
            _animator.ResetTrigger(_normal);
            _animator.ResetTrigger(_disabled);
            _animator.Play(_normal);
        }

        private void ToggleValueChanged(bool value)
        {
            if (value && !string.IsNullOrEmpty(_pressed))
            {
                _animator.SetTrigger(_pressed);
            }
            else if (!value && !string.IsNullOrEmpty(_normal))
            {
                _animator.SetTrigger(_normal);
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (!_toggle.isOn && !string.IsNullOrEmpty(_highlighted))
            {
                _animator.SetTrigger(_highlighted);
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (!_toggle.isOn && !string.IsNullOrEmpty(_normal))
            {
                _animator.ResetTrigger(_highlighted);
                _animator.ResetTrigger(_pressed);
                _animator.ResetTrigger(_disabled);
                _animator.SetTrigger(_normal);
            }
        }

        private void GetChildAnimator()
        {
            _animator = GetComponentInChildren<Animator>();
        }
    }
}