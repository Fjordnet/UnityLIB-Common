using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Components
{
	/// <summary>
	/// Use as the base class for any and all singleton monobehaviours.
	/// </summary>
	/// <typeparam name="T">The type of the singleton instance (i.e. class MySingleton : SingletonBehaviour<MySingleton>)</typeparam>
	public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
	{
		protected static T _instance;
		public static T Instance
		{
			get
			{
				if (null == _instance)
				{
                    _instance = CreateInstance();
				}
				return _instance;
			}
		}

        protected static T CreateInstance()
        {
            T newInstance = GameObject.FindObjectOfType<T>();

            if (null == newInstance)
            {
                string typeName = typeof(T).Name;
                Debug.LogWarningFormat("SingletonBehaviour \"{0}\" not found in any loaded scene: creating new instance", typeName);
                GameObject go = new GameObject(typeName);
                go.hideFlags = HideFlags.DontSave;
                newInstance = go.AddComponent<T>();
            }

            return newInstance;
        }

        [SerializeField]
		protected bool _dontDestroyOnLoad = false;

		protected virtual void Awake()
		{
			if (_dontDestroyOnLoad)
			{
				DontDestroyOnLoad(gameObject);
			}
		}
	}
}