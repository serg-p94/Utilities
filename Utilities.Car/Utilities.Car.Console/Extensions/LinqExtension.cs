using System;
using System.Collections.Generic;

namespace Utilities.Car.Console
{
    public static class LinqExtension
    {
        public static void ForEach<TItem>(this IEnumerable<TItem> items, Action<int, TItem> action)
        {
            var i = 0;
            foreach (var item in items)
            {
                action(i++, item);
            }
        }
    }
}
