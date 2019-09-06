using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fjord.Common.Components;

namespace Fjord.Common.Events
{
    public class EventDispatcher : SingletonBehaviour<EventDispatcher>
    {
        /// <summary>
        /// Returns true if an instance exists.
        /// </summary>
        public static bool IsInstantiated { get { return _instance != null; } }

        public bool DoLogging = true;

        [SerializeField]
        private Dictionary<string, StandardEvent> eventMap = new Dictionary<string, StandardEvent>();

        public void RegisterListener(string eventName, UnityAction<object, object> callback)
        {
            if (!eventMap.ContainsKey(eventName))
            {
                eventMap.Add(eventName, new StandardEvent());
            }

            eventMap[eventName].AddListener(callback);
        }
        public void UnregisterListener(string eventName, UnityAction<object, object> callback)
        {
            if (eventMap.ContainsKey(eventName))
            {
                eventMap[eventName].RemoveListener(callback);
                if(eventMap[eventName].GetPersistentEventCount() == 0)
                {
                    eventMap.Remove(eventName);
                }
            }
        }
        public void Dispatch(string eventName, object sender, object eventArg)
        {
            if (DoLogging)
            {
                string eventArgString = eventArg == null ? "(null)" : eventArg.ToString();
                string senderString = sender == null ? "(null)" : sender.ToString();
                Debug.Log("Dispatching event: " + eventName + " " + eventArgString + " for sender: " + senderString);
            }

            if (eventMap.ContainsKey(eventName))
            {
                eventMap[eventName].Invoke(sender, eventArg);
            }
        }
    }
}
