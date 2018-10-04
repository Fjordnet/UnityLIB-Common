using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fjord.Common.Extensions
{
	public static class AppDomainExtensions
	{
		public static System.Type[] GetAllDerivedTypes(this System.AppDomain appDomain, System.Type baseType)
		{
			List<System.Type> result = new List<System.Type>();
			System.Reflection.Assembly[] assemblies = appDomain.GetAssemblies();
			for (int i = 0; i < assemblies.Length; i++)
			{
				System.Type[] types = assemblies[i].GetTypes();
				for (int j = 0; j < types.Length; j++)
				{
					if (types[j].IsSubclassOf(baseType))
					{
						result.Add(types[j]);
					}
				}
			}
			return result.ToArray();
		}
	}
}