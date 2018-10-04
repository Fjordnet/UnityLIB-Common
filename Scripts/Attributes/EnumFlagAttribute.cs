using UnityEngine;

namespace Fjord.Common.Attributes
{
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