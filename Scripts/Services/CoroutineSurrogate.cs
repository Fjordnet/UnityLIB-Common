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
        public IEnumerator Iterator;

        public static void Instantiate(IEnumerator co)
        {
            GameObject surrogate = new GameObject("CoroutineSurrogate");
            DontDestroyOnLoad(surrogate);
            CoroutineSurrogate script = surrogate.AddComponent<CoroutineSurrogate>();
            script.Iterator = co;
            script.RunCoroutine();
        }

        public void RunCoroutine()
        {
            StartCoroutine(RunCoroutineCo());
        }

        IEnumerator RunCoroutineCo()
        {
            yield return StartCoroutine(Iterator);
            Destroy(gameObject);
        }
    }
}