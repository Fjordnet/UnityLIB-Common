using UnityEngine;

namespace Fjord.Common.Utilities
{
	public class StringUtility
	{
		public static string ParseColor(Color color)
		{
			string ret = string.Empty;

			for (int i = 0; i < 4; i++)
			{
				float v = color[i];
				ret = string.Format("{0}{1:X2}", ret, (int)(v * 255));
			}

			return ret;
		}

		public static string ParseColor(Color32 color)
		{
			return ParseColor(new Color(color.r / 255f, color.g / 255f, color.b / 255f, color.a / 255f));
		}
	}
}