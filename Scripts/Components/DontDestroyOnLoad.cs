using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Components
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}