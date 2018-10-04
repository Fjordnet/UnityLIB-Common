using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Types
{
    /// <summary>
    /// Can store a set of UnityTags to compare against a GameObject.
    /// </summary>
    [System.Serializable]
    public class TagMask
    {
        [SerializeField]
        private List<string> _tags = new List<string>();

        public bool CompareTags(GameObject gameObject)
        {
            if (_tags.Count == 0) return true;

            for (int i = 0; i < _tags.Count; ++i)
            {
                if (gameObject.CompareTag(_tags[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}