using System.Text;

namespace Fjord.Common.Extensions
{
    /// <summary>
    /// Extension methods for System.Text.StringBuilder.
    /// </summary>
    public static class StringBuilderExtensions
    {
        public static void Clear(this StringBuilder stringBuilder)
        {
            stringBuilder.Length = 0;
        }
    }
}