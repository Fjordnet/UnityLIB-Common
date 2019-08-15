using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Fjord.Common.Services
{
    public class EventDispatcher : MonoBehaviour
    {
        // Use this to check if EventDispatcher is currently active without attempting
        // to activate it in the process.
        public static bool IsInstantiated { get { return _instance != null; } }


        private static EventDispatcher _instance;
        public static EventDispatcher instance
        {
            get
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                    return null;
#endif


                if (_instance == null)
                {
                    _instance = CreateInstance();

                }

                return _instance;
            }
        }

        static EventDispatcher CreateInstance()
        {
            EventDispatcher newInstance = null;
            GameObject go = GameObject.Find("EventDispatcher");

            if (go != null)
            {
                newInstance = go.GetComponent<EventDispatcher>();
            }

            if (newInstance == null)
            {
                go = new GameObject("EventDispatcher");
                go.hideFlags = HideFlags.DontSave;

                newInstance = go.AddComponent<EventDispatcher>();
            }
            DontDestroyOnLoad(go);

            return newInstance;
        }
        
        [System.Serializable]
        public class StandardEvent : UnityEvent<object>
        {}
        
        [SerializeField]
        private Dictionary<string, StandardEvent> eventMap = new Dictionary<string, StandardEvent>();

        public void RegisterListener(string eventName, UnityAction<object> callback)
        {
            if (!eventMap.ContainsKey(eventName))
            {
                eventMap.Add(eventName, new StandardEvent());
            }
            eventMap[eventName].AddListener(callback);
        }
        public void UnregisterListener(string eventName, UnityAction<object> callback)
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
        public void Dispatch(string eventName, object payload)
        {
            Debug.Log("Dispatching Event : " + eventName + " " + payload);
            if (eventMap.ContainsKey(eventName))
            {
                eventMap[eventName].Invoke(payload);
            }
        }
    }
}
