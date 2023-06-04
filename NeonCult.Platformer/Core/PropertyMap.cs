using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeonCult.Platformer.Core
{
    public class PropertyMap : IDictionary<string, string>
    {

        private readonly Dictionary<string, string> _properties = new Dictionary<string, string>();

        public string this[string key] { get => ((IDictionary<string, string>)_properties)[key]; set => ((IDictionary<string, string>)_properties)[key] = value; }

        public ICollection<string> Keys => ((IDictionary<string, string>)_properties).Keys;

        public ICollection<string> Values => ((IDictionary<string, string>)_properties).Values;

        public int Count => ((ICollection<KeyValuePair<string, string>>)_properties).Count;

        public bool IsReadOnly => ((ICollection<KeyValuePair<string, string>>)_properties).IsReadOnly;

        public void Add(string key, string value)
        {
            ((IDictionary<string, string>)_properties).Add(key, value);
        }

        public void Add(KeyValuePair<string, string> item)
        {
            ((ICollection<KeyValuePair<string, string>>)_properties).Add(item);
        }

        public void Clear()
        {
            ((ICollection<KeyValuePair<string, string>>)_properties).Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return ((ICollection<KeyValuePair<string, string>>)_properties).Contains(item);
        }

        public bool ContainsKey(string key)
        {
            return ((IDictionary<string, string>)_properties).ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, string>>)_properties).CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, string>>)_properties).GetEnumerator();
        }

        public bool Remove(string key)
        {
            return ((IDictionary<string, string>)_properties).Remove(key);
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return ((ICollection<KeyValuePair<string, string>>)_properties).Remove(item);
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            return ((IDictionary<string, string>)_properties).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_properties).GetEnumerator();
        }

        public int GetInt(string key)
        {
            return Convert.ToInt32(_properties[key]);
        }

        public bool GetBoolean(string key)
        {
            return Convert.ToBoolean(_properties[key]);
        }

        public double GetDouble(string key)
        {
            return Convert.ToDouble(_properties[key]);
        }

        public float GetFloat(string key)
        {
            return Convert.ToSingle(_properties[key]);
        }

    }
}
