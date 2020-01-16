using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Fjord.Common.Data
{
    /// <summary>
    /// Encapsulate a List of tag strings that can be created in the Project Assets through Create > Curve Asset
    /// </summary>
    [CreateAssetMenu(fileName = "CustomTagMaskDatum.asset", menuName = "Custom Tag Mask", order = 110)]
    [System.Serializable]
    public class CustomTagMaskDatum : ScriptableObject
    {
        [SerializeField]
        private List<string> _tags = new List<string>();

        public ReadOnlyCollection<string> Tags
        {
            get { return _tags.AsReadOnly(); }
        }
    }
}