using UnityEngine;

namespace Fjord.Common.Extensions
{
    /// <summary>
    /// Extension methods for UnityEngine.GameObject.
    /// </summary>
    public static class GameObjectExtensions
    {
        public static void RemoveCloneSuffix(this GameObject gameObject)
        {
            gameObject.name = gameObject.name.Replace("(Clone)", "");
        }
    }
}