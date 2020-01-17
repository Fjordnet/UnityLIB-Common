using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Enums
{
    /// <summary>
    /// Helper for enumerating directions with four primary values and four secondary values (two dimensions).
    /// </summary>
    public enum Direction8
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
        UpperRight = 4,
        LowerRight = 5,
        UpperLeft = 6,
        LowerLeft = 7,
    }
}