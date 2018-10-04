using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fjord.Common.Attributes;

namespace Fjord.Common.Components
{
	public class AutoSceneLoad : MonoBehaviour
	{
		[ScenePath]
		public string SceneTarget;
		public float Delay = 5f;
		public bool LoadAsync = false;
		public LoadSceneMode LoadSceneMode = LoadSceneMode.Single;

		IEnumerator Start()
		{
			yield return new WaitForSeconds(Delay);
			string sceneName = SceneTarget.Substring(SceneTarget.LastIndexOf('/') + 1);
			sceneName = sceneName.Remove(sceneName.Length - 6);
			if (LoadAsync)
			{
				SceneManager.LoadSceneAsync(sceneName, LoadSceneMode);
			}
			else
			{
				SceneManager.LoadScene(sceneName, LoadSceneMode);
			}
		}
	}
}