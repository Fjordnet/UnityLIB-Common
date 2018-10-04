using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Data
{
    /// <summary>
    /// Encapsulate an AnimationCurve that can be created in the Project Assets through Create > Curve Asset
    /// </summary>
    [CreateAssetMenu(fileName = "curve.asset", menuName = "Curve Asset", order = 100)]
    [System.Serializable]
    public class CurveAsset : ScriptableObject
    {
        [SerializeField]
        private AnimationCurve _curve;

        public AnimationCurve Curve { get { return _curve; } }
    }
}