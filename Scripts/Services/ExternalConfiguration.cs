using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fjord.Common.Types;
using System.IO;

namespace Fjord.Common.Services
{
    /// <summary>
    /// Allows access to variables set in external configuration. Any value which ends in
    /// _ip will be tested to see if the ip responds to a ping, the working one will then be
    /// stored in ValidIPs.
    /// </summary>
    public class ExternalConfiguration : MonoBehaviour
    {
        [SerializeField]
        protected string _path = "/../configuration.json";

        [Header("How many milliseconds to wait for ping respond")]
        [SerializeField]
        protected int _millisecondsPingResponse = 1000;

        protected SerializableDictionary _configuration;
        protected Dictionary<string, string> _validIPs = new Dictionary<string, string>();

        private void Awake()
        {
            _path = Application.dataPath + _path;
            if (File.Exists(_path))
            {
                string json = File.ReadAllText(_path);
                _configuration = JsonUtility.FromJson<SerializableDictionary>(json);
                Debug.Log("Configuration loaded from " + _path);
                TestForValidIPs();
            }
        }

        /// <summary>
        /// Find any key directly from configuration file.
        /// </summary>
        public string Find(string key)
        {
            return _configuration.Find(key);
        }

        /// <summary>
        /// Find an IP by key, will only return if it responded to a ping.
        /// IP's are tested in Awake and will not be available until Start.
        /// </summary>
        public string FindValidIP(string key)
        {
            string value;
            _validIPs.TryGetValue(key, out value);
            return value;
        }

        protected virtual void TestForValidIPs()
        {
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            for (int i = 0; i < _configuration.Count; ++i)
            {
                if (_configuration[i].Key.Contains("_ip") && !_validIPs.ContainsKey(_configuration[i].Key))
                {
                    stopwatch.Start();
                    Ping ping = new Ping(_configuration[i].Value);
                    while (!ping.isDone && stopwatch.ElapsedMilliseconds < _millisecondsPingResponse)
                    { }
                    if (ping.isDone)
                    {
                        Debug.Log("Ping Succeeded, storing as valid. Key: " + _configuration[i].Key + " Value: " + _configuration[i].Value);
                        _validIPs[_configuration[i].Key] = _configuration[i].Value;
                    }
                    else
                    {
                        Debug.Log("Ping Failed. " + _configuration[i].Value);
                    }
                    stopwatch.Reset();
                }
            }
        }

        [ContextMenu("Write Template Configuration")]
        private void WriteConfigurationFile()
        {
            SerializableDictionary serializableDictionary = new SerializableDictionary();
            serializableDictionary.Add("ip", "192.168.0.1");
            string json = JsonUtility.ToJson(serializableDictionary);
            File.WriteAllText(_path, json);
            Debug.Log("Wrote template configuration file to " + _path);
        }
    }
}