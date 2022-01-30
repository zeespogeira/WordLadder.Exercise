using System.Collections.Generic;
using System.Linq;

namespace WordLadder.Exercise.Misc
{
    public static class ListExtensions
    {
        public static IEnumerable<string> Trim(this IEnumerable<string> enumerable)
        {
            return enumerable.Select(x => x.Trim());
        }

        public static IEnumerable<string> RemoveDuplicates(this IEnumerable<string> enumerable)
        {
            return enumerable.Distinct();
        }

        public static IEnumerable<string> FilterWithSizeOf(this IEnumerable<string> enumerable, int size)
        {
            return enumerable.Where(word => word.Length == size);
        }
    }
}
