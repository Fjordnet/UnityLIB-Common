using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Types
{
    /// <summary>
    /// Encapsulates a Dictionary-like data structure that can be passed to JsonUtility.ToJson
    /// </summary>
    [System.Serializable]
    public class SerializableDictionary 
    {
        [SerializeField]
        private List<SerializableDictionaryElement> _dictionary = new List<SerializableDictionaryElement>();

        public SerializableDictionaryElement this[int i]
        {
            get { return _dictionary[i]; }            
        }

        public int Count
        {
            get { return _dictionary.Count; }
        }

        public void Add(string key, string value)
        {
            _dictionary.Add(new SerializableDictionaryElement(key, value));
        }

        public string Find(string key)
        {
            SerializableDictionaryElement element = _dictionary.Find(e => e.Key == key);
            if (null != element)
            {
                return element.Value;
            }
            return null;
        }        
    }
}