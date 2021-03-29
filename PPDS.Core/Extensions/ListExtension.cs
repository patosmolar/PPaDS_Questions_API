using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPDS.Core.Extensions
{
    public static class ListExtension
    {
        public static void PrependTillIndex<T>(this IList<T> collection, int index, T element)
        {
            int i = collection.Count;
            while(i <= index)
            {
                collection.Add(element);
                i++;
            }
        }
    }
}
