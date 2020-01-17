using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Services
{
    /// <summary>
    /// Provides a single common point of access for all services throughout a project.
    /// Service behaviors should be added as children to this GameObject and requested
    /// with PersistentServices.GetService(). This mitigates the need for separate
    /// singletons for each individual service.
    /// </summary>
    public class PersistentServices : MonoBehaviour
    {
        [SerializeField]
        private bool _instantiateBeforeSceneLoad = true;

        static private PersistentServices _instance;

        static public PersistentServices Instance
        {
            get
            {
                if (null == _instance)
                {
                    _instance = FindObjectOfType<PersistentServices>();
                }
                return _instance;
            }
        }

        public bool InstantiateBeforeSceneLoad { get { return _instantiateBeforeSceneLoad; } }

        static public T GetService<T>()
        {
            return Instance.GetComponentInChildren<T>();
        }

        static public T[] GetServices<T>()
        {
            return Instance.GetComponentsInChildren<T>();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static private void Init()
        {
            if (null == _instance)
            {
                PersistentServices prefab = Resources.Load<PersistentServices>("PersistentServices");
                if (null != prefab && prefab.InstantiateBeforeSceneLoad)
                {
                    DontDestroyOnLoad(Instantiate(prefab));
                    Debug.Log("Instantiated Persistent Services.");
                }
                else
                {
                    Debug.LogWarning("Persistent Services already instantiated.");
                }
            }
        }
    }
}