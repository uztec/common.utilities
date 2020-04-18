using System.Collections;
using System.Collections.Generic;

namespace UzunTec.Utils.Common
{
    public static class DictionaryUtils
    {
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }

        public static void AddOrIgnore<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey key, TValue value)
        {
            if (!dic.ContainsKey(key))
            {
                dic.Add(key, value);
            }
        }

        public static TKey GetKeyOfValue<TKey, TValue>(this IDictionary<TKey, TValue> dic, TValue value)
        {
            foreach (TKey k in dic.Keys)
            {
                if (dic[k].Equals(value))
                {
                    return k;
                }
            }
            throw new KeyNotFoundException();
        }

        public static TKey FirstKey<TKey, TValue>(this IDictionary<TKey, TValue> dic)
        {
            foreach (TKey key in dic.Keys)
            {
                return key;
            }
            return default(TKey);
        }

        public static TKey LastKey<TKey, TValue>(this IDictionary<TKey, TValue> dic)
        {
            TKey lastKey = default(TKey);
            foreach (TKey key in dic.Keys)
            {
                lastKey = key;
            }
            return lastKey;
        }

        public static IList ToBindingList<Tkey, TValue>(this IDictionary<Tkey, TValue> dic)
        {
            return new List<KeyValuePair<Tkey, TValue>>(dic);
        }
    }
}
