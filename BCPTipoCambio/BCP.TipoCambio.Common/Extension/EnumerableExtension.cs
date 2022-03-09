using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.TipoCambio.Common.Extension
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null) throw new NullReferenceException();
            var list = enumerable.ToList();
            var n = list.Count;
            var rnd = new Random();
            for (int i = n - 1; i > 0; i--)
            {
                var j = rnd.Next(0, i);
                var temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
            return list;
        }

        public static bool HasItems<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }
    }
}
