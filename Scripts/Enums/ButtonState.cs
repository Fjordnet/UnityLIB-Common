using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Enums
{
	public enum ButtonState
	{
		/// <summary>
		/// Button is not held down.
		/// </summary>
		None,
		
		/// <summary>
		/// First cycle button is held down.
		/// </summary>
		Down,
		
		/// <summary>
		/// Button held down.
		/// </summary>
		Hold,
		
		/// <summary>
		/// First cycle button is being released.
		/// </summary>
		Up,
	}
}