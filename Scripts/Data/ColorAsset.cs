using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Data
{
    /// <summary>
    /// Encapsulate a Color that can be created in the Project Assets through Create > Color Asset
    /// </summary>
    [CreateAssetMenu(fileName = "Color.asset", menuName = "Color Asset", order = 100)]
    [System.Serializable]
    public class ColorAsset : ScriptableObject
    {
        [SerializeField]
        private Color _color;

        public Color Color { get { return _color; } }
    }
}