using System;
using Fjord.Common.Data;
using UnityEngine;

namespace Fjord.Common.Tweens
{
    /// <summary>
    /// Automatically tweens Transform properties with specified settings.
    /// </summary>
    public class TransformTweener : MonoBehaviour
    {
        [SerializeField]
        private float _speedMultiplier = 1;

        [SerializeField]
        private CurveAsset _easeCurve;

        private Coroutine _positionCoroutine;

        public void ToLocalPosition(
            float x, float y, float z,
            float speedMultiplier = 0,
            CurveAsset easeCurve = null,
            Action<Transform> step = null,
            Action<Transform> finished = null)
        {
            ToLocalPosition(new Vector3(x, y, z), speedMultiplier, easeCurve, step, finished);
        }

        public void ToLocalPosition(
            Vector3 target,
            float speedMultiplier = 0,
            CurveAsset easeCurve = null,
            Action<Transform> step = null,
            Action<Transform> finished = null)
        {
            StopPositionCoroutine();
            _positionCoroutine = TransformTweenUtility.ToLocalPosition(
                this,
                transform,
                target,
                Mathf.Approximately(speedMultiplier, 0) ? _speedMultiplier : speedMultiplier,
                easeCurve == null ? _easeCurve : easeCurve,
                step,
                finished);
        }

        public void ToPosition(
            Vector3 target,
            float speedMultiplier = 0,
            CurveAsset easeCurve = null,
            Action<Transform> step = null,
            Action<Transform> finished = null)
        {
            StopPositionCoroutine();
            _positionCoroutine = TransformTweenUtility.ToPosition(
                this,
                transform,
                target,
                Mathf.Approximately(speedMultiplier, 0) ? _speedMultiplier : speedMultiplier,
                easeCurve == null ? _easeCurve : easeCurve,
                step,
                finished);
        }

        private void StopPositionCoroutine()
        {
            if (null != _positionCoroutine)
            {
                StopCoroutine(_positionCoroutine);
            }
        }
    }
}