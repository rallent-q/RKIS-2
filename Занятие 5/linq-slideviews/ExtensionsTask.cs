using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
    public static class ExtensionsTask
    {
        public static double GetMedian(this IEnumerable<double> items)
        {
            var listOfItems = items.ToList();
            listOfItems.Sort();
            if (listOfItems.Count == 0)
                throw new InvalidOperationException();
            else if (listOfItems.Count % 2 == 1)
                return listOfItems[listOfItems.Count / 2];
            else
                return (listOfItems[listOfItems.Count / 2 - 1] + listOfItems[listOfItems.Count / 2]) / 2;
        }
        public static IEnumerable<Tuple<T, T>> GetBigrams<T>(this IEnumerable<T> items)
        {
            T tempFirst = default(T);
            bool isTempTupleEmpty = true;
            foreach (var item in items)
            {
                if (isTempTupleEmpty)
                {
                    tempFirst = item;
                    isTempTupleEmpty = false;
                }
                else
                {
                    yield return new Tuple<T, T>(tempFirst, item);
                    tempFirst = item;
                }
            }
        }
    }
}
