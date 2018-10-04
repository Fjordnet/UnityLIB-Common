using UnityEngine;

namespace Fjord.Common.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 Abs(this Vector3 vector3)
        {
            return new Vector3(Mathf.Abs(vector3.x), Mathf.Abs(vector3.y), Mathf.Abs(vector3.z));
        }
        
        public static void MemberwiseMultiply(this Vector3 lhs, Vector3 rhs)
        {
            lhs.x *= rhs.x;
            lhs.y *= rhs.y;
            lhs.z *= rhs.z;
        }

        public static void MemberwiseDivide(this Vector3 lhs, Vector3 rhs)
        {
            lhs.x /= rhs.x;
            lhs.y /= rhs.y;
            lhs.z /= rhs.z;
        }

        public static Vector3 ReplaceX(this Vector3 lhs, float x)
        {
            lhs.x = x;
            return lhs;
        }

        public static Vector3 ReplaceY(this Vector3 lhs, float y)
        {
            lhs.y = y;
            return lhs;
        }

        public static Vector3 ReplaceZ(this Vector3 lhs, float z)
        {
            lhs.z = z;
            return lhs;
        }
    }
}