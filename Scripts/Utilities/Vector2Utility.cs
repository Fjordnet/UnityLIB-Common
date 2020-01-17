using UnityEngine;

namespace Fjord.Common.Utilities
{
    /// <summary>
    /// Utility methods for Vector2.
    /// </summary>
    public static class Vector2Utility
    {
        public static bool Approximately(Vector2 a, Vector2 b)
        {
            return Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y);
        }
    }
}