using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Tweens
{
	/// <summary>
	/// Will continuously damp properties of transform
	/// towards specified targets.
	/// </summary>
	public class TransformDamper : MonoBehaviour
	{
		[SerializeField]
		private float _damp = .1f;
		
		[SerializeField]
		private bool _targetPositionIsLocal;
		
		[SerializeField]
		private Vector3 _targetPosition;

		private Vector3 _positionVelocity;

		private void Awake()
		{
			if (_targetPositionIsLocal)
			{
				_targetPosition = transform.localPosition;
			}
			else
			{
				_targetPosition = transform.position;
			}
		}

		private void Update()
		{
			if (_targetPositionIsLocal)
			{
				transform.localPosition =
					Vector3.SmoothDamp(transform.localPosition, _targetPosition, ref _positionVelocity, _damp);
			}
			else
			{
				transform.position =
					Vector3.SmoothDamp(transform.position, _targetPosition, ref _positionVelocity, _damp);
			}
		}

		public void SetTargetPosition(Vector3 targetPosition, bool isLocal)
		{
			_targetPosition = targetPosition;
			_targetPositionIsLocal = isLocal;
		}
	}
}