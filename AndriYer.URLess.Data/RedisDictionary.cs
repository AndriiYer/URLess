using StackExchange.Redis;
using System;
using System.Collections;

namespace AndriYer.URLess.Data
{
    public class RedisDictionary : IDictionary<string, string?>
    {
        private readonly IDatabase _db;
        public RedisDictionary(string configuration)
        {
            var redis = ConnectionMultiplexer.Connect(configuration);
            _db = redis.GetDatabase();
        }
        
        public ICollection<string> Keys => throw new NotImplementedException();
        
        public ICollection<string?> Values => throw new NotImplementedException();
        
        public int Count => throw new NotImplementedException();
        
        public bool IsReadOnly => false;
        
        public string? this[string key]
        {
            get => _db.StringGet(key);
            set => _db.StringSet(key, value);
        }
        
        public void Add(string key, string value)
        {
            _db.StringSet(key, value);
        }
        
        public void Add(KeyValuePair<string, string> item)
        {
            _db.StringSet(item.Key, item.Value);
        }
        
        public void Clear()
        {
            // Not supported in Redis
            throw new NotSupportedException();
        }
        
        public bool Contains(KeyValuePair<string, string> item)
        {
            var value = _db.StringGet(item.Key);
            return value.HasValue && value == item.Value;
        }
        
        public bool ContainsKey(string key)
        {
            return _db.KeyExists(key);
        }
        
        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            // Not supported in Redis
            throw new NotSupportedException();
        }
        
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            // Not supported in Redis
            throw new NotSupportedException();
        }
        
        public bool Remove(string key)
        {
            return _db.KeyDelete(key);
        }
        
        public bool Remove(KeyValuePair<string, string> item)
        {
            if (Contains(item))
            {
                return _db.KeyDelete(item.Key);
            }
            return false;
        }
        
        public bool TryGetValue(string key, out string value)
        {
            var redisValue = _db.StringGet(key);
            if (redisValue.HasValue)
            {
                value = redisValue;
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Not supported in Redis
            throw new NotSupportedException();
        }
    }
}
