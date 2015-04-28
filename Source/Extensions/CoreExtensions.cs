﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FingerboxLib
{
    public static class CoreExtensions
    {
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            if (value.CompareTo(max) > 0) return max;
            return value;
        }

        public static IEnumerable<T> TakePercent<T>(this ICollection<T> source, double percent)
        {
            int sourceCount = source.Count;
            int percentageCount = (int) Math.Ceiling(sourceCount * (percent / 100));

            return source.Take(percentageCount);
        }

        public static T RandomElement<T>(this IEnumerable<T> source, Random rng)
        {
            T current = default(T);
            int count = 0;
            foreach (T element in source)
            {
                count++;
                if (rng.Next(count) == 0)
                {
                    current = element;
                }
            }
            if (count == 0)
            {
                throw new InvalidOperationException("Sequence was empty");
            }
            return current;
        }
    }    
}
