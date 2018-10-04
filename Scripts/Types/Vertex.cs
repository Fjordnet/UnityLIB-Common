using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Fjord.Common.Types
{
	[System.Serializable]
	public struct Vertex
	{
		public Vector3 Position;
		public Vector3 Normal;
		public Vector3 Tangent;

		public Vertex(Vector3 position)
		{
			Position = position;
			Normal = Vector3.up;
			Tangent = Vector3.forward;
		}

		public Vertex(Vector3 position, Vector3 normal, Vector3 tangent)
		{
			Position = position;
			Normal = normal;
			Tangent = tangent;
		}
	}
}