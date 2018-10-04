using System;
using Fjord.Common.Data;
using UnityEngine;

namespace Fjord.Common.Tweens
{
    public static class TransformTweenUtility
    {
        public static Coroutine ToPosition(
            MonoBehaviour monoBehaviour,
            Transform transform,
            Vector3 targetPosition,
            float speedMultiplier,
            CurveAsset easeCurve,
            Action<Transform> step,
            Action<Transform> finished)
        {
            return monoBehaviour.StartCoroutine(
                Vector3TweenUtility.ToVector3Coroutine(
                    transform.position,
                    targetPosition,
                    speedMultiplier,
                    easeCurve,
                    vector3 =>
                    {
                        transform.position = vector3;
                        Debug.DrawRay(transform.position, Vector3.up * 100, Color.cyan);
                        if (null != step)
                        {
                            step(transform);
                        }
                    },
                    vector3 =>
                    {
                        transform.position = vector3;
                        Debug.DrawRay(transform.position, Vector3.up * 100, Color.red);
                        if (null != finished)
                        {
                            finished(transform);
                        }
                    })
            );
        }

        public static Coroutine ToLocalPosition(
            MonoBehaviour monoBehaviour,
            Transform transform,
            Vector3 targetPosition,
            float speedMultiplier,
            CurveAsset easeCurve,
            Action<Transform> step,
            Action<Transform> finished)
        {
            return monoBehaviour.StartCoroutine(
                Vector3TweenUtility.ToVector3Coroutine(
                    transform.localPosition,
                    targetPosition,
                    speedMultiplier,
                    easeCurve,
                    vector3 =>
                    {
                        transform.localPosition = vector3;
                        if (null != step)
                        {
                            step(transform);
                        }
                    },
                    vector3 =>
                    {
                        transform.localPosition = vector3;
                        if (null != finished)
                        {
                            finished(transform);
                        }
                    })
            );
        }
    }
}