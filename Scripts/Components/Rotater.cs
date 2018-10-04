using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Components
{
	public class Rotater : MonoBehaviour
	{	
		[SerializeField]
		private float _rotationSpeedX;

		[SerializeField]
		private Space _spaceX;

		[SerializeField]
		private float _rotationSpeedY;

		[SerializeField]
		private Space _spaceY;
		
		[SerializeField]
		private float _rotationSpeedZ;

		[SerializeField]
		private Space _spaceZ;
		
		private void Update()
		{
			transform.Rotate(_rotationSpeedX * Time.deltaTime, 0, 0, _spaceX);
			transform.Rotate(0, _rotationSpeedY * Time.deltaTime, 0, _spaceY);
			transform.Rotate(0, 0, _rotationSpeedZ * Time.deltaTime, _spaceZ);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			if (_spaceX == Space.Self)
			{
				Gizmos.DrawRay(transform.position, transform.right);
			}
			else
			{
				Gizmos.DrawRay(transform.position, Vector3.right);
			}
			
			Gizmos.color = Color.green;
			if (_spaceY == Space.Self)
			{
				Gizmos.DrawRay(transform.position, transform.up);
			}
			else
			{
				Gizmos.DrawRay(transform.position, Vector3.up);
			}
			
			Gizmos.color = Color.blue;
			if (_spaceZ == Space.Self)
			{
				Gizmos.DrawRay(transform.position, transform.forward);
			}
			else
			{
				Gizmos.DrawRay(transform.position, Vector3.forward);
			}
		}
	}
}