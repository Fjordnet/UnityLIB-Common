using UnityEngine;

namespace Fjord.Common.Utilities
{
    public static class ColorUtility
    {
        public static Color MoveTowards(Color a, Color b, float maxAmount)
        {
            return new Color(
                Mathf.MoveTowards(a.r, b.r, maxAmount),
                Mathf.MoveTowards(a.g, b.g, maxAmount),
                Mathf.MoveTowards(a.b, b.b, maxAmount),
                Mathf.MoveTowards(a.a, b.a, maxAmount));
        }
    }
}