using System;
using System.Collections.Generic;

namespace UtilsLib.Extensions
{
    public static class ListExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static IEnumerable<List<T>> Split<T>(this List<T> list, int size)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            if (list.Count <= size)
            {
                yield return new List<T>(list);
            }
            else
            {
                for (int i = 0; i < list.Count; i += size)
                {
                    yield return list.GetRange(i, System.Math.Min(size, list.Count - i));
                }
            }
        }

        public static void ExtractFirst<T>(this List<T> list, out T extractedItem)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            if (list.Count < 1)
            {
                extractedItem = default(T);
            }
            else
            {
                extractedItem = list[0];
                list.Remove(extractedItem);
            }
        }
    }
}
