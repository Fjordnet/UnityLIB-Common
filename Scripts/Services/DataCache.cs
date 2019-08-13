using System.Collections.Generic;
using System.Linq;
using Fjord.Common.Types;

namespace Fjord.Common.Services
{
    /// <summary>
    /// The purpose of this class is to provide an application-side cache of server data
    /// </summary>
    public class DataCache
    {
        #region Internal Types
        /// <summary>
        /// Separated out this interface to allow for multiple DataCacheEntries
        /// each with their own generic type, all managed within one collection
        /// </summary>
        public interface IDataCacheEntry
        {
            int Count { get; }
            DataEntry Find(string id);
            DataEntry[] All();
            void Insert(DataEntry data);
            void Clear(string id);
            void Clear();
        }

        /// <summary>
        /// Represents all instances of one particular type of data.
        /// </summary>
        private class DataCacheEntry : IDataCacheEntry
        {
            private Dictionary<string, DataEntry> _data = new Dictionary<string, DataEntry>();

            public int Count
            {
                get
                {
                    return _data.Count;
                }
            }

            public DataEntry[] All()
            {
                return _data.Values.ToArray();
            }

            public DataEntry Find(string id)
            {
                if (_data.ContainsKey(id))
                {
                    return _data[id];
                }

                return null;
            }

            public void Insert(DataEntry data)
            {
                if (_data.ContainsKey(data.Id))
                {
                    _data[data.Id] = data;
                }
                else
                {
                    _data.Add(data.Id, data);
                }
            }

            public void Clear(string id)
            {
                if (_data.ContainsKey(id))
                {
                    _data.Remove(id);
                }
            }

            public void Clear()
            {
                _data.Clear();
            }
        }
        #endregion

        #region Private Members
        /// <summary>
        /// Usage: _cacheEntries[typeof(T).Name] = cacheEntry
        /// </summary>
        private Dictionary<string, IDataCacheEntry> _cacheEntries = new Dictionary<string, IDataCacheEntry>();
        #endregion

        #region Cached Data Accessors
        /// <summary>
        /// Inserts the specified data into the cache. The key defaults
        /// to the name of the data type.
        /// </summary>
        /// <param name="data">The data to insert.</param>
        public void InsertData<T>(T data) where T : DataEntry
        {
            string key = typeof(T).Name;
            InsertData(key, data);
        }

        /// <summary>
        /// Inserts the specified data into the cache with the key "type".
        /// </summary>
        /// <param name="type">The key to insert this data at, which should correspond to the System.Type of the "data" parameter.</param>
        /// <param name="data">The data to insert.</param>
        public void InsertData(string type, DataEntry data)
        {
            if (!_cacheEntries.ContainsKey(type))
            {
                _cacheEntries.Add(type, new DataCacheEntry());
            }
            _cacheEntries[type].Insert(data);
        }

        public void InsertData<T>(IEnumerable<T> data) where T : DataEntry
        {
            InsertData(typeof(T).Name, data.Cast<DataEntry>());
        }

        public void InsertData(string type, IEnumerable<DataEntry> data)
        {
            IEnumerator<DataEntry> iterator = data.GetEnumerator();
            while (iterator.MoveNext())
            {
                InsertData(type, iterator.Current);
            }
        }

        /// <summary>
        /// Returns a specific DataEntry with type T and ID id.
        /// </summary>
        /// <typeparam name="T">The type of data to return.</typeparam>
        /// <param name="id">The ID of the specific DataEntry.</param>
        public T GetData<T>(string id) where T : DataEntry
        {
            string key = typeof(T).Name;
            if (_cacheEntries.ContainsKey(key))
            {
                return (T)_cacheEntries[key].Find(id);
            }

            return null;
        }

        /// <summary>
        /// Returns all data of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of data to return.</typeparam>
        public T[] GetData<T>() where T : DataEntry
        {
            string key = typeof(T).Name;
            if (_cacheEntries.ContainsKey(key))
            {
                return _cacheEntries[key].All().Cast<T>().ToArray();
            }

            return null;
        }
        /// <summary>
        /// Removes a specific DataEntry with type T and ID id.
        /// </summary>
        /// <typeparam name="T">The type of data to remove.</typeparam>
        /// <param name="id">The ID of the specific DataEntry.</param>
        public void ClearData<T>(string id) where T : DataEntry
        {
            string key = typeof(T).Name;
            if (_cacheEntries.ContainsKey(key))
            {
                _cacheEntries[key].Clear(id);
                if (_cacheEntries[key].Count == 0)
                {
                    _cacheEntries.Remove(key);
                }
            }
        }
        /// <summary>
        /// Removes all data of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of data to remove.</typeparam>
        public void ClearData<T>() where T : DataEntry
        {
            string key = typeof(T).Name;
            if (_cacheEntries.ContainsKey(key))
            {
                _cacheEntries[key].Clear();
                _cacheEntries.Remove(key);
            }
        }
        #endregion
    }
}