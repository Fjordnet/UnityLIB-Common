using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Services
{
    /// <summary>
    /// Provides access to Coroutines for non-MonoBehaviour objects.
    /// </summary>
    public class CoroutineSurrogate : MonoBehaviour
    {
        private static CoroutineSurrogate activeSurrogate = null;

        public static Coroutine Run(IEnumerator co)
        {
            GameObject surrogateObj = null;
            if (null == activeSurrogate)
            {
                surrogateObj = new GameObject("CoroutineSurrogate");
                DontDestroyOnLoad(surrogateObj);
                activeSurrogate = surrogateObj.AddComponent<CoroutineSurrogate>();
            }
            return activeSurrogate.StartCoroutine(co);
        }
    }
}