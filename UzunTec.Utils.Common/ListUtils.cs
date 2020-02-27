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

        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey k, TValue v)
        {
            if (dic.ContainsKey(k))
            {
                dic[k] = v;
            }
            else
            {
                dic.Add(k, v);
            }
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
    }
}