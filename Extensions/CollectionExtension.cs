using System;
using System.Collections.Generic;

namespace TransportSystems.Frontend.Extensions
{
    public static class CollectionExtension
	{
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            if (items == null)
            {
                System.Diagnostics.Debug.WriteLine("Do extension metody AddRange byly poslany items == null");
                return;
            }

            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static void ClearAndAddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            collection.Clear();
            collection.AddRange(items);
        }

        public static T Clone<T>(this T obj) where T : ICloneable
        {
            return (T)(obj as ICloneable).Clone();
        }
    }
}