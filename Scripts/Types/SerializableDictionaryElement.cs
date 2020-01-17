using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Types
{
    /// <summary>
    /// Concrete parameter type for Fjord.Common.Types.SerializableDictionary.
    /// </summary>
    [System.Serializable]
    public class SerializableDictionaryElement
    {
        [SerializeField]
        private string _key;

        [SerializeField]
        private string _value;

        public string Key { get { return _key; } }

        public string Value { get { return _value; } }

        public SerializableDictionaryElement(string key, string value)
        {
            _key = key;
            _value = value;
        }
    }
}