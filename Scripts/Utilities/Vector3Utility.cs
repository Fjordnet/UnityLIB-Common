using UnityEngine;

namespace Fjord.Common.Utilities
{
    /// <summary>
    /// Utility methods for Vector3.
    /// </summary>
    public static class Vector3Utility
    {
        public static bool Approximately(Vector3 a, Vector3 b)
        {
            return Mathf.Approximately(a.x, b.x) &&
                   Mathf.Approximately(a.y, b.y) &&
                   Mathf.Approximately(a.z, b.z);
        }

        public static Vector3 SmoothDampAngle(Vector3 source, Vector3 target, ref Vector3 velocity, float damp)
        {
            Vector3 newEuler;
            newEuler.x = Mathf.SmoothDampAngle(
                source.x,
                target.x,
                ref velocity.x,
                damp);
            newEuler.y = Mathf.SmoothDampAngle(
                source.y,
                target.y,
                ref velocity.y,
                damp);
            newEuler.z = Mathf.SmoothDampAngle(
                source.z,
                target.z,
                ref velocity.z,
                damp);
            return newEuler;
        }
    }
}