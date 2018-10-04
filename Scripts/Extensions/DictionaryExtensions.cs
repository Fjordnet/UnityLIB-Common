using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public static class DictionaryExtensions
{
    /// <summary>
    /// Gets a value if available, otherwise returns null. Does so without generating
    /// garbage, TryGetValue generates garbage.
    /// </summary>
    public static T1 GetValue<T0, T1>(this Dictionary<T0, T1> dictionary, T0 key)
    {
        if (dictionary.ContainsKey(key))
        {
            return dictionary[key];
        }
        return default(T1);
    }
}