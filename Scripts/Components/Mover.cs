using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Components
{
	/// <summary>
	/// Simply component to add movement to a GameObject every frame.
	/// </summary>
	public class Mover : MonoBehaviour
	{
		[Header("Units to move, or force to apply, every frame.")]
		[SerializeField]
		private Vector3 _amount;

		[Header("Space in which to apply transformation.")]
		[SerializeField]
		private Space _space;

		[Header("How much should Amount decrease each frame.")]
		[SerializeField]
		private Vector3 _amountDecay;

		[Header("Will destroy after seconds. 0 = never destroy.")]
		[SerializeField]
		private float _destroyAfterTime;
		
		private Rigidbody _rigidbody;
		private float _timer;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			if (null == _rigidbody || (null != _rigidbody && _rigidbody.isKinematic))
			{
				if (_space == Space.World)
				{
					transform.position += _amount;
				}
				else if (_space == Space.Self)
				{
					transform.localPosition += _amount;
				}
			}

			if (_amountDecay.sqrMagnitude != 0)
			{
				_amount = _amount - (_amountDecay * Time.deltaTime);
			}

			_timer += Time.deltaTime;
			if (_destroyAfterTime != 0 && _timer > _destroyAfterTime)
			{
				Destroy(gameObject);
			}
		}

		private void FixedUpdate()
		{
			if (null != _rigidbody && !_rigidbody.isKinematic)
			{
				if (_space == Space.World)
				{
					_rigidbody.AddForce(_amount);
				}
				else if (_space == Space.Self)
				{
					_rigidbody.AddRelativeForce(_amount);
				}

			}
		}
	}
}