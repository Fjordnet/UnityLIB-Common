using UnityEngine;

namespace Fjord.Common.Extensions
{
    public static class GameObjectExtensions
    {
        public static void RemoveCloneSuffix(this GameObject gameObject)
        {
            gameObject.name = gameObject.name.Replace("(Clone)", "");
        }
    }
}