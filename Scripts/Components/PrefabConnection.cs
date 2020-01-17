using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Components
{
    /// <summary>
    /// Enables the ability to create and update nested prefabs.
    /// </summary>
    [System.Obsolete("Deprecated now that Unity natively includes support for nested prefabs.")]
    public class PrefabConnection : MonoBehaviour
    {
        [SerializeField]
        private string _path;
    }
}