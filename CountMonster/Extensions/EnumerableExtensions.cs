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
    }
}
