using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementMyList
{
    public static class EnumerableExtensions
    {
        public static MyList<T> ToMyList<T>(this IEnumerable<T> enumerable)
        {
            var list = new MyList<T>();
            foreach (var item in enumerable)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
