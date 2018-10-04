using System;
using System.Collections;
using Fjord.Common.Data;
using UnityEngine;

namespace Fjord.Common.Tweens
{
	public static class Vector3TweenUtility
	{
		public static IEnumerator ToVector3Coroutine(
			Vector3 vector3, 
			Vector3 targetVector3,
			float speedMultiplier, 
			CurveAsset curveAsset, 
			Action<Vector3> step,
			Action<Vector3> finished)
		{
			Vector3 startVector3 = vector3;
			float time = 0;

			while (time < 1)
			{
				time += Time.deltaTime * speedMultiplier;
				float easedTime = time;
				if (null != curveAsset)
				{
					easedTime = curveAsset.Curve.Evaluate(time);
				}
				vector3 = Vector3.Lerp(startVector3, targetVector3, easedTime);
				if (null != step)
				{
					step(vector3);
				}
				yield return null;
			}

			vector3 = targetVector3;
			if (null != finished)
			{
				finished(vector3);
			}
		}
	}
}