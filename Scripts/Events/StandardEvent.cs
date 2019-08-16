using UnityEngine.Events;

namespace Fjord.Common.Events
{
    /// <summary>
    /// Parameters: sender, eventArg
    /// </summary>
    [System.Serializable]
    public class StandardEvent : UnityEvent<object, object> { }
}