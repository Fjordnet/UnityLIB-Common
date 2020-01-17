using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Types
{
    /// <summary>
    /// Base class for providing a custom list of string tags.
    /// </summary>
    public abstract class CustomTagMask 
    {
        [SerializeField]
        private List<string> _tags = new List<string>();

        public bool CompareTags(CustomTagMask customTagMask)
        {
            for (int i = 0; i < _tags.Count; ++i)
            {
                for (int j = 0; j < customTagMask._tags.Count; ++j)
                {
                    if (_tags[i].Contains(customTagMask._tags[j]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int Count()
        {
            return _tags.Count;
        }
    }
}

