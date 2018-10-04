using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Components
{
    /// <summary>
    /// Common shortcuts which should be in all applications.
    /// </summary>
    public class ShortcutProcessor : MonoBehaviour
    {
        [Header("Scene to load on F5 Press")]
        [SerializeField]
        private string _reloadSceneName;
        
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.F5))
            {
                Application.LoadLevel(_reloadSceneName);
            }
        }
    }
}