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
		protected static T instance;
		public static T Instance
		{
			get
			{
				if (null == instance)
				{
					instance = GameObject.FindObjectOfType<T>();
					if (null == instance)
					{
						Debug.LogWarningFormat("Singleton {0} does not exist in any currently loaded scenes!", typeof(T).Name);
					}
				}
				return instance;
			}
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