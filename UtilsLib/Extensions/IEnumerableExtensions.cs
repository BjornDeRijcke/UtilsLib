using System;
using System.Collections.Generic;

namespace UtilsLib.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TSource> Distinct<TSource, TProperty>(this IEnumerable<TSource> source, Func<TSource, TProperty> equalityProperty)
        {
            if (source != null)
            {
                HashSet<TProperty> seenKeys = new HashSet<TProperty>();
                foreach (var elem in source)
                {
                    if (seenKeys.Add(equalityProperty(elem)))
                    {
                        yield return elem;
                    }
                }
            }
        }
    }
}
