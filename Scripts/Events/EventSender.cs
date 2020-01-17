using UnityEngine;

namespace Fjord.Common.Events
{
    /// <summary>
    /// Enables on-demand sending of specified events.
    /// </summary>
    public class TriggerDispatchEvent : MonoBehaviour
    {
        private void TriggerDispatch(string eventName, object eventArg)
        {
            EventDispatcher.Instance.Dispatch(eventName, this, null);
        }
    }
}
