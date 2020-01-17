using UnityEngine;

namespace Fjord.Common.Attributes
{
    /// <summary>
    /// Enables the EnumFlagPropertyDrawer to render enum fields as dropdown lists in the Inspector.
    /// </summary>
    public class EnumFlagAttribute : PropertyAttribute
    {
        public readonly string EnumName;

        public EnumFlagAttribute()
        {
        }

        public EnumFlagAttribute(string name)
        {
            EnumName = name;
        }
    }
}