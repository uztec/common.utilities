using System;
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

        public static IList ToBindingList<TKey, TValue>(this IDictionary<TKey, TValue> dic)
        {
            return new List<KeyValuePair<TKey, TValue>>(dic);
        }

        public static int CompareDictionary<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> dic, bool ignoreOrder = false)
            where TKey : IComparable
            where TValue : IComparable
        {
            if (source == null)
            {
                return (dic == null) ? 0 : -1;
            }
            else if (dic == null)
            {
                return 1;
            }

            int countCompare = source.Count.CompareTo(dic.Count);
            return (countCompare != 0) ? countCompare :
                (ignoreOrder) ? source.CompareDictionaryItemsIgnoreOrder(dic) :
                source.CompareDictionaryItemsSameOrder(dic);
        }

        private static int CompareDictionaryItemsSameOrder<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> dic)
            where TKey : IComparable
            where TValue : IComparable
        {
            List<TKey> dicKeyList = new List<TKey>(dic.Keys);
            int keyCompare = source.Keys.CompareList(dicKeyList, false);

            if (keyCompare == 0)
            {
                List<TValue> dicValueList = new List<TValue>(dic.Values);
                return source.Values.CompareList(dicValueList);
            }

            return keyCompare;
        }

        private static int CompareDictionaryItemsIgnoreOrder<TKey, TValue>(this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> dic)
            where TKey : IComparable
            where TValue : IComparable
        {
            foreach (TKey k in source.Keys)
            {
                if (dic.TryGetValue(k, out TValue v))
                {
                    int valueCompare = v.CompareTo(source[k]);
                    if (valueCompare != 0)
                    {
                        return valueCompare;
                    }
                }
                else
                {
                    return -1;
                }
            }
            return 0;
        }

        public static void AddRangeOverrideExisiting<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ForEach(x => dic.AddOrUpdate(x.Key, x.Value));
        }

        public static void AddRangeIgnoreExisting<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ForEach(x => dic.AddOrIgnore(x.Key, x.Value));

        }

        public static void AddRange<TKey, TValue>(this IDictionary<TKey, TValue> dic, IDictionary<TKey, TValue> dicToAdd)
        {
            dicToAdd.ForEach(x => dic.Add(x.Key, x.Value));
        }

        public static bool ContainsKeys<TKey, TValue>(this IDictionary<TKey, TValue> dic, IEnumerable<TKey> keys)
        {
            bool result = false;
            keys.ForEachOrBreak((x) => 
            { 
                result = dic.ContainsKey(x); 
                return result;
            });
            return result;
        }
    }
}
