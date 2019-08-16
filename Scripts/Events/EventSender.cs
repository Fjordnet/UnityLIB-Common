using UnityEngine;

namespace Fjord.Common.Events
{
    public class TriggerDispatchEvent : MonoBehaviour
    {
        private void TriggerDispatch(string eventName, object eventArg)
        {
            EventDispatcher.Instance.Dispatch(eventName, this, null);
        }
    }
}
