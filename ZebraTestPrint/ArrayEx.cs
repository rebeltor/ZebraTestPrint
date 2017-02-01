using System;
using System.Collections.Generic;
using System.Text;

namespace ZebraTestPrint
{
    public class ArrayEx
    {
        public static bool Equals(object[] a, object[] b)
        {
            return Equals<object>(a, b, true);
        }
        public static bool Equals(object[] a, object[] b, bool order_must_be_preserved)
        {
            return Equals<object>(a, b, order_must_be_preserved);
        }
        public static bool Equals<T>(T[] a, T[] b)
        {
            return Equals<T>(a, b, true);
        }
        public static bool Equals<T>(T[] a, T[] b, bool order_must_be_preserved)
        {
            if (!Misc.EqualNullality(a, b)) { return false; }
            if ((a == null) && (b == null)) { return true; }
            if (a.Length != b.Length) { return false; }

            for (int i = 0; i < a.Length; i++)
            {
                if (order_must_be_preserved)
                {
                    if (!a[i].Equals(b[i])) { return false; }
                }
                else
                {
                    bool found = false;
                    foreach (T _b_ in b)
                    {
                        if (_b_.Equals(a[i]))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found) { return false; }
                }
            }

            return true;
        }
        public static bool Equals<T>(ICollection<T> a, ICollection<T> b)
        {
            if (!Misc.EqualNullality(a, b)) { return false; }
            if ((a == null) && (b == null)) { return true; }
            if (a.Count != b.Count) { return false; }

            foreach (T _a_ in a)
            {
                bool found = false;
                foreach (T _b_ in b)
                {
                    if (Misc.NullSafeEquals<T>(_a_, _b_))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found) { return false; }
            }

            return true;
        }

        public static bool Exists<T>(T[] a, T b)
        {
            foreach (T _a_ in a)
            {
                if (_a_.Equals(b))
                {
                    return true;
                }
            }

            return false;
        }
        public static bool Exists<T>(ICollection<T> a, T b)
        {
            foreach (T _a_ in a)
            {
                if (_a_.Equals(b))
                {
                    return true;
                }
            }

            return false;
        }

        public static T[] MergeUnique<T>(T[] a, T[] b)
        {
            List<T> retval = new List<T>(a.Length + b.Length);
            retval.AddRange(a);
            foreach (T item in b)
            {
                if (!retval.Contains(item))
                {
                    retval.Add(item);
                }
            }
            return retval.ToArray();
        }

        public static int? GetIndexBinarySearch<T>(
            IList<T> array, BinarySearchComparison<T> comparison)
            where T : struct
        {
            return GetIndexBinarySearch<T>(array, comparison, null);
        }
        public static int? GetIndexBinarySearch<T>(
            IList<T> array, BinarySearchComparison<T> comparison, int? default_value)
            where T : struct
        {
            int min = 0;
            int max = array.Count - 1;
            while (true)
            {
                int middle = (max - min) / 2 + min;
                int result = comparison(array[middle]);

                if (result == 0) { return middle; }
                else if (result < 0) { min = middle + 1; }
                else { max = middle - 1; }

                if ((max < min) || (min > max) ||
                    (min < 0) || (max >= array.Count))
                {
                    return default_value;
                }
            }
        }
        
        public static T[] Concatenate<T>(T[] a, T[] b)
        {
            T[] joint_array = new T[a.LongLength + b.LongLength];
            Array.Copy(a, 0, joint_array, 0, a.LongLength);
            Array.Copy(b, 0, joint_array, a.LongLength, b.LongLength);
            return joint_array;
        }
        public static T[] Concatenate<T>(T[] a, T b)
        {
            T[] joint_array = new T[a.LongLength + 1];
            Array.Copy(a, 0, joint_array, 0, a.LongLength);
            joint_array[a.LongLength] = b;
            return joint_array;
        }
       
        public static T Max<T>(T[] array) where T : IComparable
        {
            if (array.Length > 0)
            {
                T retval = array[0];
                foreach (T item in array)
                {
                    if (item.CompareTo(retval) > 0) { retval = item; }
                }
                return retval;
            }
            else throw new IndexOutOfRangeException();
        }
        public static T Max<T>(T a, T b) where T : IComparable
        {
            return Max<T>(new T[] { a, b });
        }
        public static T Max<T>(T a, T b, T c) where T : IComparable
        {
            return Max<T>(new T[] { a, b, c });
        }
        public static T Max<T>(T a, T b, T c, T d) where T : IComparable
        {
            return Max<T>(new T[] { a, b, c });
        }

        public static T Min<T>(T[] array) where T : IComparable
        {
            if (array.Length > 0)
            {
                T retval = array[0];
                foreach (T item in array)
                {
                    if (item.CompareTo(retval) < 0) { retval = item; }
                }
                return retval;
            }
            else throw new IndexOutOfRangeException();
        }
        public static T Min<T>(T a, T b) where T : IComparable
        {
            return Min<T>(new T[] { a, b });
        }
        public static T Min<T>(T a, T b, T c) where T : IComparable
        {
            return Min<T>(new T[] { a, b, c });
        }
        public static T Min<T>(T a, T b, T c, T d) where T : IComparable
        {
            return Min<T>(new T[] { a, b, c });
        }

        public static T[] ToArray<T>(IEnumerable<T> values)
        {
            return new List<T>(values).ToArray();
        }
        public static T[] ToArray<T>(T item)
        {
            T[] array = new T[1];
            array[0] = item;
            return array;
        }
        
        public static T LastItem<T>(T[] a)
        {
            return a[a.Length - 1];
        }
        public static T LastItem<T>(IList<T> a)
        {
            return a[a.Count - 1];
        }

        public static bool IsLast<T>(T[] a, T value)
        {
            return LastItem<T>(a).Equals(value);
        }
        public static bool IsLast<T>(IList<T> a, T value)
        {
            return LastItem<T>(a).Equals(value);
        }

        public static double Average(ICollection<double> values)
        {
            double total = 0.0d;
            foreach (double value in values)
            {
                total += value;
            }
            return total / values.Count;
        }
        
        public static string[] ToStringArray(Type type)
        {
            if (!type.IsSubclassOf(typeof(Enum)))
            {
                throw new InvalidCastException("This function can only be run on Enum data types");
            }

            List<string> retval = new List<string>();
            foreach (Enum enum_value in Enum.GetValues(type))
            {
                retval.Add(enum_value.ToString());
            }
            return retval.ToArray();
        }

        /// <summary>
        /// Returns a count of all items in all arrays in the dictionary
        /// </summary>
        public static int Count<T, U>(IDictionary<T, List<U>> dictionary)
        {
            int count = 0;
            foreach (T key in dictionary.Keys)
            {
                count += dictionary[key].Count;
            }
            return count;
        }

        public static int CountWhere<T>(T[] a, Predicate<T> condition)
        {
            int count = 0;
            foreach (T item in a)
            {
                if (condition(item))
                {
                    count++;
                }
            }
            return count;
        }
        public static int CountWhere<T>(IList<T> a, Predicate<T> condition)
        {
            int count = 0;
            foreach (T item in a)
            {
                if (condition(item))
                {
                    count++;
                }
            }
            return count;
        }

        public static void RemoveDuplicates<T>(ref T[] a)
        {
            List<T> list = new List<T>(a);
            RemoveDuplicates<T>(ref list);
            a = list.ToArray();
        }
        public static void RemoveDuplicates<T>(ref List<T> a)
        {
            List<int> indexes_to_remove = new List<int>();

            // first, go through the array, and find any item which exists more than once
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = i + 1; j < a.Count; j++)
                {
                    if (Misc.NullSafeEquals<T>(a[i], a[j]) &&
                        (!indexes_to_remove.Contains(j)))
                    {
                        indexes_to_remove.Add(j);
                    }
                }
            }

            // we need to start at the end & move forward, otherwise as we delete items,
            // the indexes of the items we need to remove would be adjusted
            for (int i = indexes_to_remove.Count - 1; i >= 0; i--)
            {
                a.RemoveAt(indexes_to_remove[i]);
            }
        }

        public static bool IsNullOrEmpty<T>(T[] a)
        {
            return (a == null) || (a.Length == 0);
        }
        public static bool IsNullOrEmpty<T>(IList<T> a)
        {
            return (a == null) || (a.Count == 0);
        }

        /// <summary>
        /// Returns an array of all array elements which match the given predicate
        /// </summary>
        /// <typeparam name="T">The data type of the array</typeparam>
        /// <param name="a">The source array to filter</param>
        /// <param name="condition">The condition returned array items must match</param>
        /// <returns>The source array, filtered based upon the given predicate</returns>
        public static T[] Where<T>(T[] a, Predicate<T> condition)
        {
            List<T> results = new List<T>(a.Length);
            foreach (T item in a)
            {
                if (condition(item))
                {
                    results.Add(item);
                }
            }
            return results.ToArray();
        }
        /// <summary>
        /// Returns an array of all array elements which match the given predicate
        /// </summary>
        /// <typeparam name="T">The data type of the array</typeparam>
        /// <param name="a">The source array to filter</param>
        /// <param name="condition">The condition returned array items must match</param>
        /// <returns>The source array, filtered based upon the given predicate</returns>
        public static T[] Where<T>(IList<T> a, Predicate<T> condition)
        {
            List<T> results = new List<T>(a.Count);
            foreach (T item in a)
            {
                if (condition(item))
                {
                    results.Add(item);
                }
            }
            return results.ToArray();
        }

        public static U[] Convert<T, U>(T[] a, Converter<T, U> converter)
        {
            U[] b = new U[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                b[i] = converter(a[i]);
            }
            return b;
        }
    }

    public delegate int BinarySearchComparison<T>(T a);
}