using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Data
{
    /// <summary>
    /// Encapsulate a Color that can be created in the Project Assets through Create > Color Asset
    /// </summary>
    [CreateAssetMenu(fileName = "Gradient.asset", menuName = "Gradient Asset", order = 100)]
    [System.Serializable]
    public class GradientAsset : ScriptableObject
    {
        [SerializeField]
        private Gradient _gradient;

        public Gradient Gradient { get { return _gradient; } }
    }
}