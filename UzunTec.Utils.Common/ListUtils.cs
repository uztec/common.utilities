using System;
using System.Collections.Generic;

namespace UzunTec.Utils.Common
{
    public static class ListUtils
    {
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

        public static T Max<T>(this IEnumerable<T> list) where T : struct, IComparable<T>
        {
            bool bAssigned = false;
            T output = default(T);

            foreach (T obj in list)
            {
                if (bAssigned)
                {
                    if (obj.CompareTo(output) > 0)
                    {
                        output = obj;
                    }
                }
                else
                {
                    output = obj;
                    bAssigned = true;
                }
            }
            return output;
        }

        public static T Min<T>(this IEnumerable<T> list) where T : struct, IComparable<T>
        {
            bool bAssigned = false;
            T output = default(T);

            foreach (T obj in list)
            {
                if (bAssigned)
                {
                    if (obj.CompareTo(output) < 0)
                    {
                        output = obj;
                    }
                }
                else
                {
                    output = obj;
                    bAssigned = true;
                }
            }
            return output;
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

        public static int CompareList<T>(this IEnumerable<T> list1, IList<T> list2, bool ignoreOrder = false)
            where T : IComparable
        {
            return (list1 == null) ? ((list2 == null) ? 0 : -1) : (list2 == null) ? 1 :
                (ignoreOrder) ? list1.CompareListItemsIgnoreOrder(list2) :
                list1.CompareListItemsSameOrder(list2);
        }

        public static int CompareListItemsIgnoreOrder<T>(this IEnumerable<T> list1, IList<T> list2)
             where T : IComparable
        {
            int i = 0;
            foreach (T obj in list1)
            {
                if (!list2.Contains(obj))
                {
                    return -1;
                }
                i++;
            }
            return i.CompareTo(list2.Count);
        }
        public static int CompareListItemsSameOrder<T>(this IEnumerable<T> list1, IList<T> list2)
                where T : IComparable
        {
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

                int itemCompare = obj?.CompareTo(list2[i]) ?? -1;
                if (itemCompare != 0)
                {
                    return itemCompare;
                }
                i++;
            }
            return i.CompareTo(list2.Count);
        }
    }
}