using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Fjord.Common.Data
{
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