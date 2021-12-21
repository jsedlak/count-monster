namespace CountMonster.Extensions
{
    public static class EnumerableExtensions
    {
        public static TValue Median<TInput, TValue>(this IEnumerable<TInput> collection, Func<TInput, TValue> getValue)
        {
            var midpoint = (collection.Count() - 1) / 2;
            var ordered = collection.OrderBy(getValue);
            return getValue(ordered.ElementAt(midpoint));
        }

        public static int FindIndex<TInput>(this IEnumerable<TInput> collection, Func<TInput, bool> predicate)
        {
            int index = 0;

            foreach(var item in collection)
            {
                if(predicate(item))
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        public static TInput? At<TInput>(this IEnumerable<TInput> collection, int index)
        {
            int currentIndex = 0;

            foreach(var item in collection)
            {
                if(currentIndex == index)
                {
                    return item;
                }
            }

            return default;
        }
    }
}
