using System;
using System.Collections;
using System.Collections.Generic;

namespace UzunTec.Utils.Common
{
    public static class ListUtils
    {
        public static IList ToBindingList<Tkey, TValue>(this IDictionary<Tkey, TValue> dic)
        {
            return new List<KeyValuePair<Tkey, TValue>>(dic);
        }

        public static List<T> Filter<T>(this IEnumerable<T> list, Predicate<T> match)
        {
            List<T> output = new List<T>();
            foreach (T obj in list)
            {
                if (match(obj))
                {
                    output.Add(obj);
                }
            }
            return output;
        }


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

        public static IList<T> ConcatList<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
        {
            List<T> output = new List<T>();
            output.AddRange(list1);
            output.AddRange(list2);
            return output;
        }

        public static IDictionary<TKey, TValue> MakeKeyDictionary<TKey, TValue>(this IEnumerable<TValue> list, Func<TValue, TKey> extractKeyMethod)
        {
            IDictionary<TKey, TValue> output = new Dictionary<TKey, TValue>();
            foreach (TValue val in list)
            {
                output.Add(extractKeyMethod(val), val);
            }
            return output;
        }

        public static IDictionary<TKey, List<TValue>> DivideByGroup<TKey, TValue>(this IEnumerable<TValue> list, Func<TValue, TKey> extractGroupMethod)
        {
            IDictionary<TKey, List<TValue>> output = new Dictionary<TKey, List<TValue>>();

            foreach (TValue val in list)
            {
                TKey groupKey = extractGroupMethod(val);
                if (!output.TryGetValue(groupKey, out List<TValue> valueList))
                {
                    valueList = new List<TValue>();
                    output.Add(groupKey, valueList);
                }
                valueList.Add(val);
            }
            return output;
        }

        public static int CompareTo<T>(this IEnumerable<T> list1, IList<T> list2)
        {
            if (list1 == null || list2 == null)
            {
                return -1;
            }

            int i = 0;
            foreach (T obj in list1)
            {
                if (list2.Count < (i + 1))
                {
                    return -1;
                }

                if (obj == null && list2[i] == null)
                {
                    continue;
                }

                if (!obj?.Equals(list2[i]) ?? false)
                {
                    return -1;
                }
                i++;
            }
            return i.CompareTo(list2.Count);
        }
    }
}