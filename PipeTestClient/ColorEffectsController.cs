using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeTestClient
{
    public static class ColorEffectsController
    {
        public static IEnumerable<T[]> Split<T>(this T[] source, int length)
        {
            int arrayLength = source.Length;

            int resultCount = (int)Math.Ceiling((double)arrayLength / (double)length);

            for (int i = 0; i < resultCount; i++)
            {
                var completed = i * length;
                var actualSize = Math.Min(arrayLength - completed, length);

                T[] slice = new T[actualSize];
                Array.Copy(source, completed, slice, 0, actualSize);

                yield return slice;
            }
        }

        public static string[] ToToucanOrder(string[] colors)
        {
            return new string[]
            {
                colors[13],
                colors[12],
                colors[15],
                colors[14],
                colors[1],
                colors[0],
                colors[11],
                colors[10],
                colors[9],
                colors[8],
                colors[7],
                colors[6],
                colors[5],
                colors[4],
                colors[3],
                colors[2]
            };
        }
    }
}
