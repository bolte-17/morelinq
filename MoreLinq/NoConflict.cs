#region License and Terms
// MoreLINQ - Extensions to LINQ to Objects
// Copyright (C) 2008 Jonathan Skeet.
// Portions Copyright (C) 2009 Atif Aziz, Chris Ammerman, Konrad Rudolph.
// Portions Copyright (C) 2010 Johannes Rudolph, Leopold Bushkin.
// Portions Copyright (C) 2015 Felipe Sateler, "sholland".
// Portions Copyright (C) 2016 Leandro F. Vieira (leandromoh).
// Portions Copyright (C) Microsoft. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

namespace MoreLinq.NoConflict
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary><c>Acquire</c> extension.</summary>
    public static partial class AcquireExtension
    {
        /// <summary>
        /// Ensures that a source sequence of <see cref = "IDisposable"/> 
        /// objects are all acquired successfully. If the acquisition of any 
        /// one <see cref = "IDisposable"/> fails then those successfully 
        /// acquired till that point are disposed.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in <paramref name = "source"/> sequence.</typeparam>
        /// <param name = "source">Source sequence of <see cref = "IDisposable"/> objects.</param>
        /// <returns>
        /// Returns an array of all the acquired <see cref = "IDisposable"/>
        /// object and in source order.
        /// </returns>
        /// <remarks>
        /// This operator executes immediately.
        /// </remarks>
        public static TSource[] Acquire<TSource>(this IEnumerable<TSource> source)where TSource : IDisposable
        {
            return MoreEnumerable.Acquire(source);
        }
    }

    /// <summary><c>Assert</c> extension.</summary>
    public static partial class AssertExtension
    {
        /// <summary>
        /// Asserts that all elements of a sequence meet a given condition
        /// otherwise throws an <see cref = "Exception"/> object.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in <paramref name = "source"/> sequence.</typeparam>
        /// <param name = "source">Source sequence.</param>
        /// <param name = "predicate">Function that asserts an element of the <paramref name = "source"/> sequence for a condition.</param>
        /// <returns>
        /// Returns the original sequence.
        /// </returns>
        /// <exception cref = "InvalidOperationException">The input sequence
        /// contains an element that does not meet the condition being 
        /// asserted.</exception>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        public static IEnumerable<TSource> Assert<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return MoreEnumerable.Assert(source, predicate);
        }
    }

    /// <summary><c>Assert</c> extension.</summary>
    public static partial class AssertExtension
    {
        /// <summary>
        /// Asserts that all elements of a sequence meet a given condition
        /// otherwise throws an <see cref = "Exception"/> object.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in <paramref name = "source"/> sequence.</typeparam>
        /// <param name = "source">Source sequence.</param>
        /// <param name = "predicate">Function that asserts an element of the input sequence for a condition.</param>
        /// <param name = "errorSelector">Function that returns the <see cref = "Exception"/> object to throw.</param>
        /// <returns>
        /// Returns the original sequence.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        public static IEnumerable<TSource> Assert<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, Func<TSource, Exception> errorSelector)
        {
            return MoreEnumerable.Assert(source, predicate, errorSelector);
        }
    }

    /// <summary><c>AssertCount</c> extension.</summary>
    public static partial class AssertCountExtension
    {
        /// <summary>
        /// Asserts that a source sequence contains a given count of elements.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in <paramref name = "source"/> sequence.</typeparam>
        /// <param name = "source">Source sequence.</param>
        /// <param name = "count">Count to assert.</param>
        /// <returns>
        /// Returns the original sequence as long it is contains the
        /// number of elements specified by <paramref name = "count"/>.
        /// Otherwise it throws <see cref = "Exception"/>.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        public static IEnumerable<TSource> AssertCount<TSource>(this IEnumerable<TSource> source, int count)
        {
            return MoreEnumerable.AssertCount(source, count);
        }
    }

    /// <summary><c>AssertCount</c> extension.</summary>
    public static partial class AssertCountExtension
    {
        /// <summary>
        /// Asserts that a source sequence contains a given count of elements.
        /// A parameter specifies the exception to be thrown.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in <paramref name = "source"/> sequence.</typeparam>
        /// <param name = "source">Source sequence.</param>
        /// <param name = "count">Count to assert.</param>
        /// <param name = "errorSelector">Function that returns the <see cref = "Exception"/> object to throw.</param>
        /// <returns>
        /// Returns the original sequence as long it is contains the
        /// number of elements specified by <paramref name = "count"/>.
        /// Otherwise it throws the <see cref = "Exception"/> object
        /// returned by calling <paramref name = "errorSelector"/>.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        public static IEnumerable<TSource> AssertCount<TSource>(this IEnumerable<TSource> source, int count, Func<int, int, Exception> errorSelector)
        {
            return MoreEnumerable.AssertCount(source, count, errorSelector);
        }
    }

    /// <summary><c>AtLeast</c> extension.</summary>
    public static partial class AtLeastExtension
    {
        /// <summary>
        /// Returns true when the number of elements in the given sequence is greater than
        /// or equal to the given integer.
        /// This method throws an exception if the given integer is negative.
        /// </summary>
        /// <remarks>
        /// The number of items streamed will be less than or equal to the given integer.
        /// </remarks>
        /// <typeparam name = "TSource">Element type of sequence</typeparam>
        /// <param name = "source">The source sequence</param>
        /// <param name = "count">The minimum number of items a sequence must have for this
        /// function to return true</param>
        /// <exception cref = "ArgumentNullException">source is null</exception>
        /// <exception cref = "ArgumentOutOfRangeException">count is negative</exception>
        /// <returns><c>true</c> if the number of elements in the sequence is greater than
        /// or equal to the given integer or <c>false</c> otherwise.</returns>
        /// <example>
        /// <code>
        /// var numbers = { 123, 456, 789 };
        /// var result = numbers.AtLeast(2);
        /// </code>
        /// The <c>result</c> variable will contain <c>true</c>.
        /// </example>
        public static bool AtLeast<TSource>(this IEnumerable<TSource> source, int count)
        {
            return MoreEnumerable.AtLeast(source, count);
        }
    }

    /// <summary><c>Batch</c> extension.</summary>
    public static partial class BatchExtension
    {
        /// <summary>
        /// Batches the source sequence into sized buckets.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in <paramref name = "source"/> sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "size">Size of buckets.</param>
        /// <returns>A sequence of equally sized buckets containing elements of the source collection.</returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results (buckets and bucket content). 
        /// </remarks>
        public static IEnumerable<IEnumerable<TSource>> Batch<TSource>(this IEnumerable<TSource> source, int size)
        {
            return MoreEnumerable.Batch(source, size);
        }
    }

    /// <summary><c>Batch</c> extension.</summary>
    public static partial class BatchExtension
    {
        /// <summary>
        /// Batches the source sequence into sized buckets and applies a projection to each bucket.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in <paramref name = "source"/> sequence.</typeparam>
        /// <typeparam name = "TResult">Type of result returned by <paramref name = "resultSelector"/>.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "size">Size of buckets.</param>
        /// <param name = "resultSelector">The projection to apply to each bucket.</param>
        /// <returns>A sequence of projections on equally sized buckets containing elements of the source collection.</returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results (buckets and bucket content).
        /// </remarks>
        public static IEnumerable<TResult> Batch<TSource, TResult>(this IEnumerable<TSource> source, int size, Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            return MoreEnumerable.Batch(source, size, resultSelector);
        }
    }

    /// <summary><c>Cartesian</c> extension.</summary>
    public static partial class CartesianExtension
    {
        /// <summary>
        /// Returns the Cartesian product of two sequences by combining each element of the first set with each in the second
        /// and applying the user=define projection to the pair.
        /// </summary>
        /// <typeparam name = "TFirst">The type of the elements of <paramref name = "first"/></typeparam>
        /// <typeparam name = "TSecond">The type of the elements of <paramref name = "second"/></typeparam>
        /// <typeparam name = "TResult">The type of the elements of the result sequence</typeparam>
        /// <param name = "first">The first sequence of elements</param>
        /// <param name = "second">The second sequence of elements</param>
        /// <param name = "resultSelector">A projection function that combines elements from both sequences</param>
        /// <returns>A sequence representing the Cartesian product of the two source sequences</returns>
        public static IEnumerable<TResult> Cartesian<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            return MoreEnumerable.Cartesian(first, second, resultSelector);
        }
    }

    /// <summary><c>Concat</c> extension.</summary>
    public static partial class ConcatExtension
    {
        /// <summary>
        /// Returns a sequence consisting of the head element and the given tail elements.
        /// </summary>
        /// <typeparam name = "T">Type of sequence</typeparam>
        /// <param name = "head">Head element of the new sequence.</param>
        /// <param name = "tail">All elements of the tail. Must not be null.</param>
        /// <returns>A sequence consisting of the head elements and the given tail elements.</returns>
        /// <remarks>This operator uses deferred execution and streams its results.</remarks>
        public static IEnumerable<T> Concat<T>(this T head, IEnumerable<T> tail)
        {
            return MoreEnumerable.Concat(head, tail);
        }
    }

    /// <summary><c>Concat</c> extension.</summary>
    public static partial class ConcatExtension
    {
        /// <summary>
        /// Returns a sequence consisting of the head elements and the given tail element.
        /// </summary>
        /// <typeparam name = "T">Type of sequence</typeparam>
        /// <param name = "head">All elements of the head. Must not be null.</param>
        /// <param name = "tail">Tail element of the new sequence.</param>
        /// <returns>A sequence consisting of the head elements and the given tail element.</returns>
        /// <remarks>This operator uses deferred execution and streams its results.</remarks>
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> head, T tail)
        {
            return MoreEnumerable.Concat(head, tail);
        }
    }

    /// <summary><c>Consume</c> extension.</summary>
    public static partial class ConsumeExtension
    {
        /// <summary>
        /// Completely consumes the given sequence. This method uses immediate execution,
        /// and doesn't store any data during execution.
        /// </summary>
        /// <typeparam name = "T">Element type of the sequence</typeparam>
        /// <param name = "source">Source to consume</param>
        public static void Consume<T>(this IEnumerable<T> source)
        {
            MoreEnumerable.Consume(source);
        }
    }

    /// <summary><c>CountBy</c> extension.</summary>
    public static partial class CountByExtension
    {
        /// <summary>
        /// Applies a key-generating function to each element of a sequence and returns a sequence of 
        /// unique keys and their number of occurrences in the original sequence.
        /// </summary>
        /// <typeparam name = "TSource">Type of the elements of the source sequence.</typeparam>
        /// <typeparam name = "TKey">Type of the projected element.</typeparam>
        /// <param name = "source">Source sequence.</param>
        /// <param name = "keySelector">Function that transforms each item of source sequence into a key to be compared against the others.</param>
        /// <returns>A sequence of unique keys and their number of occurrences in the original sequence.</returns>
        public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return MoreEnumerable.CountBy(source, keySelector);
        }
    }

    /// <summary><c>CountBy</c> extension.</summary>
    public static partial class CountByExtension
    {
        /// <summary>
        /// Applies a key-generating function to each element of a sequence and returns a sequence of 
        /// unique keys and their number of occurrences in the original sequence.
        /// An additional argument specifies a comparer to use for testing equivalence of keys.
        /// </summary>
        /// <typeparam name = "TSource">Type of the elements of the source sequence.</typeparam>
        /// <typeparam name = "TKey">Type of the projected element.</typeparam>
        /// <param name = "source">Source sequence.</param>
        /// <param name = "keySelector">Function that transforms each item of source sequence into a key to be compared against the others.</param>
        /// <param name = "comparer">The equality comparer to use to determine whether or not keys are equal.
        /// If null, the default equality comparer for <typeparamref name = "TSource"/> is used.</param>
        /// <returns>A sequence of unique keys and their number of occurrences in the original sequence.</returns>
        public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return MoreEnumerable.CountBy(source, keySelector, comparer);
        }
    }

    /// <summary><c>DistinctBy</c> extension.</summary>
    public static partial class DistinctByExtension
    {
        /// <summary>
        /// Returns all distinct elements of the given source, where "distinctness"
        /// is determined via a projection and the default equality comparer for the projected type.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams the results, although
        /// a set of already-seen keys is retained. If a key is seen multiple times,
        /// only the first element with that key is returned.
        /// </remarks>
        /// <typeparam name = "TSource">Type of the source sequence</typeparam>
        /// <typeparam name = "TKey">Type of the projected element</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "keySelector">Projection for determining "distinctness"</param>
        /// <returns>A sequence consisting of distinct elements from the source sequence,
        /// comparing them by the specified key projection.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return MoreEnumerable.DistinctBy(source, keySelector);
        }
    }

    /// <summary><c>DistinctBy</c> extension.</summary>
    public static partial class DistinctByExtension
    {
        /// <summary>
        /// Returns all distinct elements of the given source, where "distinctness"
        /// is determined via a projection and the specified comparer for the projected type.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams the results, although
        /// a set of already-seen keys is retained. If a key is seen multiple times,
        /// only the first element with that key is returned.
        /// </remarks>
        /// <typeparam name = "TSource">Type of the source sequence</typeparam>
        /// <typeparam name = "TKey">Type of the projected element</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "keySelector">Projection for determining "distinctness"</param>
        /// <param name = "comparer">The equality comparer to use to determine whether or not keys are equal.
        /// If null, the default equality comparer for <c>TSource</c> is used.</param>
        /// <returns>A sequence consisting of distinct elements from the source sequence,
        /// comparing them by the specified key projection.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return MoreEnumerable.DistinctBy(source, keySelector, comparer);
        }
    }

    /// <summary><c>EndsWith</c> extension.</summary>
    public static partial class EndsWithExtension
    {
        /// <summary>
        /// Determines whether the end of the first sequence is equivalent to
        /// the second sequence, using the default equality comparer.
        /// </summary>
        /// <typeparam name = "T">Type of elements.</typeparam>
        /// <param name = "first">The sequence to check.</param>
        /// <param name = "second">The sequence to compare to.</param>
        /// <returns>
        /// <c>true</c> if <paramref name = "first"/> ends with elements
        /// equivalent to <paramref name = "second"/>.
        /// </returns>
        /// <remarks>
        /// This is the <see cref = "IEnumerable{T}"/> equivalent of
        /// <see cref = "string.EndsWith(string)"/> and
        /// it calls <see cref = "IEqualityComparer{T}.Equals(T, T)"/> using
        /// <see cref = "EqualityComparer{T}.Default"/> on pairs of elements at
        /// the same index.
        /// </remarks>
        public static bool EndsWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return MoreEnumerable.EndsWith(first, second);
        }
    }

    /// <summary><c>EndsWith</c> extension.</summary>
    public static partial class EndsWithExtension
    {
        /// <summary>
        /// Determines whether the end of the first sequence is equivalent to
        /// the second sequence, using the specified element equality comparer.
        /// </summary>
        /// <typeparam name = "T">Type of elements.</typeparam>
        /// <param name = "first">The sequence to check.</param>
        /// <param name = "second">The sequence to compare to.</param>
        /// <param name = "comparer">Equality comparer to use.</param>
        /// <returns>
        /// <c>true</c> if <paramref name = "first"/> ends with elements
        /// equivalent to <paramref name = "second"/>.
        /// </returns>
        /// <remarks>
        /// This is the <see cref = "IEnumerable{T}"/> equivalent of
        /// <see cref = "string.EndsWith(string)"/> and it calls
        /// <see cref = "IEqualityComparer{T}.Equals(T, T)"/> on pairs of
        /// elements at the same index.
        /// </remarks>
        public static bool EndsWith<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            return MoreEnumerable.EndsWith(first, second, comparer);
        }
    }

    /// <summary><c>EquiZip</c> extension.</summary>
    public static partial class EquiZipExtension
    {
        /// <summary>
        /// Returns a projection of tuples, where each tuple contains the N-th element
        /// from each of the argument sequences.
        /// </summary>
        /// <example>
        /// <code>
        /// int[] numbers = { 1, 2, 3, 4 };
        /// string[] letters = { "A", "B", "C", "D" };
        /// var zipped = numbers.EquiZip(letters, (n, l) => n + l);
        /// </code>
        /// The <c>zipped</c> variable, when iterated over, will yield "1A", "2B", "3C", "4D" in turn.
        /// </example>
        /// <typeparam name = "TFirst">Type of elements in first sequence</typeparam>
        /// <typeparam name = "TSecond">Type of elements in second sequence</typeparam>
        /// <typeparam name = "TResult">Type of elements in result sequence</typeparam>
        /// <param name = "first">First sequence</param>
        /// <param name = "second">Second sequence</param>
        /// <param name = "resultSelector">Function to apply to each pair of elements</param>
        /// <returns>
        /// A sequence that contains elements of the two input sequences,
        /// combined by <paramref name = "resultSelector"/>.
        /// </returns>
        /// <remarks>
        /// If the two input sequences are of different lengths then
        /// <see cref = "InvalidOperationException"/> is thrown.
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        public static IEnumerable<TResult> EquiZip<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            return MoreEnumerable.EquiZip(first, second, resultSelector);
        }
    }

    /// <summary><c>EquiZip</c> extension.</summary>
    public static partial class EquiZipExtension
    {
        /// <summary>
        /// Returns a projection of tuples, where each tuple contains the N-th element 
        /// from each of the argument sequences.
        /// </summary>
        /// <remarks>
        /// If the three input sequences are of different lengths then 
        /// <see cref = "InvalidOperationException"/> is thrown.
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// var numbers = { 1, 2, 3, 4 };
        /// var letters = { "A", "B", "C", "D" };
        /// var chars    = { 'a', 'b', 'c', 'd' };
        /// var zipped = numbers.EquiZip(letters, chars, (n, l, c) => n + l + c);
        /// </code>
        /// The <c>zipped</c> variable, when iterated over, will yield "1Aa", "2Bb", "3Cc", "4Dd" in turn.
        /// </example>
        /// <typeparam name = "T1">Type of elements in first sequence</typeparam>
        /// <typeparam name = "T2">Type of elements in second sequence</typeparam>
        /// <typeparam name = "T3">Type of elements in third sequence</typeparam>
        /// <typeparam name = "TResult">Type of elements in result sequence</typeparam>
        /// <param name = "first">First sequence</param>
        /// <param name = "second">Second sequence</param>
        /// <param name = "third">Third sequence</param>
        /// <param name = "resultSelector">Function to apply to each triplet of elements</param>
        /// <returns>
        /// A sequence that contains elements of the three input sequences,
        /// combined by <paramref name = "resultSelector"/>.
        /// </returns>
        public static IEnumerable<TResult> EquiZip<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> resultSelector)
        {
            return MoreEnumerable.EquiZip(first, second, third, resultSelector);
        }
    }

    /// <summary><c>EquiZip</c> extension.</summary>
    public static partial class EquiZipExtension
    {
        /// <summary>
        /// Returns a projection of tuples, where each tuple contains the N-th element 
        /// from each of the argument sequences.
        /// </summary>
        /// <remarks>
        /// If the three input sequences are of different lengths then 
        /// <see cref = "InvalidOperationException"/> is thrown.
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// var numbers = { 1, 2, 3, 4 };
        /// var letters = { "A", "B", "C", "D" };
        /// var chars   = { 'a', 'b', 'c', 'd' };
        /// var flags   = { true, false, true, false };
        /// var zipped = numbers.EquiZip(letters, chars, flags, (n, l, c, f) => n + l + c + f);
        /// </code>
        /// The <c>zipped</c> variable, when iterated over, will yield "1AaTrue", "2BbFalse", "3CcTrue", "4DdFalse" in turn.
        /// </example>
        /// <typeparam name = "T1">Type of elements in first sequence</typeparam>
        /// <typeparam name = "T2">Type of elements in second sequence</typeparam>
        /// <typeparam name = "T3">Type of elements in third sequence</typeparam>
        /// <typeparam name = "T4">Type of elements in fourth sequence</typeparam>
        /// <typeparam name = "TResult">Type of elements in result sequence</typeparam>
        /// <param name = "first">First sequence</param>
        /// <param name = "second">Second sequence</param>
        /// <param name = "third">Third sequence</param>
        /// <param name = "fourth">Fourth sequence</param>
        /// <param name = "resultSelector">Function to apply to each quadruplet of elements</param>
        /// <returns>
        /// A sequence that contains elements of the four input sequences,
        /// combined by <paramref name = "resultSelector"/>.
        /// </returns>
        public static IEnumerable<TResult> EquiZip<T1, T2, T3, T4, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, Func<T1, T2, T3, T4, TResult> resultSelector)
        {
            return MoreEnumerable.EquiZip(first, second, third, fourth, resultSelector);
        }
    }

    /// <summary><c>ExceptBy</c> extension.</summary>
    public static partial class ExceptByExtension
    {
        /// <summary>
        /// Returns the set of elements in the first sequence which aren't
        /// in the second sequence, according to a given key selector.
        /// </summary>
        /// <remarks>
        /// This is a set operation; if multiple elements in <paramref name = "first"/> have
        /// equal keys, only the first such element is returned.
        /// This operator uses deferred execution and streams the results, although
        /// a set of keys from <paramref name = "second"/> is immediately selected and retained.
        /// </remarks>
        /// <typeparam name = "TSource">The type of the elements in the input sequences.</typeparam>
        /// <typeparam name = "TKey">The type of the key returned by <paramref name = "keySelector"/>.</typeparam>
        /// <param name = "first">The sequence of potentially included elements.</param>
        /// <param name = "second">The sequence of elements whose keys may prevent elements in
        /// <paramref name = "first"/> from being returned.</param>
        /// <param name = "keySelector">The mapping from source element to key.</param>
        /// <returns>A sequence of elements from <paramref name = "first"/> whose key was not also a key for
        /// any element in <paramref name = "second"/>.</returns>
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector)
        {
            return MoreEnumerable.ExceptBy(first, second, keySelector);
        }
    }

    /// <summary><c>ExceptBy</c> extension.</summary>
    public static partial class ExceptByExtension
    {
        /// <summary>
        /// Returns the set of elements in the first sequence which aren't
        /// in the second sequence, according to a given key selector.
        /// </summary>
        /// <remarks>
        /// This is a set operation; if multiple elements in <paramref name = "first"/> have
        /// equal keys, only the first such element is returned.
        /// This operator uses deferred execution and streams the results, although
        /// a set of keys from <paramref name = "second"/> is immediately selected and retained.
        /// </remarks>
        /// <typeparam name = "TSource">The type of the elements in the input sequences.</typeparam>
        /// <typeparam name = "TKey">The type of the key returned by <paramref name = "keySelector"/>.</typeparam>
        /// <param name = "first">The sequence of potentially included elements.</param>
        /// <param name = "second">The sequence of elements whose keys may prevent elements in
        /// <paramref name = "first"/> from being returned.</param>
        /// <param name = "keySelector">The mapping from source element to key.</param>
        /// <param name = "keyComparer">The equality comparer to use to determine whether or not keys are equal.
        /// If null, the default equality comparer for <c>TSource</c> is used.</param>
        /// <returns>A sequence of elements from <paramref name = "first"/> whose key was not also a key for
        /// any element in <paramref name = "second"/>.</returns>
        public static IEnumerable<TSource> ExceptBy<TSource, TKey>(this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer)
        {
            return MoreEnumerable.ExceptBy(first, second, keySelector, keyComparer);
        }
    }

    /// <summary><c>Exclude</c> extension.</summary>
    public static partial class ExcludeExtension
    {
        /// <summary>
        /// Excludes <paramref name = "count"/> elements from a sequence starting at a given index
        /// </summary>
        /// <typeparam name = "T">The type of the elements of the sequence</typeparam>
        /// <param name = "sequence">The sequence to exclude elements from</param>
        /// <param name = "startIndex">The zero-based index at which to begin excluding elements</param>
        /// <param name = "count">The number of elements to exclude</param>
        /// <returns>A sequence that excludes the specified portion of elements</returns>
        public static IEnumerable<T> Exclude<T>(this IEnumerable<T> sequence, int startIndex, int count)
        {
            return MoreEnumerable.Exclude(sequence, startIndex, count);
        }
    }

    /// <summary><c>FallbackIfEmpty</c> extension.</summary>
    public static partial class FallbackIfEmptyExtension
    {
        /// <summary>
        /// Returns the elements of the specified sequence or the specified
        /// value in a singleton collection if the sequence is empty.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequences.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "fallback">The value to return in a singleton
        /// collection if <paramref name = "source"/> is empty.</param>
        /// <returns>
        /// An <see cref = "IEnumerable{T}"/> that contains <paramref name = "fallback"/>
        /// if <paramref name = "source"/> is empty; otherwise, <paramref name = "source"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// var numbers = { 123, 456, 789 };
        /// var result = numbers.Where(x => x == 100).FallbackIfEmpty(-1).Single();
        /// </code>
        /// The <c>result</c> variable will contain <c>-1</c>.
        /// </example>
        public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback)
        {
            return MoreEnumerable.FallbackIfEmpty(source, fallback);
        }
    }

    /// <summary><c>FallbackIfEmpty</c> extension.</summary>
    public static partial class FallbackIfEmptyExtension
    {
        /// <summary>
        /// Returns the elements of a sequence, but if it is empty then
        /// returns an altenate sequence of values.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequences.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "fallback1">First value of the alternate sequence that
        /// is returned if <paramref name = "source"/> is empty.</param>
        /// <param name = "fallback2">Second value of the alternate sequence that
        /// is returned if <paramref name = "source"/> is empty.</param>
        /// <returns>
        /// An <see cref = "IEnumerable{T}"/> that containing fallback values
        /// if <paramref name = "source"/> is empty; otherwise, <paramref name = "source"/>.
        /// </returns>
        public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2)
        {
            return MoreEnumerable.FallbackIfEmpty(source, fallback1, fallback2);
        }
    }

    /// <summary><c>FallbackIfEmpty</c> extension.</summary>
    public static partial class FallbackIfEmptyExtension
    {
        /// <summary>
        /// Returns the elements of a sequence, but if it is empty then
        /// returns an altenate sequence of values.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequences.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "fallback1">First value of the alternate sequence that
        /// is returned if <paramref name = "source"/> is empty.</param>
        /// <param name = "fallback2">Second value of the alternate sequence that
        /// is returned if <paramref name = "source"/> is empty.</param>
        /// <param name = "fallback3">Third value of the alternate sequence that
        /// is returned if <paramref name = "source"/> is empty.</param>
        /// <returns>
        /// An <see cref = "IEnumerable{T}"/> that containing fallback values
        /// if <paramref name = "source"/> is empty; otherwise, <paramref name = "source"/>.
        /// </returns>
        public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2, T fallback3)
        {
            return MoreEnumerable.FallbackIfEmpty(source, fallback1, fallback2, fallback3);
        }
    }

    /// <summary><c>FallbackIfEmpty</c> extension.</summary>
    public static partial class FallbackIfEmptyExtension
    {
        /// <summary>
        /// Returns the elements of a sequence, but if it is empty then
        /// returns an altenate sequence of values.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequences.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "fallback1">First value of the alternate sequence that
        /// is returned if <paramref name = "source"/> is empty.</param>
        /// <param name = "fallback2">Second value of the alternate sequence that
        /// is returned if <paramref name = "source"/> is empty.</param>
        /// <param name = "fallback3">Third value of the alternate sequence that
        /// is returned if <paramref name = "source"/> is empty.</param>
        /// <param name = "fallback4">Fourth value of the alternate sequence that
        /// is returned if <paramref name = "source"/> is empty.</param>
        /// <returns>
        /// An <see cref = "IEnumerable{T}"/> that containing fallback values
        /// if <paramref name = "source"/> is empty; otherwise, <paramref name = "source"/>.
        /// </returns>
        public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2, T fallback3, T fallback4)
        {
            return MoreEnumerable.FallbackIfEmpty(source, fallback1, fallback2, fallback3, fallback4);
        }
    }

    /// <summary><c>FallbackIfEmpty</c> extension.</summary>
    public static partial class FallbackIfEmptyExtension
    {
        /// <summary>
        /// Returns the elements of a sequence, but if it is empty then
        /// returns an altenate sequence from an array of values.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequences.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "fallback">The array that is returned as the alternate
        /// sequence if <paramref name = "source"/> is empty.</param>
        /// <returns>
        /// An <see cref = "IEnumerable{T}"/> that containing fallback values
        /// if <paramref name = "source"/> is empty; otherwise, <paramref name = "source"/>.
        /// </returns>
        public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, params T[] fallback)
        {
            return MoreEnumerable.FallbackIfEmpty(source, fallback);
        }
    }

    /// <summary><c>FallbackIfEmpty</c> extension.</summary>
    public static partial class FallbackIfEmptyExtension
    {
        /// <summary>
        /// Returns the elements of a sequence, but if it is empty then
        /// returns an altenate sequence of values.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequences.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "fallback">The alternate sequence that is returned
        /// if <paramref name = "source"/> is empty.</param>
        /// <returns>
        /// An <see cref = "IEnumerable{T}"/> that containing fallback values
        /// if <paramref name = "source"/> is empty; otherwise, <paramref name = "source"/>.
        /// </returns>
        public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, IEnumerable<T> fallback)
        {
            return MoreEnumerable.FallbackIfEmpty(source, fallback);
        }
    }

    /// <summary><c>FillForward</c> extension.</summary>
    public static partial class FillForwardExtension
    {
        /// <summary>
        /// Returns a sequence with each null reference or value in the source
        /// replaced with the previous non-null reference or value seen in
        /// that sequence.
        /// </summary>
        /// <param name = "source">The source sequence.</param>
        /// <typeparam name = "T">Type of the elements in the source sequence.</typeparam>
        /// <returns>
        /// An <see cref = "IEnumerable{T}"/> with null references or values
        /// replaced.
        /// </returns>
        /// <remarks>
        /// This method uses deferred execution semantics and streams its
        /// results. If references or values are null at the start of the
        /// sequence then they remain null.
        /// </remarks>
        public static IEnumerable<T> FillForward<T>(this IEnumerable<T> source)
        {
            return MoreEnumerable.FillForward(source);
        }
    }

    /// <summary><c>FillForward</c> extension.</summary>
    public static partial class FillForwardExtension
    {
        /// <summary>
        /// Returns a sequence with each missing element in the source replaced
        /// with the previous non-missing element seen in that sequence. An
        /// additional parameter specifies a function used to determine if an
        /// element is considered missing or not.
        /// </summary>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "predicate">The function used to determine if
        /// an element in the sequence is considered missing.</param>
        /// <typeparam name = "T">Type of the elements in the source sequence.</typeparam>
        /// <returns>
        /// An <see cref = "IEnumerable{T}"/> with missing values replaced.
        /// </returns>
        /// <remarks>
        /// This method uses deferred execution semantics and streams its
        /// results. If elements are missing at the start of the sequence then
        /// they remain missing.
        /// </remarks>
        public static IEnumerable<T> FillForward<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            return MoreEnumerable.FillForward(source, predicate);
        }
    }

    /// <summary><c>FillForward</c> extension.</summary>
    public static partial class FillForwardExtension
    {
        /// <summary>
        /// Returns a sequence with each missing element in the source replaced
        /// with one based on the previous non-missing element seen in that
        /// sequence. An  additional parameter specifies a function used to
        /// determine if an element is considered missing or not.
        /// </summary>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "predicate">The function used to determine if
        /// an element in the sequence is considered missing.</param>
        /// <param name = "fillSelector">The function used to produce the element
        /// that will replace the missing one. It receives the previous
        /// non-element as well as the current element considered missing.</param>
        /// <typeparam name = "T">Type of the elements in the source sequence.</typeparam>
        /// <returns>
        /// An <see cref = "IEnumerable{T}"/> with missing values replaced.
        /// </returns>
        /// <remarks>
        /// This method uses deferred execution semantics and streams its
        /// results. If elements are missing at the start of the sequence then
        /// they remain missing.
        /// </remarks>
        public static IEnumerable<T> FillForward<T>(this IEnumerable<T> source, Func<T, bool> predicate, Func<T, T, T> fillSelector)
        {
            return MoreEnumerable.FillForward(source, predicate, fillSelector);
        }
    }

    /// <summary><c>Fold</c> extension.</summary>
    public static partial class FoldExtension
    {
        /// <summary>
        /// Returns the result of applying a function to a sequence of
        /// 1 element.
        /// </summary>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers
        /// as many items of the source sequence as necessary.
        /// </remarks>
        /// <typeparam name = "T">Type of element in the source sequence</typeparam>
        /// <typeparam name = "TResult">Type of the result</typeparam>
        /// <param name = "source">The sequence of items to fold.</param>
        /// <param name = "folder">Function to apply to the elements in the sequence.</param>
        /// <returns>The folded value returned by <paramref name = "folder"/>.</returns>
        public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, TResult> folder)
        {
            return MoreEnumerable.Fold(source, folder);
        }
    }

    /// <summary><c>Fold</c> extension.</summary>
    public static partial class FoldExtension
    {
        /// <summary>
        /// Returns the result of applying a function to a sequence of
        /// 2 elements.
        /// </summary>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers
        /// as many items of the source sequence as necessary.
        /// </remarks>
        /// <typeparam name = "T">Type of element in the source sequence</typeparam>
        /// <typeparam name = "TResult">Type of the result</typeparam>
        /// <param name = "source">The sequence of items to fold.</param>
        /// <param name = "folder">Function to apply to the elements in the sequence.</param>
        /// <returns>The folded value returned by <paramref name = "folder"/>.</returns>
        public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, TResult> folder)
        {
            return MoreEnumerable.Fold(source, folder);
        }
    }

    /// <summary><c>Fold</c> extension.</summary>
    public static partial class FoldExtension
    {
        /// <summary>
        /// Returns the result of applying a function to a sequence of
        /// 3 elements.
        /// </summary>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers
        /// as many items of the source sequence as necessary.
        /// </remarks>
        /// <typeparam name = "T">Type of element in the source sequence</typeparam>
        /// <typeparam name = "TResult">Type of the result</typeparam>
        /// <param name = "source">The sequence of items to fold.</param>
        /// <param name = "folder">Function to apply to the elements in the sequence.</param>
        /// <returns>The folded value returned by <paramref name = "folder"/>.</returns>
        public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, TResult> folder)
        {
            return MoreEnumerable.Fold(source, folder);
        }
    }

    /// <summary><c>Fold</c> extension.</summary>
    public static partial class FoldExtension
    {
        /// <summary>
        /// Returns the result of applying a function to a sequence of
        /// 4 elements.
        /// </summary>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers
        /// as many items of the source sequence as necessary.
        /// </remarks>
        /// <typeparam name = "T">Type of element in the source sequence</typeparam>
        /// <typeparam name = "TResult">Type of the result</typeparam>
        /// <param name = "source">The sequence of items to fold.</param>
        /// <param name = "folder">Function to apply to the elements in the sequence.</param>
        /// <returns>The folded value returned by <paramref name = "folder"/>.</returns>
        public static TResult Fold<T, TResult>(this IEnumerable<T> source, Func<T, T, T, T, TResult> folder)
        {
            return MoreEnumerable.Fold(source, folder);
        }
    }

    /// <summary><c>ForEach</c> extension.</summary>
    public static partial class ForEachExtension
    {
        /// <summary>
        /// Immediately executes the given action on each element in the source sequence.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <param name = "source">The sequence of elements</param>
        /// <param name = "action">The action to execute on each element</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            MoreEnumerable.ForEach(source, action);
        }
    }

    /// <summary><c>ForEach</c> extension.</summary>
    public static partial class ForEachExtension
    {
        /// <summary>
        /// Immediately executes the given action on each element in the source sequence.
        /// Each element's index is used in the logic of the action.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <param name = "source">The sequence of elements</param>
        /// <param name = "action">The action to execute on each element; the second parameter
        /// of the action represents the index of the source element.</param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            MoreEnumerable.ForEach(source, action);
        }
    }

    /// <summary><c>FullGroupJoin</c> extension.</summary>
    public static partial class FullGroupJoinExtension
    {
        /// <summary>
        /// Performs a Full Group Join between the <paramref name = "first"/> and <paramref name = "second"/> sequences.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams the results.
        /// The results are yielded in the order of the elements found in the first sequence
        /// followed by those found only in the second. In addition, the callback responsible
        /// for projecting the results is supplied with sequences which preserve their source order.
        /// </remarks>
        /// <typeparam name = "TFirst">The type of the elements in the first input sequence</typeparam>
        /// <typeparam name = "TSecond">The type of the elements in the first input sequence</typeparam>
        /// <typeparam name = "TKey">The type of the key to use to join</typeparam>
        /// <typeparam name = "TResult">The type of the elements of the resulting sequence</typeparam>
        /// <param name = "first">First sequence</param>
        /// <param name = "second">Second sequence</param>
        /// <param name = "firstKeySelector">The mapping from first sequence to key</param>
        /// <param name = "secondKeySelector">The mapping from second sequence to key</param>
        /// <param name = "resultSelector">Function to apply to each pair of elements plus the key</param>
        /// <returns>A sequence of elements joined from <paramref name = "first"/> and <paramref name = "second"/>.
        /// </returns>
        public static IEnumerable<TResult> FullGroupJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TKey, IEnumerable<TFirst>, IEnumerable<TSecond>, TResult> resultSelector)
        {
            return MoreEnumerable.FullGroupJoin(first, second, firstKeySelector, secondKeySelector, resultSelector);
        }
    }

    /// <summary><c>FullGroupJoin</c> extension.</summary>
    public static partial class FullGroupJoinExtension
    {
        /// <summary>
        /// Performs a Full Group Join between the <paramref name = "first"/> and <paramref name = "second"/> sequences.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams the results.
        /// The results are yielded in the order of the elements found in the first sequence
        /// followed by those found only in the second. In addition, the callback responsible
        /// for projecting the results is supplied with sequences which preserve their source order.
        /// </remarks>
        /// <typeparam name = "TFirst">The type of the elements in the first input sequence</typeparam>
        /// <typeparam name = "TSecond">The type of the elements in the first input sequence</typeparam>
        /// <typeparam name = "TKey">The type of the key to use to join</typeparam>
        /// <typeparam name = "TResult">The type of the elements of the resulting sequence</typeparam>
        /// <param name = "first">First sequence</param>
        /// <param name = "second">Second sequence</param>
        /// <param name = "firstKeySelector">The mapping from first sequence to key</param>
        /// <param name = "secondKeySelector">The mapping from second sequence to key</param>
        /// <param name = "resultSelector">Function to apply to each pair of elements plus the key</param>
        /// <param name = "comparer">The equality comparer to use to determine whether or not keys are equal.
        /// If null, the default equality comparer for <c>TKey</c> is used.</param>
        /// <returns>A sequence of elements joined from <paramref name = "first"/> and <paramref name = "second"/>.
        /// </returns>
        public static IEnumerable<TResult> FullGroupJoin<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TKey, IEnumerable<TFirst>, IEnumerable<TSecond>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return MoreEnumerable.FullGroupJoin(first, second, firstKeySelector, secondKeySelector, resultSelector, comparer);
        }
    }

    /// <summary><c>GroupAdjacent</c> extension.</summary>
    public static partial class GroupAdjacentExtension
    {
        /// <summary>
        /// Groups the adjacent elements of a sequence according to a 
        /// specified key selector function.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of 
        /// <paramref name = "source"/>.</typeparam>
        /// <typeparam name = "TKey">The type of the key returned by 
        /// <paramref name = "keySelector"/>.</typeparam>
        /// <param name = "source">A sequence whose elements to group.</param>
        /// <param name = "keySelector">A function to extract the key for each 
        /// element.</param>
        /// <returns>A sequence of groupings where each grouping
        /// (<see cref = "IGrouping{TKey, TElement}"/>) contains the key
        /// and the adjacent elements in the same order as found in the 
        /// source sequence.</returns>
        /// <remarks>
        /// This method is implemented by using deferred execution and 
        /// streams the groupings. The grouping elements, however, are 
        /// buffered. Each grouping is therefore yielded as soon as it 
        /// is complete and before the next grouping occurs.
        /// </remarks>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacent<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return MoreEnumerable.GroupAdjacent(source, keySelector);
        }
    }

    /// <summary><c>GroupAdjacent</c> extension.</summary>
    public static partial class GroupAdjacentExtension
    {
        /// <summary>
        /// Groups the adjacent elements of a sequence according to a 
        /// specified key selector function and compares the keys by using a 
        /// specified comparer.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of 
        /// <paramref name = "source"/>.</typeparam>
        /// <typeparam name = "TKey">The type of the key returned by 
        /// <paramref name = "keySelector"/>.</typeparam>
        /// <param name = "source">A sequence whose elements to group.</param>
        /// <param name = "keySelector">A function to extract the key for each 
        /// element.</param>
        /// <param name = "comparer">An <see cref = "IEqualityComparer{T}"/> to 
        /// compare keys.</param>
        /// <returns>A sequence of groupings where each grouping
        /// (<see cref = "IGrouping{TKey, TElement}"/>) contains the key
        /// and the adjacent elements in the same order as found in the 
        /// source sequence.</returns>
        /// <remarks>
        /// This method is implemented by using deferred execution and 
        /// streams the groupings. The grouping elements, however, are 
        /// buffered. Each grouping is therefore yielded as soon as it 
        /// is complete and before the next grouping occurs.
        /// </remarks>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupAdjacent<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return MoreEnumerable.GroupAdjacent(source, keySelector, comparer);
        }
    }

    /// <summary><c>GroupAdjacent</c> extension.</summary>
    public static partial class GroupAdjacentExtension
    {
        /// <summary>
        /// Groups the adjacent elements of a sequence according to a 
        /// specified key selector function and projects the elements for 
        /// each group by using a specified function.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of 
        /// <paramref name = "source"/>.</typeparam>
        /// <typeparam name = "TKey">The type of the key returned by 
        /// <paramref name = "keySelector"/>.</typeparam>
        /// <typeparam name = "TElement">The type of the elements in the
        /// resulting groupings.</typeparam>
        /// <param name = "source">A sequence whose elements to group.</param>
        /// <param name = "keySelector">A function to extract the key for each 
        /// element.</param>
        /// <param name = "elementSelector">A function to map each source 
        /// element to an element in the resulting grouping.</param>
        /// <returns>A sequence of groupings where each grouping
        /// (<see cref = "IGrouping{TKey, TElement}"/>) contains the key
        /// and the adjacent elements (of type <typeparamref name = "TElement"/>) 
        /// in the same order as found in the source sequence.</returns>
        /// <remarks>
        /// This method is implemented by using deferred execution and 
        /// streams the groupings. The grouping elements, however, are 
        /// buffered. Each grouping is therefore yielded as soon as it 
        /// is complete and before the next grouping occurs.
        /// </remarks>
        public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacent<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return MoreEnumerable.GroupAdjacent(source, keySelector, elementSelector);
        }
    }

    /// <summary><c>GroupAdjacent</c> extension.</summary>
    public static partial class GroupAdjacentExtension
    {
        /// <summary>
        /// Groups the adjacent elements of a sequence according to a 
        /// specified key selector function. The keys are compared by using 
        /// a comparer and each group's elements are projected by using a 
        /// specified function.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of 
        /// <paramref name = "source"/>.</typeparam>
        /// <typeparam name = "TKey">The type of the key returned by 
        /// <paramref name = "keySelector"/>.</typeparam>
        /// <typeparam name = "TElement">The type of the elements in the
        /// resulting groupings.</typeparam>
        /// <param name = "source">A sequence whose elements to group.</param>
        /// <param name = "keySelector">A function to extract the key for each 
        /// element.</param>
        /// <param name = "elementSelector">A function to map each source 
        /// element to an element in the resulting grouping.</param>
        /// <param name = "comparer">An <see cref = "IEqualityComparer{T}"/> to 
        /// compare keys.</param>
        /// <returns>A sequence of groupings where each grouping
        /// (<see cref = "IGrouping{TKey, TElement}"/>) contains the key
        /// and the adjacent elements (of type <typeparamref name = "TElement"/>) 
        /// in the same order as found in the source sequence.</returns>
        /// <remarks>
        /// This method is implemented by using deferred execution and 
        /// streams the groupings. The grouping elements, however, are 
        /// buffered. Each grouping is therefore yielded as soon as it 
        /// is complete and before the next grouping occurs.
        /// </remarks>
        public static IEnumerable<IGrouping<TKey, TElement>> GroupAdjacent<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return MoreEnumerable.GroupAdjacent(source, keySelector, elementSelector, comparer);
        }
    }

    /// <summary><c>GroupAdjacent</c> extension.</summary>
    public static partial class GroupAdjacentExtension
    {
        /// <summary>
        /// Groups the adjacent elements of a sequence according to a 
        /// specified key selector function. The keys are compared by using 
        /// a comparer and each group's elements are projected by using a 
        /// specified function.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of 
        /// <paramref name = "source"/>.</typeparam>
        /// <typeparam name = "TKey">The type of the key returned by 
        /// <paramref name = "keySelector"/>.</typeparam>
        /// <typeparam name = "TResult">The type of the elements in the
        /// resulting sequence.</typeparam>
        /// <param name = "source">A sequence whose elements to group.</param>
        /// <param name = "keySelector">A function to extract the key for each 
        /// element.</param>
        /// <param name = "resultSelector">A function to map each key and
        /// associated source elements to a result object.</param>
        /// <returns>A collection of elements of type
        /// <typeparamref name = "TResult"/> where each element represents
        /// a projection over a group and its key.</returns>
        /// <remarks>
        /// This method is implemented by using deferred execution and 
        /// streams the groupings. The grouping elements, however, are 
        /// buffered. Each grouping is therefore yielded as soon as it 
        /// is complete and before the next grouping occurs.
        /// </remarks>
        public static IEnumerable<TResult> GroupAdjacent<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)
        {
            return MoreEnumerable.GroupAdjacent(source, keySelector, resultSelector);
        }
    }

    /// <summary><c>GroupAdjacent</c> extension.</summary>
    public static partial class GroupAdjacentExtension
    {
        /// <summary>
        /// Groups the adjacent elements of a sequence according to a 
        /// specified key selector function. The keys are compared by using 
        /// a comparer and each group's elements are projected by using a 
        /// specified function.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of 
        /// <paramref name = "source"/>.</typeparam>
        /// <typeparam name = "TKey">The type of the key returned by 
        /// <paramref name = "keySelector"/>.</typeparam>
        /// <typeparam name = "TResult">The type of the elements in the
        /// resulting sequence.</typeparam>
        /// <param name = "source">A sequence whose elements to group.</param>
        /// <param name = "keySelector">A function to extract the key for each 
        /// element.</param>
        /// <param name = "resultSelector">A function to map each key and
        /// associated source elements to a result object.</param>
        /// <param name = "comparer">An <see cref = "IEqualityComparer{TKey}"/> to 
        /// compare keys.</param>
        /// <returns>A collection of elements of type
        /// <typeparamref name = "TResult"/> where each element represents
        /// a projection over a group and its key.</returns>
        /// <remarks>
        /// This method is implemented by using deferred execution and 
        /// streams the groupings. The grouping elements, however, are 
        /// buffered. Each grouping is therefore yielded as soon as it 
        /// is complete and before the next grouping occurs.
        /// </remarks>
        public static IEnumerable<TResult> GroupAdjacent<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            return MoreEnumerable.GroupAdjacent(source, keySelector, resultSelector, comparer);
        }
    }

    /// <summary><c>Incremental</c> extension.</summary>
    public static partial class IncrementalExtension
    {
        /// <summary>
        /// Computes an incremental value between every adjacent element in a sequence: {N,N+1}, {N+1,N+2}, ...
        /// </summary>
        /// <remarks>
        /// The projection function is passed the previous and next element (in that order) and may use
        /// either or both in computing the result.<br/>
        /// If the sequence has less than two items, the result is always an empty sequence.<br/>
        /// The number of items in the resulting sequence is always one less than in the source sequence.<br/>
        /// </remarks>
        /// <typeparam name = "TSource">The type of the elements in the source sequence</typeparam>
        /// <typeparam name = "TResult">The type of the elements in the result sequence</typeparam>
        /// <param name = "sequence">The sequence of elements to incrementally process</param>
        /// <param name = "resultSelector">A projection applied to each pair of adjacent elements in the sequence</param>
        /// <returns>A sequence of elements resulting from projection every adjacent pair</returns>
        public static IEnumerable<TResult> Incremental<TSource, TResult>(this IEnumerable<TSource> sequence, Func<TSource, TSource, TResult> resultSelector)
        {
            return MoreEnumerable.Incremental(sequence, resultSelector);
        }
    }

    /// <summary><c>Incremental</c> extension.</summary>
    public static partial class IncrementalExtension
    {
        /// <summary>
        /// Computes an incremental value between every adjacent element in a sequence: {N,N+1}, {N+1,N+2}, ...
        /// </summary>
        /// <remarks>
        /// The projection function is passed the previous element, next element, and the zero-based index of
        /// the next element (in that order) and may use any of these values in computing the result.<br/>
        /// If the sequence has less than two items, the result is always an empty sequence.<br/>
        /// The number of items in the resulting sequence is always one less than in the source sequence.<br/>
        /// </remarks>
        /// <typeparam name = "TSource">The type of the elements in the source sequence</typeparam>
        /// <typeparam name = "TResult">The type of the elements in the result sequence</typeparam>
        /// <param name = "sequence">The sequence of elements to incrementally process</param>
        /// <param name = "resultSelector">A projection applied to each pair of adjacent elements in the sequence</param>
        /// <returns>A sequence of elements resulting from projection every adjacent pair</returns>
        public static IEnumerable<TResult> Incremental<TSource, TResult>(this IEnumerable<TSource> sequence, Func<TSource, TSource, int, TResult> resultSelector)
        {
            return MoreEnumerable.Incremental(sequence, resultSelector);
        }
    }

    /// <summary><c>Index</c> extension.</summary>
    public static partial class IndexExtension
    {
        /// <summary>
        /// Returns a sequence of <see cref = "KeyValuePair{TKey, TValue}"/> 
        /// where the key is the zero-based index of the value in the source 
        /// sequence.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in <paramref name = "source"/> sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <returns>A sequence of <see cref = "KeyValuePair{TKey, TValue}"/>.</returns>
        /// <remarks>This operator uses deferred execution and streams its 
        /// results.</remarks>
        public static IEnumerable<KeyValuePair<int, TSource>> Index<TSource>(this IEnumerable<TSource> source)
        {
            return MoreEnumerable.Index(source);
        }
    }

    /// <summary><c>Index</c> extension.</summary>
    public static partial class IndexExtension
    {
        /// <summary>
        /// Returns a sequence of <see cref = "KeyValuePair{TKey, TValue}"/> 
        /// where the key is the index of the value in the source sequence.
        /// An additional parameter specifies the starting index.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in <paramref name = "source"/> sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "startIndex"></param>
        /// <returns>A sequence of <see cref = "KeyValuePair{TKey, TValue}"/>.</returns>
        /// <remarks>This operator uses deferred execution and streams its 
        /// results.</remarks>
        public static IEnumerable<KeyValuePair<int, TSource>> Index<TSource>(this IEnumerable<TSource> source, int startIndex)
        {
            return MoreEnumerable.Index(source, startIndex);
        }
    }

    /// <summary><c>Interleave</c> extension.</summary>
    public static partial class InterleaveExtension
    {
        /// <summary>
        /// Interleaves the elements of two or more sequences into a single sequence, skipping sequences as they are consumed
        /// </summary>
        /// <remarks>
        /// Interleave combines sequences by visiting each in turn, and returning the first element of each, followed
        /// by the second, then the third, and so on. So, for example:<br/>
        /// <code>
        /// {1,1,1}.Interleave( {2,2,2}, {3,3,3} ) => { 1,2,3,1,2,3,1,2,3 }
        /// </code>
        /// This operator behaves in a deferred and streaming manner.<br/>
        /// When sequences are of unequal length, this method will skip those sequences that have been fully consumed
        /// and continue interleaving the remaining sequences.<br/>
        /// The sequences are interleaved in the order that they appear in the <paramref name = "otherSequences"/>
        /// collection, with <paramref name = "sequence"/> as the first sequence.
        /// </remarks>
        /// <typeparam name = "T">The type of the elements of the source sequences</typeparam>
        /// <param name = "sequence">The first sequence in the interleave group</param>
        /// <param name = "otherSequences">The other sequences in the interleave group</param>
        /// <returns>A sequence of interleaved elements from all of the source sequences</returns>
        public static IEnumerable<T> Interleave<T>(this IEnumerable<T> sequence, params IEnumerable<T>[] otherSequences)
        {
            return MoreEnumerable.Interleave(sequence, otherSequences);
        }
    }

    /// <summary><c>Lag</c> extension.</summary>
    public static partial class LagExtension
    {
        /// <summary>
        /// Produces a projection of a sequence by evaluating pairs of elements separated by a negative offset.
        /// </summary>
        /// <remarks>
        /// This operator evaluates in a deferred and streaming manner.<br/>
        /// For elements prior to the lag offset, <c>default(T) is used as the lagged value.</c><br/>
        /// </remarks>
        /// <typeparam name = "TSource">The type of the elements of the source sequence</typeparam>
        /// <typeparam name = "TResult">The type of the elements of the result sequence</typeparam>
        /// <param name = "source">The sequence over which to evaluate lag</param>
        /// <param name = "offset">The offset (expressed as a positive number) by which to lag each value of the sequence</param>
        /// <param name = "resultSelector">A projection function which accepts the current and lagged items (in that order) and returns a result</param>
        /// <returns>A sequence produced by projecting each element of the sequence with its lagged pairing</returns>
        public static IEnumerable<TResult> Lag<TSource, TResult>(this IEnumerable<TSource> source, int offset, Func<TSource, TSource, TResult> resultSelector)
        {
            return MoreEnumerable.Lag(source, offset, resultSelector);
        }
    }

    /// <summary><c>Lag</c> extension.</summary>
    public static partial class LagExtension
    {
        /// <summary>
        /// Produces a projection of a sequence by evaluating pairs of elements separated by a negative offset.
        /// </summary>
        /// <remarks>
        /// This operator evaluates in a deferred and streaming manner.<br/>
        /// </remarks>
        /// <typeparam name = "TSource">The type of the elements of the source sequence</typeparam>
        /// <typeparam name = "TResult">The type of the elements of the result sequence</typeparam>
        /// <param name = "source">The sequence over which to evaluate lag</param>
        /// <param name = "offset">The offset (expressed as a positive number) by which to lag each value of the sequence</param>
        /// <param name = "defaultLagValue">A default value supplied for the lagged value prior to the lag offset</param>
        /// <param name = "resultSelector">A projection function which accepts the current and lagged items (in that order) and returns a result</param>
        /// <returns>A sequence produced by projecting each element of the sequence with its lagged pairing</returns>
        public static IEnumerable<TResult> Lag<TSource, TResult>(this IEnumerable<TSource> source, int offset, TSource defaultLagValue, Func<TSource, TSource, TResult> resultSelector)
        {
            return MoreEnumerable.Lag(source, offset, defaultLagValue, resultSelector);
        }
    }

    /// <summary><c>Lead</c> extension.</summary>
    public static partial class LeadExtension
    {
        /// <summary>
        /// Produces a projection of a sequence by evaluating pairs of elements separated by a positive offset.
        /// </summary>
        /// <remarks>
        /// This operator evaluates in a deferred and streaming manner.<br/>
        /// For elements of the sequence that are less than <paramref name = "offset"/> items from the end,
        /// default(T) is used as the lead value.<br/>
        /// </remarks>
        /// <typeparam name = "TSource">The type of the elements in the source sequence</typeparam>
        /// <typeparam name = "TResult">The type of the elements in the result sequence</typeparam>
        /// <param name = "source">The sequence over which to evaluate Lead</param>
        /// <param name = "offset">The offset (expressed as a positive number) by which to lead each element of the sequence</param>
        /// <param name = "resultSelector">A projection function which accepts the current and subsequent (lead) element (in that order) and produces a result</param>
        /// <returns>A sequence produced by projecting each element of the sequence with its lead pairing</returns>
        public static IEnumerable<TResult> Lead<TSource, TResult>(this IEnumerable<TSource> source, int offset, Func<TSource, TSource, TResult> resultSelector)
        {
            return MoreEnumerable.Lead(source, offset, resultSelector);
        }
    }

    /// <summary><c>Lead</c> extension.</summary>
    public static partial class LeadExtension
    {
        /// <summary>
        /// Produces a projection of a sequence by evaluating pairs of elements separated by a positive offset.
        /// </summary>
        /// <remarks>
        /// This operator evaluates in a deferred and streaming manner.<br/>
        /// </remarks>
        /// <typeparam name = "TSource">The type of the elements in the source sequence</typeparam>
        /// <typeparam name = "TResult">The type of the elements in the result sequence</typeparam>
        /// <param name = "source">The sequence over which to evaluate Lead</param>
        /// <param name = "offset">The offset (expressed as a positive number) by which to lead each element of the sequence</param>
        /// <param name = "defaultLeadValue">A default value supplied for the leading element when none is available</param>
        /// <param name = "resultSelector">A projection function which accepts the current and subsequent (lead) element (in that order) and produces a result</param>
        /// <returns>A sequence produced by projecting each element of the sequence with its lead pairing</returns>
        public static IEnumerable<TResult> Lead<TSource, TResult>(this IEnumerable<TSource> source, int offset, TSource defaultLeadValue, Func<TSource, TSource, TResult> resultSelector)
        {
            return MoreEnumerable.Lead(source, offset, defaultLeadValue, resultSelector);
        }
    }

    /// <summary><c>MaxBy</c> extension.</summary>
    public static partial class MaxByExtension
    {
        /// <summary>
        /// Returns the maximal element of the given sequence, based on
        /// the given projection.
        /// </summary>
        /// <remarks>
        /// If more than one element has the maximal projected value, the first
        /// one encountered will be returned. This overload uses the default comparer
        /// for the projected type. This operator uses immediate execution, but
        /// only buffers a single result (the current maximal element).
        /// </remarks>
        /// <typeparam name = "TSource">Type of the source sequence</typeparam>
        /// <typeparam name = "TKey">Type of the projected element</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "selector">Selector to use to pick the results to compare</param>
        /// <returns>The maximal element, according to the projection.</returns>
        /// <exception cref = "ArgumentNullException"><paramref name = "source"/> or <paramref name = "selector"/> is null</exception>
        /// <exception cref = "InvalidOperationException"><paramref name = "source"/> is empty</exception>
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return MoreEnumerable.MaxBy(source, selector);
        }
    }

    /// <summary><c>MaxBy</c> extension.</summary>
    public static partial class MaxByExtension
    {
        /// <summary>
        /// Returns the maximal element of the given sequence, based on
        /// the given projection and the specified comparer for projected values. 
        /// </summary>
        /// <remarks>
        /// If more than one element has the maximal projected value, the first
        /// one encountered will be returned. This operator uses immediate execution, but
        /// only buffers a single result (the current maximal element).
        /// </remarks>
        /// <typeparam name = "TSource">Type of the source sequence</typeparam>
        /// <typeparam name = "TKey">Type of the projected element</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "selector">Selector to use to pick the results to compare</param>
        /// <param name = "comparer">Comparer to use to compare projected values</param>
        /// <returns>The maximal element, according to the projection.</returns>
        /// <exception cref = "ArgumentNullException"><paramref name = "source"/>, <paramref name = "selector"/> 
        /// or <paramref name = "comparer"/> is null</exception>
        /// <exception cref = "InvalidOperationException"><paramref name = "source"/> is empty</exception>
        public static TSource MaxBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
        {
            return MoreEnumerable.MaxBy(source, selector, comparer);
        }
    }

    /// <summary><c>MinBy</c> extension.</summary>
    public static partial class MinByExtension
    {
        /// <summary>
        /// Returns the minimal element of the given sequence, based on
        /// the given projection.
        /// </summary>
        /// <remarks>
        /// If more than one element has the minimal projected value, the first
        /// one encountered will be returned. This overload uses the default comparer
        /// for the projected type. This operator uses immediate execution, but
        /// only buffers a single result (the current minimal element).
        /// </remarks>
        /// <typeparam name = "TSource">Type of the source sequence</typeparam>
        /// <typeparam name = "TKey">Type of the projected element</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "selector">Selector to use to pick the results to compare</param>
        /// <returns>The minimal element, according to the projection.</returns>
        /// <exception cref = "ArgumentNullException"><paramref name = "source"/> or <paramref name = "selector"/> is null</exception>
        /// <exception cref = "InvalidOperationException"><paramref name = "source"/> is empty</exception>
        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            return MoreEnumerable.MinBy(source, selector);
        }
    }

    /// <summary><c>MinBy</c> extension.</summary>
    public static partial class MinByExtension
    {
        /// <summary>
        /// Returns the minimal element of the given sequence, based on
        /// the given projection and the specified comparer for projected values.
        /// </summary>
        /// <remarks>
        /// If more than one element has the minimal projected value, the first
        /// one encountered will be returned. This operator uses immediate execution, but
        /// only buffers a single result (the current minimal element).
        /// </remarks>
        /// <typeparam name = "TSource">Type of the source sequence</typeparam>
        /// <typeparam name = "TKey">Type of the projected element</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "selector">Selector to use to pick the results to compare</param>
        /// <param name = "comparer">Comparer to use to compare projected values</param>
        /// <returns>The minimal element, according to the projection.</returns>
        /// <exception cref = "ArgumentNullException"><paramref name = "source"/>, <paramref name = "selector"/> 
        /// or <paramref name = "comparer"/> is null</exception>
        /// <exception cref = "InvalidOperationException"><paramref name = "source"/> is empty</exception>
        public static TSource MinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
        {
            return MoreEnumerable.MinBy(source, selector, comparer);
        }
    }

    /// <summary><c>NestedLoops</c> extension.</summary>
    public static partial class NestedLoopsExtension
    {
        // This extension method was developed (primarily) to support the
        // implementation of the Permutations() extension methods. However,
        // it is of sufficient generality and usefulness to be elevated to
        // a public extension method in its own right.
        /// <summary>
        /// Produces a sequence from an action based on the dynamic generation of N nested loops
        /// who iteration counts are defined by <paramref name = "loopCounts"/>.
        /// </summary>
        /// <param name = "action">Action delegate for which to produce a nested loop sequence</param>
        /// <param name = "loopCounts">A sequence of loop repetition counts</param>
        /// <returns>A sequence of Action representing the expansion of a set of nested loops</returns>
        public static IEnumerable<Action> NestedLoops(this Action action, IEnumerable<int> loopCounts)
        {
            return MoreEnumerable.NestedLoops(action, loopCounts);
        }
    }

    /// <summary><c>OrderBy</c> extension.</summary>
    public static partial class OrderByExtension
    {
        /// <summary>
        /// Sorts the elements of a sequence in a particular direction (ascending, descending) according to a key
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the source sequence</typeparam>
        /// <typeparam name = "TKey">The type of the key used to order elements</typeparam>
        /// <param name = "source">The sequence to order</param>
        /// <param name = "keySelector">A key selector function</param>
        /// <param name = "direction">A direction in which to order the elements (ascending, descending)</param>
        /// <returns>An ordered copy of the source sequence</returns>
        public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, OrderByDirection direction)
        {
            return MoreEnumerable.OrderBy(source, keySelector, direction);
        }
    }

    /// <summary><c>OrderBy</c> extension.</summary>
    public static partial class OrderByExtension
    {
        /// <summary>
        /// Sorts the elements of a sequence in a particular direction (ascending, descending) according to a key
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the source sequence</typeparam>
        /// <typeparam name = "TKey">The type of the key used to order elements</typeparam>
        /// <param name = "source">The sequence to order</param>
        /// <param name = "keySelector">A key selector function</param>
        /// <param name = "direction">A direction in which to order the elements (ascending, descending)</param>
        /// <param name = "comparer">A comparer used to define the semantics of element comparison</param>
        /// <returns>An ordered copy of the source sequence</returns>
        public static IOrderedEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
        {
            return MoreEnumerable.OrderBy(source, keySelector, comparer, direction);
        }
    }

    /// <summary><c>ThenBy</c> extension.</summary>
    public static partial class ThenByExtension
    {
        /// <summary>
        /// Performs a subsequent ordering of elements in a sequence in a particular direction (ascending, descending) according to a key
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the source sequence</typeparam>
        /// <typeparam name = "TKey">The type of the key used to order elements</typeparam>
        /// <param name = "source">The sequence to order</param>
        /// <param name = "keySelector">A key selector function</param>
        /// <param name = "direction">A direction in which to order the elements (ascending, descending)</param>
        /// <returns>An ordered copy of the source sequence</returns>
        public static IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector, OrderByDirection direction)
        {
            return MoreEnumerable.ThenBy(source, keySelector, direction);
        }
    }

    /// <summary><c>ThenBy</c> extension.</summary>
    public static partial class ThenByExtension
    {
        /// <summary>
        /// Performs a subsequent ordering of elements in a sequence in a particular direction (ascending, descending) according to a key
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the source sequence</typeparam>
        /// <typeparam name = "TKey">The type of the key used to order elements</typeparam>
        /// <param name = "source">The sequence to order</param>
        /// <param name = "keySelector">A key selector function</param>
        /// <param name = "direction">A direction in which to order the elements (ascending, descending)</param>
        /// <param name = "comparer">A comparer used to define the semantics of element comparison</param>
        /// <returns>An ordered copy of the source sequence</returns>
        public static IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
        {
            return MoreEnumerable.ThenBy(source, keySelector, comparer, direction);
        }
    }

    /// <summary><c>OrderedMerge</c> extension.</summary>
    public static partial class OrderedMergeExtension
    {
        /// <summary>
        /// Merges two ordered sequences into one. Where the elements equal
        /// in both sequences, the element from the first sequence is
        /// returned in the resulting sequence.
        /// </summary>
        /// <typeparam name = "T">Type of elements in input and output sequences.</typeparam>
        /// <param name = "first">The first input sequence.</param>
        /// <param name = "second">The second input sequence.</param>
        /// <returns>
        /// A sequence with elements from the two input sequences merged, as
        /// in a full outer join.</returns>
        /// <remarks>
        /// This method uses deferred execution. The behavior is undefined
        /// if the sequences are unordered as inputs.
        /// </remarks>
        public static IEnumerable<T> OrderedMerge<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return MoreEnumerable.OrderedMerge(first, second);
        }
    }

    /// <summary><c>OrderedMerge</c> extension.</summary>
    public static partial class OrderedMergeExtension
    {
        /// <summary>
        /// Merges two ordered sequences into one with an additional
        /// parameter specifying how to compare the elements of the
        /// sequences. Where the elements equal in both sequences, the
        /// element from the first sequence is returned in the resulting
        /// sequence.
        /// </summary>
        /// <typeparam name = "T">Type of elements in input and output sequences.</typeparam>
        /// <param name = "first">The first input sequence.</param>
        /// <param name = "second">The second input sequence.</param>
        /// <param name = "comparer">An <see cref = "IComparer{T}"/> to compare elements.</param>
        /// <returns>
        /// A sequence with elements from the two input sequences merged, as
        /// in a full outer join.</returns>
        /// <remarks>
        /// This method uses deferred execution. The behavior is undefined
        /// if the sequences are unordered as inputs.
        /// </remarks>
        public static IEnumerable<T> OrderedMerge<T>(this IEnumerable<T> first, IEnumerable<T> second, IComparer<T> comparer)
        {
            return MoreEnumerable.OrderedMerge(first, second, comparer);
        }
    }

    /// <summary><c>OrderedMerge</c> extension.</summary>
    public static partial class OrderedMergeExtension
    {
        /// <summary>
        /// Merges two ordered sequences into one with an additional
        /// parameter specifying the element key by which the sequences are
        /// ordered. Where the keys equal in both sequences, the
        /// element from the first sequence is returned in the resulting
        /// sequence.
        /// </summary>
        /// <typeparam name = "T">Type of elements in input and output sequences.</typeparam>
        /// <typeparam name = "TKey">Type of keys used for merging.</typeparam>
        /// <param name = "first">The first input sequence.</param>
        /// <param name = "second">The second input sequence.</param>
        /// <param name = "keySelector">Function to extract a key given an element.</param>
        /// <returns>
        /// A sequence with elements from the two input sequences merged
        /// according to a key, as in a full outer join.</returns>
        /// <remarks>
        /// This method uses deferred execution. The behavior is undefined
        /// if the sequences are unordered (by key) as inputs.
        /// </remarks>
        public static IEnumerable<T> OrderedMerge<T, TKey>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector)
        {
            return MoreEnumerable.OrderedMerge(first, second, keySelector);
        }
    }

    /// <summary><c>OrderedMerge</c> extension.</summary>
    public static partial class OrderedMergeExtension
    {
        /// <summary>
        /// Merges two ordered sequences into one. Additional parameters
        /// specify the element key by which the sequences are ordered,
        /// the result when element is found in first sequence but not in
        /// the second, the result when element is found in second sequence
        /// but not in the first and the result when elements are found in
        /// both sequences.
        /// </summary>
        /// <typeparam name = "T">Type of elements in source sequences.</typeparam>
        /// <typeparam name = "TKey">Type of keys used for merging.</typeparam>
        /// <typeparam name = "TResult">Type of elements in the returned sequence.</typeparam>
        /// <param name = "first">The first input sequence.</param>
        /// <param name = "second">The second input sequence.</param>
        /// <param name = "keySelector">Function to extract a key given an element.</param>
        /// <param name = "firstSelector">Function to project the result element
        /// when only the first sequence yields a source element.</param>
        /// <param name = "secondSelector">Function to project the result element
        /// when only the second sequence yields a source element.</param>
        /// <param name = "bothSelector">Function to project the result element
        /// when only both sequences yield a source element whose keys are
        /// equal.</param>
        /// <returns>
        /// A sequence with projections from the two input sequences merged
        /// according to a key, as in a full outer join.</returns>
        /// <remarks>
        /// This method uses deferred execution. The behavior is undefined
        /// if the sequences are unordered (by key) as inputs.
        /// </remarks>
        public static IEnumerable<TResult> OrderedMerge<T, TKey, TResult>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector, Func<T, TResult> firstSelector, Func<T, TResult> secondSelector, Func<T, T, TResult> bothSelector)
        {
            return MoreEnumerable.OrderedMerge(first, second, keySelector, firstSelector, secondSelector, bothSelector);
        }
    }

    /// <summary><c>OrderedMerge</c> extension.</summary>
    public static partial class OrderedMergeExtension
    {
        /// <summary>
        /// Merges two ordered sequences into one. Additional parameters
        /// specify the element key by which the sequences are ordered,
        /// the result when element is found in first sequence but not in
        /// the second, the result when element is found in second sequence
        /// but not in the first, the result when elements are found in
        /// both sequences and a method for comparing keys.
        /// </summary>
        /// <typeparam name = "T">Type of elements in source sequences.</typeparam>
        /// <typeparam name = "TKey">Type of keys used for merging.</typeparam>
        /// <typeparam name = "TResult">Type of elements in the returned sequence.</typeparam>
        /// <param name = "first">The first input sequence.</param>
        /// <param name = "second">The second input sequence.</param>
        /// <param name = "keySelector">Function to extract a key given an element.</param>
        /// <param name = "firstSelector">Function to project the result element
        /// when only the first sequence yields a source element.</param>
        /// <param name = "secondSelector">Function to project the result element
        /// when only the second sequence yields a source element.</param>
        /// <param name = "bothSelector">Function to project the result element
        /// when only both sequences yield a source element whose keys are
        /// equal.</param>
        /// <param name = "comparer">An <see cref = "IComparer{T}"/> to compare keys.</param>
        /// <returns>
        /// A sequence with projections from the two input sequences merged
        /// according to a key, as in a full outer join.</returns>
        /// <remarks>
        /// This method uses deferred execution. The behavior is undefined
        /// if the sequences are unordered (by key) as inputs.
        /// </remarks>
        public static IEnumerable<TResult> OrderedMerge<T, TKey, TResult>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, TKey> keySelector, Func<T, TResult> firstSelector, Func<T, TResult> secondSelector, Func<T, T, TResult> bothSelector, IComparer<TKey> comparer)
        {
            return MoreEnumerable.OrderedMerge(first, second, keySelector, firstSelector, secondSelector, bothSelector, comparer);
        }
    }

    /// <summary><c>OrderedMerge</c> extension.</summary>
    public static partial class OrderedMergeExtension
    {
        /// <summary>
        /// Merges two heterogeneous sequences ordered by a common key type
        /// into a homogeneous one. Additional parameters specify the
        /// element key by which the sequences are ordered, the result when
        /// element is found in first sequence but not in the second and
        /// the result when element is found in second sequence but not in
        /// the first, the result when elements are found in both sequences.
        /// </summary>
        /// <typeparam name = "TFirst">Type of elements in the first sequence.</typeparam>
        /// <typeparam name = "TSecond">Type of elements in the second sequence.</typeparam>
        /// <typeparam name = "TKey">Type of keys used for merging.</typeparam>
        /// <typeparam name = "TResult">Type of elements in the returned sequence.</typeparam>
        /// <param name = "first">The first input sequence.</param>
        /// <param name = "second">The second input sequence.</param>
        /// <param name = "firstKeySelector">Function to extract a key given an
        /// element from the first sequence.</param>
        /// <param name = "secondKeySelector">Function to extract a key given an
        /// element from the second sequence.</param>
        /// <param name = "firstSelector">Function to project the result element
        /// when only the first sequence yields a source element.</param>
        /// <param name = "secondSelector">Function to project the result element
        /// when only the second sequence yields a source element.</param>
        /// <param name = "bothSelector">Function to project the result element
        /// when only both sequences yield a source element whose keys are
        /// equal.</param>
        /// <returns>
        /// A sequence with projections from the two input sequences merged
        /// according to a key, as in a full outer join.</returns>
        /// <remarks>
        /// This method uses deferred execution. The behavior is undefined
        /// if the sequences are unordered (by key) as inputs.
        /// </remarks>
        public static IEnumerable<TResult> OrderedMerge<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector)
        {
            return MoreEnumerable.OrderedMerge(first, second, firstKeySelector, secondKeySelector, firstSelector, secondSelector, bothSelector);
        }
    }

    /// <summary><c>OrderedMerge</c> extension.</summary>
    public static partial class OrderedMergeExtension
    {
        /// <summary>
        /// Merges two heterogeneous sequences ordered by a common key type
        /// into a homogeneous one. Additional parameters specify the
        /// element key by which the sequences are ordered, the result when
        /// element is found in first sequence but not in the second,
        /// the result when element is found in second sequence but not in
        /// the first, the result when elements are found in both sequences
        /// and a method for comparing keys.
        /// </summary>
        /// <typeparam name = "TFirst">Type of elements in the first sequence.</typeparam>
        /// <typeparam name = "TSecond">Type of elements in the second sequence.</typeparam>
        /// <typeparam name = "TKey">Type of keys used for merging.</typeparam>
        /// <typeparam name = "TResult">Type of elements in the returned sequence.</typeparam>
        /// <param name = "first">The first input sequence.</param>
        /// <param name = "second">The second input sequence.</param>
        /// <param name = "firstKeySelector">Function to extract a key given an
        /// element from the first sequence.</param>
        /// <param name = "secondKeySelector">Function to extract a key given an
        /// element from the second sequence.</param>
        /// <param name = "firstSelector">Function to project the result element
        /// when only the first sequence yields a source element.</param>
        /// <param name = "secondSelector">Function to project the result element
        /// when only the second sequence yields a source element.</param>
        /// <param name = "bothSelector">Function to project the result element
        /// when only both sequences yield a source element whose keys are
        /// equal.</param>
        /// <param name = "comparer">An <see cref = "IComparer{T}"/> to compare keys.</param>
        /// <returns>
        /// A sequence with projections from the two input sequences merged
        /// according to a key, as in a full outer join.</returns>
        /// <remarks>
        /// This method uses deferred execution. The behavior is undefined
        /// if the sequences are unordered (by key) as inputs.
        /// </remarks>
        public static IEnumerable<TResult> OrderedMerge<TFirst, TSecond, TKey, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TKey> firstKeySelector, Func<TSecond, TKey> secondKeySelector, Func<TFirst, TResult> firstSelector, Func<TSecond, TResult> secondSelector, Func<TFirst, TSecond, TResult> bothSelector, IComparer<TKey> comparer)
        {
            return MoreEnumerable.OrderedMerge(first, second, firstKeySelector, secondKeySelector, firstSelector, secondSelector, bothSelector, comparer);
        }
    }

    /// <summary><c>Pad</c> extension.</summary>
    public static partial class PadExtension
    {
        /// <summary>
        /// Pads a sequence with default values if it is narrower (shorter 
        /// in length) than a given width.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of <paramref name = "source"/>.</typeparam>
        /// <param name = "source">The sequence to pad.</param>
        /// <param name = "width">The width/length below which to pad.</param>
        /// <returns>
        /// Returns a sequence that is at least as wide/long as the width/length
        /// specified by the <paramref name = "width"/> parameter.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// int[] numbers = { 123, 456, 789 };
        /// IEnumerable&lt;int&gt; result = numbers.Pad(5);
        /// </code>
        /// The <c>result</c> variable, when iterated over, will yield 
        /// 123, 456, 789 and two zeroes, in turn.
        /// </example>
        public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> source, int width)
        {
            return MoreEnumerable.Pad(source, width);
        }
    }

    /// <summary><c>Pad</c> extension.</summary>
    public static partial class PadExtension
    {
        /// <summary>
        /// Pads a sequence with a given filler value if it is narrower (shorter 
        /// in length) than a given width.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of <paramref name = "source"/>.</typeparam>
        /// <param name = "source">The sequence to pad.</param>
        /// <param name = "width">The width/length below which to pad.</param>
        /// <param name = "padding">The value to use for padding.</param>
        /// <returns>
        /// Returns a sequence that is at least as wide/long as the width/length
        /// specified by the <paramref name = "width"/> parameter.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// int[] numbers = { 123, 456, 789 };
        /// IEnumerable&lt;int&gt; result = numbers.Pad(5, -1);
        /// </code>
        /// The <c>result</c> variable, when iterated over, will yield 
        /// 123, 456, and 789 followed by two occurrences of -1, in turn.
        /// </example>
        public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> source, int width, TSource padding)
        {
            return MoreEnumerable.Pad(source, width, padding);
        }
    }

    /// <summary><c>Pad</c> extension.</summary>
    public static partial class PadExtension
    {
        /// <summary>
        /// Pads a sequence with a dynamic filler value if it is narrower (shorter 
        /// in length) than a given width.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of <paramref name = "source"/>.</typeparam>
        /// <param name = "source">The sequence to pad.</param>
        /// <param name = "width">The width/length below which to pad.</param>
        /// <param name = "paddingSelector">Function to calculate padding.</param>
        /// <returns>
        /// Returns a sequence that is at least as wide/long as the width/length
        /// specified by the <paramref name = "width"/> parameter.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// int[] numbers = { 0, 1, 2 };
        /// IEnumerable&lt;int&gt; result = numbers.Pad(5, i => -i);
        /// </code>
        /// The <c>result</c> variable, when iterated over, will yield 
        /// 0, 1, 2, -3 and -4, in turn.
        /// </example>
        public static IEnumerable<TSource> Pad<TSource>(this IEnumerable<TSource> source, int width, Func<int, TSource> paddingSelector)
        {
            return MoreEnumerable.Pad(source, width, paddingSelector);
        }
    }

    /// <summary><c>Pairwise</c> extension.</summary>
    public static partial class PairwiseExtension
    {
        /// <summary>
        /// Returns a sequence resulting from applying a function to each 
        /// element in the source sequence and its 
        /// predecessor, with the exception of the first element which is 
        /// only returned as the predecessor of the second element.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of <paramref name = "source"/>.</typeparam>
        /// <typeparam name = "TResult">The type of the element of the returned sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "resultSelector">A transform function to apply to 
        /// each pair of sequence.</param>
        /// <returns>
        /// Returns the resulting sequence.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// int[] numbers = { 123, 456, 789 };
        /// IEnumerable&lt;int&gt; result = numbers.Pairwise((a, b) => a + b);
        /// </code>
        /// The <c>result</c> variable, when iterated over, will yield 
        /// 579 and 1245, in turn.
        /// </example>
        public static IEnumerable<TResult> Pairwise<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> resultSelector)
        {
            return MoreEnumerable.Pairwise(source, resultSelector);
        }
    }

    /// <summary><c>PartialSort</c> extension.</summary>
    public static partial class PartialSortExtension
    {
        /// <summary>
        /// Combines <see cref = "Enumerable.OrderBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey})"/>,
        /// where each element is its key, and <see cref = "Enumerable.Take{TSource}"/>
        /// in a single operation.
        /// </summary>
        /// <typeparam name = "T">Type of elements in the sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "count">Number of (maximum) elements to return.</param>
        /// <returns>A sequence containing at most top <paramref name = "count"/>
        /// elements from source, in their ascending order.</returns>
        /// <remarks>
        /// This operator uses deferred execution and streams it results.
        /// </remarks>
        public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count)
        {
            return MoreEnumerable.PartialSort(source, count);
        }
    }

    /// <summary><c>PartialSort</c> extension.</summary>
    public static partial class PartialSortExtension
    {
        /// <summary>
        /// Combines <see cref = "MoreEnumerable.OrderBy{T, TKey}(IEnumerable{T}, Func{T, TKey}, IComparer{TKey}, OrderByDirection)"/>,
        /// where each element is its key, and <see cref = "Enumerable.Take{TSource}"/>
        /// in a single operation.
        /// An additional parameter specifies the direction of the sort
        /// </summary>
        /// <typeparam name = "T">Type of elements in the sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "count">Number of (maximum) elements to return.</param>
        /// <param name = "direction">The direction in which to sort the elements</param>
        /// <returns>A sequence containing at most top <paramref name = "count"/>
        /// elements from source, in the specified order.</returns>
        /// <remarks>
        /// This operator uses deferred execution and streams it results.
        /// </remarks>
        public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count, OrderByDirection direction)
        {
            return MoreEnumerable.PartialSort(source, count, direction);
        }
    }

    /// <summary><c>PartialSort</c> extension.</summary>
    public static partial class PartialSortExtension
    {
        /// <summary>
        /// Combines <see cref = "Enumerable.OrderBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey}, IComparer{TKey})"/>,
        /// where each element is its key, and <see cref = "Enumerable.Take{TSource}"/>
        /// in a single operation. An additional parameter specifies how the
        /// elements compare to each other.
        /// </summary>
        /// <typeparam name = "T">Type of elements in the sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "count">Number of (maximum) elements to return.</param>
        /// <param name = "comparer">A <see cref = "IComparer{T}"/> to compare elements.</param>
        /// <returns>A sequence containing at most top <paramref name = "count"/>
        /// elements from source, in their ascending order.</returns>
        /// <remarks>
        /// This operator uses deferred execution and streams it results.
        /// </remarks>
        public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count, IComparer<T> comparer)
        {
            return MoreEnumerable.PartialSort(source, count, comparer);
        }
    }

    /// <summary><c>PartialSort</c> extension.</summary>
    public static partial class PartialSortExtension
    {
        /// <summary>
        /// Combines <see cref = "MoreEnumerable.OrderBy{T, TKey}(IEnumerable{T}, Func{T, TKey}, IComparer{TKey}, OrderByDirection)"/>,
        /// where each element is its key, and <see cref = "Enumerable.Take{TSource}"/>
        /// in a single operation.
        /// Additional parameters specify how the elements compare to each other and
        /// the direction of the sort.
        /// </summary>
        /// <typeparam name = "T">Type of elements in the sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "count">Number of (maximum) elements to return.</param>
        /// <param name = "comparer">A <see cref = "IComparer{T}"/> to compare elements.</param>
        /// <param name = "direction">The direction in which to sort the elements</param>
        /// <returns>A sequence containing at most top <paramref name = "count"/>
        /// elements from source, in the specified order.</returns>
        /// <remarks>
        /// This operator uses deferred execution and streams it results.
        /// </remarks>
        public static IEnumerable<T> PartialSort<T>(this IEnumerable<T> source, int count, IComparer<T> comparer, OrderByDirection direction)
        {
            return MoreEnumerable.PartialSort(source, count, comparer, direction);
        }
    }

    /// <summary><c>PartialSortBy</c> extension.</summary>
    public static partial class PartialSortByExtension
    {
        /// <summary>
        /// Combines <see cref = "Enumerable.OrderBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey}, IComparer{TKey})"/>,
        /// and <see cref = "Enumerable.Take{TSource}"/> in a single operation.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in the sequence.</typeparam>
        /// <typeparam name = "TKey">Type of keys.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "keySelector">A function to extract a key from an element.</param>
        /// <param name = "count">Number of (maximum) elements to return.</param>
        /// <returns>A sequence containing at most top <paramref name = "count"/>
        /// elements from source, in ascending order of their keys.</returns>
        /// <remarks>
        /// This operator uses deferred execution and streams it results.
        /// </remarks>
        public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector)
        {
            return MoreEnumerable.PartialSortBy(source, count, keySelector);
        }
    }

    /// <summary><c>PartialSortBy</c> extension.</summary>
    public static partial class PartialSortByExtension
    {
        /// <summary>
        /// Combines <see cref = "MoreEnumerable.OrderBy{T, TKey}(IEnumerable{T}, Func{T, TKey}, OrderByDirection)"/>,
        /// and <see cref = "Enumerable.Take{TSource}"/> in a single operation.
        /// An additional parameter specifies the direction of the sort
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in the sequence.</typeparam>
        /// <typeparam name = "TKey">Type of keys.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "keySelector">A function to extract a key from an element.</param>
        /// <param name = "count">Number of (maximum) elements to return.</param>
        /// <param name = "direction">The direction in which to sort the elements</param>
        /// <returns>A sequence containing at most top <paramref name = "count"/>
        /// elements from source, in the specified order of their keys.</returns>
        /// <remarks>
        /// This operator uses deferred execution and streams it results.
        /// </remarks>
        public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector, OrderByDirection direction)
        {
            return MoreEnumerable.PartialSortBy(source, count, keySelector, direction);
        }
    }

    /// <summary><c>PartialSortBy</c> extension.</summary>
    public static partial class PartialSortByExtension
    {
        /// <summary>
        /// Combines <see cref = "Enumerable.OrderBy{TSource, TKey}(IEnumerable{TSource}, Func{TSource, TKey}, IComparer{TKey})"/>,
        /// and <see cref = "Enumerable.Take{TSource}"/> in a single operation.
        /// An additional parameter specifies how the keys compare to each other.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in the sequence.</typeparam>
        /// <typeparam name = "TKey">Type of keys.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "keySelector">A function to extract a key from an element.</param>
        /// <param name = "count">Number of (maximum) elements to return.</param>
        /// <param name = "comparer">A <see cref = "IComparer{T}"/> to compare elements.</param>
        /// <returns>A sequence containing at most top <paramref name = "count"/>
        /// elements from source, in ascending order of their keys.</returns>
        /// <remarks>
        /// This operator uses deferred execution and streams it results.
        /// </remarks>
        public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return MoreEnumerable.PartialSortBy(source, count, keySelector, comparer);
        }
    }

    /// <summary><c>PartialSortBy</c> extension.</summary>
    public static partial class PartialSortByExtension
    {
        /// <summary>
        /// Combines <see cref = "MoreEnumerable.OrderBy{T, TKey}(IEnumerable{T}, Func{T, TKey}, OrderByDirection)"/>,
        /// and <see cref = "Enumerable.Take{TSource}"/> in a single operation.
        /// Additional parameters specify how the elements compare to each other and
        /// the direction of the sort.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in the sequence.</typeparam>
        /// <typeparam name = "TKey">Type of keys.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "keySelector">A function to extract a key from an element.</param>
        /// <param name = "count">Number of (maximum) elements to return.</param>
        /// <param name = "comparer">A <see cref = "IComparer{T}"/> to compare elements.</param>
        /// <param name = "direction">The direction in which to sort the elements</param>
        /// <returns>A sequence containing at most top <paramref name = "count"/>
        /// elements from source, in the specified order of their keys.</returns>
        /// <remarks>
        /// This operator uses deferred execution and streams it results.
        /// </remarks>
        public static IEnumerable<TSource> PartialSortBy<TSource, TKey>(this IEnumerable<TSource> source, int count, Func<TSource, TKey> keySelector, IComparer<TKey> comparer, OrderByDirection direction)
        {
            return MoreEnumerable.PartialSortBy(source, count, keySelector, comparer, direction);
        }
    }

    /// <summary><c>Permutations</c> extension.</summary>
    public static partial class PermutationsExtension
    {
        /// <summary>
        /// Generates a sequence of lists that represent the permutations of the original sequence.
        /// </summary>
        /// <remarks>
        /// A permutation is a unique re-ordering of the elements of the sequence.<br/>
        /// This operator returns permutations in a deferred, streaming fashion; however, each
        /// permutation is materialized into a new list. There are N! permutations of a sequence,
        /// where N => sequence.Count().<br/>
        /// Be aware that the original sequence is considered one of the permutations and will be
        /// returned as one of the results.
        /// </remarks>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <param name = "sequence">The original sequence to permute</param>
        /// <returns>A sequence of lists representing permutations of the original sequence</returns>
        public static IEnumerable<IList<T>> Permutations<T>(this IEnumerable<T> sequence)
        {
            return MoreEnumerable.Permutations(sequence);
        }
    }

    /// <summary><c>Pipe</c> extension.</summary>
    public static partial class PipeExtension
    {
        /// <summary>
        /// Executes the given action on each element in the source sequence
        /// and yields it.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <param name = "source">The sequence of elements</param>
        /// <param name = "action">The action to execute on each element</param>
        /// <returns>A sequence with source elements in their original order.</returns>
        /// <remarks>
        /// The returned sequence is essentially a duplicate of
        /// the original, but with the extra action being executed while the
        /// sequence is evaluated. The action is always taken before the element
        /// is yielded, so any changes made by the action will be visible in the
        /// returned sequence. This operator uses deferred execution and streams it results.
        /// </remarks>
        public static IEnumerable<T> Pipe<T>(this IEnumerable<T> source, Action<T> action)
        {
            return MoreEnumerable.Pipe(source, action);
        }
    }

    /// <summary><c>Prepend</c> extension.</summary>
    public static partial class PrependExtension
    {
        /// <summary>
        /// Prepends a single value to a sequence.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of <paramref name = "source"/>.</typeparam>
        /// <param name = "source">The sequence to prepend to.</param>
        /// <param name = "value">The value to prepend.</param>
        /// <returns>
        /// Returns a sequence where a value is prepended to it.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <code>
        /// int[] numbers = { 1, 2, 3 };
        /// IEnumerable&lt;int&gt; result = numbers.Prepend(0);
        /// </code>
        /// The <c>result</c> variable, when iterated over, will yield 
        /// 0, 1, 2 and 3, in turn.
        public static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            return MoreEnumerable.Prepend(source, value);
        }
    }

    /// <summary><c>PreScan</c> extension.</summary>
    public static partial class PreScanExtension
    {
        /// <summary>
        /// Performs a pre-scan (exclusive prefix sum) on a sequence of elements.
        /// </summary>
        /// <remarks>
        /// An exclusive prefix sum returns an equal-length sequence where the
        /// N-th element is the sum of the first N-1 input elements (the first
        /// element is a special case, it is set to the identity). More
        /// generally, the pre-scan allows any commutative binary operation,
        /// not just a sum.
        /// The inclusive version of PreScan is <see cref = "MoreEnumerable.Scan{TSource}"/>.
        /// This operator uses deferred execution and streams its result.
        /// </remarks>
        /// <example>
        /// <code>
        /// Func&lt;int, int, int&gt; plus = (a, b) =&gt; a + b;
        /// int[] values = { 1, 2, 3, 4 };
        /// IEnumerable&lt;int&gt; prescan = values.PreScan(plus, 0);
        /// IEnumerable&lt;int&gt; scan = values.Scan(plus; a + b);
        /// IEnumerable&lt;int&gt; result = values.ZipShortest(prescan, plus);
        /// </code>
        /// <c>prescan</c> will yield <c>{ 0, 1, 3, 6 }</c>, while <c>scan</c>
        /// and <c>result</c> will both yield <c>{ 1, 3, 6, 10 }</c>. This
        /// shows the relationship between the inclusive and exclusive prefix sum.
        /// </example>
        /// <typeparam name = "TSource">Type of elements in source sequence</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "transformation">Transformation operation</param>
        /// <param name = "identity">Identity element (see remarks)</param>
        /// <returns>The scanned sequence</returns>
        public static IEnumerable<TSource> PreScan<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> transformation, TSource identity)
        {
            return MoreEnumerable.PreScan(source, transformation, identity);
        }
    }

    /// <summary><c>RandomSubset</c> extension.</summary>
    public static partial class RandomSubsetExtension
    {
        /// <summary>
        /// Returns a sequence of a specified size of random elements from the original sequence
        /// </summary>
        /// <typeparam name = "T">The type of elements in the sequence</typeparam>
        /// <param name = "sequence">The sequence from which to return random elements</param>
        /// <param name = "subsetSize">The size of the random subset to return</param>
        /// <returns>A random sequence of elements in random order from the original sequence</returns>
        public static IEnumerable<T> RandomSubset<T>(this IEnumerable<T> sequence, int subsetSize)
        {
            return MoreEnumerable.RandomSubset(sequence, subsetSize);
        }
    }

    /// <summary><c>RandomSubset</c> extension.</summary>
    public static partial class RandomSubsetExtension
    {
        /// <summary>
        /// Returns a sequence of a specified size of random elements from the original sequence
        /// </summary>
        /// <typeparam name = "T">The type of elements in the sequence</typeparam>
        /// <param name = "sequence">The sequence from which to return random elements</param>
        /// <param name = "subsetSize">The size of the random subset to return</param>
        /// <param name = "rand">A random generator used as part of the selection algorithm</param>
        /// <returns>A random sequence of elements in random order from the original sequence</returns>
        public static IEnumerable<T> RandomSubset<T>(this IEnumerable<T> sequence, int subsetSize, Random rand)
        {
            return MoreEnumerable.RandomSubset(sequence, subsetSize, rand);
        }
    }

    /// <summary><c>Rank</c> extension.</summary>
    public static partial class RankExtension
    {
        /// <summary>
        /// Ranks each item in the sequence in descending ordering using a default comparer.
        /// </summary>
        /// <typeparam name = "TSource">Type of item in the sequence</typeparam>
        /// <param name = "source">The sequence whose items will be ranked</param>
        /// <returns>A sequence of position integers representing the ranks of the corresponding items in the sequence</returns>
        public static IEnumerable<int> Rank<TSource>(this IEnumerable<TSource> source)
        {
            return MoreEnumerable.Rank(source);
        }
    }

    /// <summary><c>Rank</c> extension.</summary>
    public static partial class RankExtension
    {
        /// <summary>
        /// Rank each item in the sequence using a caller-supplied comparer.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements in the source sequence</typeparam>
        /// <param name = "source">The sequence of items to rank</param>
        /// <param name = "comparer">A object that defines comparison semantics for the elements in the sequence</param>
        /// <returns>A sequence of position integers representing the ranks of the corresponding items in the sequence</returns>
        public static IEnumerable<int> Rank<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            return MoreEnumerable.Rank(source, comparer);
        }
    }

    /// <summary><c>RankBy</c> extension.</summary>
    public static partial class RankByExtension
    {
        /// <summary>
        /// Ranks each item in the sequence in descending ordering by a specified key using a default comparer
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements in the source sequence</typeparam>
        /// <typeparam name = "TKey">The type of the key used to rank items in the sequence</typeparam>
        /// <param name = "source">The sequence of items to rank</param>
        /// <param name = "keySelector">A key selector function which returns the value by which to rank items in the sequence</param>
        /// <returns>A sequence of position integers representing the ranks of the corresponding items in the sequence</returns>
        public static IEnumerable<int> RankBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return MoreEnumerable.RankBy(source, keySelector);
        }
    }

    /// <summary><c>RankBy</c> extension.</summary>
    public static partial class RankByExtension
    {
        /// <summary>
        /// Ranks each item in a sequence using a specified key and a caller-supplied comparer
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements in the source sequence</typeparam>
        /// <typeparam name = "TKey">The type of the key used to rank items in the sequence</typeparam>
        /// <param name = "source">The sequence of items to rank</param>
        /// <param name = "keySelector">A key selector function which returns the value by which to rank items in the sequence</param>
        /// <param name = "comparer">An object that defines the comparison semantics for keys used to rank items</param>
        /// <returns>A sequence of position integers representing the ranks of the corresponding items in the sequence</returns>
        public static IEnumerable<int> RankBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            return MoreEnumerable.RankBy(source, keySelector, comparer);
        }
    }

    /// <summary><c>Repeat</c> extension.</summary>
    public static partial class RepeatExtension
    {
        /// <summary>
        /// Repeats the specific sequences <paramref name = "count"/> times.
        /// </summary>
        /// <typeparam name = "T">Type of elements in sequence</typeparam>
        /// <param name = "sequence">The sequence to repeat</param>
        /// <param name = "count">Number of times to repeat the sequence</param>
        /// <returns>A sequence produced from the repetition of the original source sequence</returns>
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> sequence, int count)
        {
            return MoreEnumerable.Repeat(sequence, count);
        }
    }

    /// <summary><c>RunLengthEncode</c> extension.</summary>
    public static partial class RunLengthEncodeExtension
    {
        /// <summary>
        /// Run-length encodes a sequence by converting consecutive instances of the same element into
        /// a <c>KeyValuePair{T,int}</c> representing the item and its occurrence count.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <param name = "sequence">The sequence to run length encode</param>
        /// <returns>A sequence of <c>KeyValuePair{T,int}</c> where the key is the element and the value is the occurrence count</returns>
        public static IEnumerable<KeyValuePair<T, int>> RunLengthEncode<T>(this IEnumerable<T> sequence)
        {
            return MoreEnumerable.RunLengthEncode(sequence);
        }
    }

    /// <summary><c>RunLengthEncode</c> extension.</summary>
    public static partial class RunLengthEncodeExtension
    {
        /// <summary>
        /// Run-length encodes a sequence by converting consecutive instances of the same element into
        /// a <c>KeyValuePair{T,int}</c> representing the item and its occurrence count. This overload
        /// uses a custom equality comparer to identify equivalent items.
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <param name = "sequence">The sequence to run length encode</param>
        /// <param name = "comparer">The comparer used to identify equivalent items</param>
        /// <returns>A sequence of <c>KeyValuePair{T,int}</c> where they key is the element and the value is the occurrence count</returns>
        public static IEnumerable<KeyValuePair<T, int>> RunLengthEncode<T>(this IEnumerable<T> sequence, IEqualityComparer<T> comparer)
        {
            return MoreEnumerable.RunLengthEncode(sequence, comparer);
        }
    }

    /// <summary><c>Scan</c> extension.</summary>
    public static partial class ScanExtension
    {
        /// <summary>
        /// Peforms a scan (inclusive prefix sum) on a sequence of elements.
        /// </summary>
        /// <remarks>
        /// An inclusive prefix sum returns an equal-length sequence where the
        /// N-th element is the sum of the first N input elements. More
        /// generally, the scan allows any commutative binary operation, not
        /// just a sum.
        /// The exclusive version of Scan is <see cref = "MoreEnumerable.PreScan{TSource}"/>.
        /// This operator uses deferred execution and streams its result.
        /// </remarks>
        /// <example>
        /// <code>
        /// Func&lt;int, int, int&gt; plus = (a, b) =&gt; a + b;
        /// int[] values = { 1, 2, 3, 4 };
        /// IEnumerable&lt;int&gt; prescan = values.PreScan(plus, 0);
        /// IEnumerable&lt;int&gt; scan = values.Scan(plus; a + b);
        /// IEnumerable&lt;int&gt; result = values.ZipShortest(prescan, plus);
        /// </code>
        /// <c>prescan</c> will yield <c>{ 0, 1, 3, 6 }</c>, while <c>scan</c>
        /// and <c>result</c> will both yield <c>{ 1, 3, 6, 10 }</c>. This
        /// shows the relationship between the inclusive and exclusive prefix sum.
        /// </example>
        /// <typeparam name = "TSource">Type of elements in source sequence</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "transformation">Transformation operation</param>
        /// <returns>The scanned sequence</returns>
        /// <exception cref = "System.InvalidOperationException">If <paramref name = "source"/> is empty.</exception>
        public static IEnumerable<TSource> Scan<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> transformation)
        {
            return MoreEnumerable.Scan(source, transformation);
        }
    }

    /// <summary><c>Scan</c> extension.</summary>
    public static partial class ScanExtension
    {
        /// <summary>
        /// Like <see cref = "Enumerable.Aggregate{TSource}"/> except returns 
        /// the sequence of intermediate results as well as the final one. 
        /// An additional parameter specifies a seed.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams its result.
        /// </remarks>
        /// <example>
        /// <code>
        /// var result = Enumerable.Range(1, 5).Scan(0, (a, b) =&gt; a + b);
        /// </code>
        /// When iterated, <c>result</c> will yield <c>{ 0, 1, 3, 6, 10, 15 }</c>.
        /// </example>
        /// <typeparam name = "TSource">Type of elements in source sequence</typeparam>
        /// <typeparam name = "TState">Type of state</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "seed">Initial state to seed</param>
        /// <param name = "transformation">Transformation operation</param>
        /// <returns>The scanned sequence</returns>
        public static IEnumerable<TState> Scan<TSource, TState>(this IEnumerable<TSource> source, TState seed, Func<TState, TSource, TState> transformation)
        {
            return MoreEnumerable.Scan(source, seed, transformation);
        }
    }

    /// <summary><c>Segment</c> extension.</summary>
    public static partial class SegmentExtension
    {
        /// <summary>
        /// Divides a sequence into multiple sequences by using a segment detector based on the original sequence
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <param name = "source">The sequence to segment</param>
        /// <param name = "newSegmentPredicate">A function, which returns <c>true</c> if the given element begins a new segment, and <c>false</c> otherwise</param>
        /// <returns>A sequence of segment, each of which is a portion of the original sequence</returns>
        /// <exception cref = "ArgumentNullException">
        /// Thrown if either <paramref name = "source"/> or <paramref name = "newSegmentPredicate"/> are <see langword = "null"/>.
        /// </exception>
        public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, bool> newSegmentPredicate)
        {
            return MoreEnumerable.Segment(source, newSegmentPredicate);
        }
    }

    /// <summary><c>Segment</c> extension.</summary>
    public static partial class SegmentExtension
    {
        /// <summary>
        /// Divides a sequence into multiple sequences by using a segment detector based on the original sequence
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <param name = "source">The sequence to segment</param>
        /// <param name = "newSegmentPredicate">A function, which returns <c>true</c> if the given element or index indicate a new segment, and <c>false</c> otherwise</param>
        /// <returns>A sequence of segment, each of which is a portion of the original sequence</returns>
        /// <exception cref = "ArgumentNullException">
        /// Thrown if either <paramref name = "source"/> or <paramref name = "newSegmentPredicate"/> are <see langword = "null"/>.
        /// </exception>
        public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, int, bool> newSegmentPredicate)
        {
            return MoreEnumerable.Segment(source, newSegmentPredicate);
        }
    }

    /// <summary><c>Segment</c> extension.</summary>
    public static partial class SegmentExtension
    {
        /// <summary>
        /// Divides a sequence into multiple sequences by using a segment detector based on the original sequence
        /// </summary>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <param name = "source">The sequence to segment</param>
        /// <param name = "newSegmentPredicate">A function, which returns <c>true</c> if the given current element, previous element or index indicate a new segment, and <c>false</c> otherwise</param>
        /// <returns>A sequence of segment, each of which is a portion of the original sequence</returns>
        /// <exception cref = "ArgumentNullException">
        /// Thrown if either <paramref name = "source"/> or <paramref name = "newSegmentPredicate"/> are <see langword = "null"/>.
        /// </exception>
        public static IEnumerable<IEnumerable<T>> Segment<T>(this IEnumerable<T> source, Func<T, T, int, bool> newSegmentPredicate)
        {
            return MoreEnumerable.Segment(source, newSegmentPredicate);
        }
    }

    /// <summary><c>SkipUntil</c> extension.</summary>
    public static partial class SkipUntilExtension
    {
        /// <summary>
        /// Skips items from the input sequence until the given predicate returns true
        /// when applied to the current source item; that item will be the last skipped.
        /// </summary>
        /// <remarks>
        /// <para>
        /// SkipUntil differs from Enumerable.SkipWhile in two respects. Firstly, the sense
        /// of the predicate is reversed: it is expected that the predicate will return false
        /// to start with, and then return true - for example, when trying to find a matching
        /// item in a sequence.
        /// </para>
        /// <para>
        /// Secondly, SkipUntil skips the element which causes the predicate to return true. For
        /// example, in a sequence <code>{ 1, 2, 3, 4, 5 }</code> and with a predicate of
        /// <code>x => x == 3</code>, the result would be <code>{ 4, 5 }</code>.
        /// </para>
        /// <para>
        /// SkipUntil is as lazy as possible: it will not iterate over the source sequence
        /// until it has to, it won't iterate further than it has to, and it won't evaluate
        /// the predicate until it has to. (This means that an item may be returned which would
        /// actually cause the predicate to throw an exception if it were evaluated, so long as
        /// it comes after the first item causing the predicate to return true.)
        /// </para>
        /// </remarks>
        /// <typeparam name = "TSource">Type of the source sequence</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "predicate">Predicate used to determine when to stop yielding results from the source.</param>
        /// <returns>Items from the source sequence after the predicate first returns true when applied to the item.</returns>
        /// <exception cref = "ArgumentNullException"><paramref name = "source"/> or <paramref name = "predicate"/> is null</exception>
        public static IEnumerable<TSource> SkipUntil<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return MoreEnumerable.SkipUntil(source, predicate);
        }
    }

    /// <summary><c>Slice</c> extension.</summary>
    public static partial class SliceExtension
    {
        /// <summary>
        /// Extracts <paramref name = "count"/> elements from a sequence at a particular zero-based starting index
        /// </summary>
        /// <remarks>
        /// If the starting position or count specified result in slice extending past the end of the sequence,
        /// it will return all elements up to that point. There is no guarantee that the resulting sequence will
        /// contain the number of elements requested - it may have anywhere from 0 to <paramref name = "count"/>.<br/>
        /// This method is implemented in an optimized manner for any sequence implementing <c>IList{T}</c>.<br/>
        /// The result of Slice() is identical to: <c>sequence.Skip(startIndex).Take(count)</c>
        /// </remarks>
        /// <typeparam name = "T">The type of the elements in the source sequence</typeparam>
        /// <param name = "sequence">The sequence from which to extract elements</param>
        /// <param name = "startIndex">The zero-based index at which to begin slicing</param>
        /// <param name = "count">The number of items to slice out of the index</param>
        /// <returns>A new sequence containing any elements sliced out from the source sequence</returns>
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> sequence, int startIndex, int count)
        {
            return MoreEnumerable.Slice(sequence, startIndex, count);
        }
    }

    /// <summary><c>SortedMerge</c> extension.</summary>
    public static partial class SortedMergeExtension
    {
        /// <summary>
        /// Merges two or more sequences that are in a common order (either ascending or descending) into
        /// a single sequence that preserves that order.
        /// </summary>
        /// <remarks>
        /// Using SortedMerge on sequences that are not ordered or are not in the same order produces
        /// undefined results.<br/>
        /// <c>SortedMerge</c> uses performs the merge in a deferred, streaming manner. <br/>
        /// 
        /// Here is an example of a merge, as well as the produced result:
        /// <code>
        ///   var s1 = new[] { 3, 7, 11 };
        ///   var s2 = new[] { 2, 4, 20 };
        ///   var s3 = new[] { 17, 19, 25 };
        ///   var merged = s1.SortedMerge( OrderByDirection.Ascending, s2, s3 );
        ///   var result = merged.ToArray();
        ///   // result will be:
        ///   // { 2, 3, 4, 7, 11, 17, 19, 20, 25 }
        /// </code>
        /// </remarks>
        /// <typeparam name = "TSource">The type of the elements of the sequence</typeparam>
        /// <param name = "source">The primary sequence with which to merge</param>
        /// <param name = "direction">The ordering that all sequences must already exhibit</param>
        /// <param name = "otherSequences">A variable argument array of zero or more other sequences to merge with</param>
        /// <returns>A merged, order-preserving sequence containing all of the elements of the original sequences</returns>
        public static IEnumerable<TSource> SortedMerge<TSource>(this IEnumerable<TSource> source, OrderByDirection direction, params IEnumerable<TSource>[] otherSequences)
        {
            return MoreEnumerable.SortedMerge(source, direction, otherSequences);
        }
    }

    /// <summary><c>SortedMerge</c> extension.</summary>
    public static partial class SortedMergeExtension
    {
        /// <summary>
        /// Merges two or more sequences that are in a common order (either ascending or descending) into
        /// a single sequence that preserves that order.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements in the sequence</typeparam>
        /// <param name = "source">The primary sequence with which to merge</param>
        /// <param name = "direction">The ordering that all sequences must already exhibit</param>
        /// <param name = "comparer">The comparer used to evaluate the relative order between elements</param>
        /// <param name = "otherSequences">A variable argument array of zero or more other sequences to merge with</param>
        /// <returns>A merged, order-preserving sequence containing al of the elements of the original sequences</returns>
        public static IEnumerable<TSource> SortedMerge<TSource>(this IEnumerable<TSource> source, OrderByDirection direction, IComparer<TSource> comparer, params IEnumerable<TSource>[] otherSequences)
        {
            return MoreEnumerable.SortedMerge(source, direction, comparer, otherSequences);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by a separator.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separator">Separator element.</param>
        /// <returns>A sequence of splits of elements.</returns>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator)
        {
            return MoreEnumerable.Split(source, separator);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by a separator given a maximum count of splits.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separator">Separator element.</param>
        /// <param name = "count">Maximum number of splits.</param>
        /// <returns>A sequence of splits of elements.</returns>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator, int count)
        {
            return MoreEnumerable.Split(source, separator, count);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by a separator and then transforms
        /// the splits into results.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <typeparam name = "TResult">Type of the result sequence elements.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separator">Separator element.</param>
        /// <param name = "resultSelector">Function used to project splits
        /// of source elements into elements of the resulting sequence.</param>
        /// <returns>
        /// A sequence of values typed as <typeparamref name = "TResult"/>.
        /// </returns>
        public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            return MoreEnumerable.Split(source, separator, resultSelector);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by a separator, given a maximum count
        /// of splits, and then transforms the splits into results.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <typeparam name = "TResult">Type of the result sequence elements.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separator">Separator element.</param>
        /// <param name = "count">Maximum number of splits.</param>
        /// <param name = "resultSelector">Function used to project splits
        /// of source elements into elements of the resulting sequence.</param>
        /// <returns>
        /// A sequence of values typed as <typeparamref name = "TResult"/>.
        /// </returns>
        public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            return MoreEnumerable.Split(source, separator, count, resultSelector);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by a separator and then transforms the
        /// splits into results.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separator">Separator element.</param>
        /// <param name = "comparer">Comparer used to determine separator
        /// element equality.</param>
        /// <returns>A sequence of splits of elements.</returns>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer)
        {
            return MoreEnumerable.Split(source, separator, comparer);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by a separator, given a maximum count
        /// of splits. A parameter specifies how the separator is compared
        /// for equality.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separator">Separator element.</param>
        /// <param name = "comparer">Comparer used to determine separator
        /// element equality.</param>
        /// <param name = "count">Maximum number of splits.</param>
        /// <returns>A sequence of splits of elements.</returns>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer, int count)
        {
            return MoreEnumerable.Split(source, separator, comparer, count);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by a separator and then transforms the
        /// splits into results. A parameter specifies how the separator is
        /// compared for equality.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <typeparam name = "TResult">Type of the result sequence elements.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separator">Separator element.</param>
        /// <param name = "comparer">Comparer used to determine separator
        /// element equality.</param>
        /// <param name = "resultSelector">Function used to project splits
        /// of source elements into elements of the resulting sequence.</param>
        /// <returns>
        /// A sequence of values typed as <typeparamref name = "TResult"/>.
        /// </returns>
        public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer, Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            return MoreEnumerable.Split(source, separator, comparer, resultSelector);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by a separator, given a maximum count
        /// of splits, and then transforms the splits into results. A
        /// parameter specifies how the separator is compared for equality.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <typeparam name = "TResult">Type of the result sequence elements.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separator">Separator element.</param>
        /// <param name = "comparer">Comparer used to determine separator
        /// element equality.</param>
        /// <param name = "count">Maximum number of splits.</param>
        /// <param name = "resultSelector">Function used to project splits
        /// of source elements into elements of the resulting sequence.</param>
        /// <returns>
        /// A sequence of values typed as <typeparamref name = "TResult"/>.
        /// </returns>
        public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, TSource separator, IEqualityComparer<TSource> comparer, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            return MoreEnumerable.Split(source, separator, comparer, count, resultSelector);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by separator elements identified by a
        /// function.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separatorFunc">Predicate function used to determine
        /// the splitter elements in the source sequence.</param>
        /// <returns>A sequence of splits of elements.</returns>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc)
        {
            return MoreEnumerable.Split(source, separatorFunc);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by separator elements identified by a
        /// function, given a maximum count of splits.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separatorFunc">Predicate function used to determine
        /// the splitter elements in the source sequence.</param>
        /// <param name = "count">Maximum number of splits.</param>
        /// <returns>A sequence of splits of elements.</returns>
        public static IEnumerable<IEnumerable<TSource>> Split<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc, int count)
        {
            return MoreEnumerable.Split(source, separatorFunc, count);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by separator elements identified by
        /// a function and then transforms the splits into results.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <typeparam name = "TResult">Type of the result sequence elements.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separatorFunc">Predicate function used to determine
        /// the splitter elements in the source sequence.</param>
        /// <param name = "resultSelector">Function used to project splits
        /// of source elements into elements of the resulting sequence.</param>
        /// <returns>
        /// A sequence of values typed as <typeparamref name = "TResult"/>.
        /// </returns>
        public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc, Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            return MoreEnumerable.Split(source, separatorFunc, resultSelector);
        }
    }

    /// <summary><c>Split</c> extension.</summary>
    public static partial class SplitExtension
    {
        /// <summary>
        /// Splits the source sequence by separator elements identified by
        /// a function, given a maximum count of splits, and then transforms
        /// the splits into results.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence.</typeparam>
        /// <typeparam name = "TResult">Type of the result sequence elements.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "separatorFunc">Predicate function used to determine
        /// the splitter elements in the source sequence.</param>
        /// <param name = "count">Maximum number of splits.</param>
        /// <param name = "resultSelector">Function used to project a split
        /// group of source elements into an element of the resulting sequence.</param>
        /// <returns>
        /// A sequence of values typed as <typeparamref name = "TResult"/>.
        /// </returns>
        public static IEnumerable<TResult> Split<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool> separatorFunc, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            return MoreEnumerable.Split(source, separatorFunc, count, resultSelector);
        }
    }

    /// <summary><c>StartsWith</c> extension.</summary>
    public static partial class StartsWithExtension
    {
        /// <summary>
        /// Determines whether the beginning of the first sequence is
        /// equivalent to the second sequence, using the default equality
        /// comparer.
        /// </summary>
        /// <typeparam name = "T">Type of elements.</typeparam>
        /// <param name = "first">The sequence to check.</param>
        /// <param name = "second">The sequence to compare to.</param>
        /// <returns>
        /// <c>true</c> if <paramref name = "first"/> begins with elements
        /// equivalent to <paramref name = "second"/>.
        /// </returns>
        /// <remarks>
        /// This is the <see cref = "IEnumerable{T}"/> equivalent of 
        /// <see cref = "string.StartsWith(string)"/> and it calls
        /// <see cref = "IEqualityComparer{T}.Equals(T, T)"/> using 
        /// <see cref = "EqualityComparer{T}.Default"/> on pairs of elements at
        /// the same index.
        /// </remarks>
        public static bool StartsWith<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return MoreEnumerable.StartsWith(first, second);
        }
    }

    /// <summary><c>StartsWith</c> extension.</summary>
    public static partial class StartsWithExtension
    {
        /// <summary>
        /// Determines whether the beginning of the first sequence is
        /// equivalent to the second sequence, using the specified element
        /// equality comparer.
        /// </summary>
        /// <typeparam name = "T">Type of elements.</typeparam>
        /// <param name = "first">The sequence to check.</param>
        /// <param name = "second">The sequence to compare to.</param>
        /// <param name = "comparer">Equality comparer to use.</param>
        /// <returns>
        /// <c>true</c> if <paramref name = "first"/> begins with elements
        /// equivalent to <paramref name = "second"/>.
        /// </returns>
        /// <remarks>
        /// This is the <see cref = "IEnumerable{T}"/> equivalent of 
        /// <see cref = "string.StartsWith(string)"/> and
        /// it calls <see cref = "IEqualityComparer{T}.Equals(T, T)"/> on pairs
        /// of elements at the same index.
        /// </remarks>
        public static bool StartsWith<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
        {
            return MoreEnumerable.StartsWith(first, second, comparer);
        }
    }

    /// <summary><c>Subsets</c> extension.</summary>
    public static partial class SubsetsExtension
    {
        /// <summary>
        /// Returns a sequence of <see cref = "IList{T}"/> representing all of the subsets
        /// of any size that are part of the original sequence.
        /// </summary>
        /// <remarks>
        /// This operator produces all of the subsets of a given sequence. Subsets are returned
        /// in increasing cardinality, starting with the empty set and terminating with the
        /// entire original sequence.<br/>
        /// Subsets are produced in a deferred, streaming manner; however, each subset is returned 
        /// as a materialized list.<br/>
        /// There are 2^N subsets of a given sequence, where N => sequence.Count(). 
        /// </remarks>
        /// <param name = "sequence">Sequence for which to produce subsets</param>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <returns>A sequence of lists that represent the all subsets of the original sequence</returns>
        /// <exception cref = "ArgumentNullException">Thrown if <paramref name = "sequence"/> is <see langword = "null"/></exception>
        public static IEnumerable<IList<T>> Subsets<T>(this IEnumerable<T> sequence)
        {
            return MoreEnumerable.Subsets(sequence);
        }
    }

    /// <summary><c>Subsets</c> extension.</summary>
    public static partial class SubsetsExtension
    {
        /// <summary>
        /// Returns a sequence of <see cref = "IList{T}"/> representing all subsets of the
        /// specified size that are part of the original sequence.
        /// </summary>
        /// <param name = "sequence">Sequence for which to produce subsets</param>
        /// <param name = "subsetSize">The size of the subsets to produce</param>
        /// <typeparam name = "T">The type of the elements in the sequence</typeparam>
        /// <returns>A sequence of lists that represents of K-sized subsets of the original sequence</returns>
        /// <exception cref = "ArgumentNullException">
        /// Thrown if <paramref name = "sequence"/> is <see langword = "null"/>
        /// </exception>
        /// <exception cref = "ArgumentOutOfRangeException">
        /// Thrown if <paramref name = "subsetSize"/> is less than zero.
        /// </exception>
        public static IEnumerable<IList<T>> Subsets<T>(this IEnumerable<T> sequence, int subsetSize)
        {
            return MoreEnumerable.Subsets(sequence, subsetSize);
        }
    }

    /// <summary><c>TagFirstLast</c> extension.</summary>
    public static partial class TagFirstLastExtension
    {
        /// <summary>
        /// Returns a sequence resulting from applying a function to each 
        /// element in the source sequence with additional parameters 
        /// indicating whether the element is the first and/or last of the 
        /// sequence.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of <paramref name = "source"/>.</typeparam>
        /// <typeparam name = "TResult">The type of the element of the returned sequence.</typeparam>
        /// <param name = "source">The source sequence.</param>
        /// <param name = "resultSelector">A function that determines how to 
        /// project the each element along with its first or last tag.</param>
        /// <returns>
        /// Returns the resulting sequence.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// var numbers = new[] { 123, 456, 789 };
        /// var result = numbers.TagFirstLast((num, fst, lst) => new 
        ///              { 
        ///                  Number = num,
        ///                  IsFirst = fst, IsLast = lst
        ///              });
        /// </code>
        /// The <c>result</c> variable, when iterated over, will yield 
        /// <c>{ Number = 123, IsFirst = True, IsLast = False }</c>, 
        /// <c>{ Number = 456, IsFirst = False, IsLast = False }</c> and 
        /// <c>{ Number = 789, IsFirst = False, IsLast = True }</c> in turn.
        /// </example>
        public static IEnumerable<TResult> TagFirstLast<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, bool, bool, TResult> resultSelector)
        {
            return MoreEnumerable.TagFirstLast(source, resultSelector);
        }
    }

    /// <summary><c>TakeEvery</c> extension.</summary>
    public static partial class TakeEveryExtension
    {
        /// <summary>
        /// Returns every N-th element of a sequence.
        /// </summary>
        /// <typeparam name = "TSource">Type of the source sequence</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "step">Number of elements to bypass before returning the next element.</param>
        /// <returns>
        /// A sequence with every N-th element of the input sequence.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// int[] numbers = { 1, 2, 3, 4, 5 };
        /// IEnumerable&lt;int&gt; result = numbers.TakeEvery(2);
        /// </code>
        /// The <c>result</c> variable, when iterated over, will yield 1, 3 and 5, in turn.
        /// </example>
        public static IEnumerable<TSource> TakeEvery<TSource>(this IEnumerable<TSource> source, int step)
        {
            return MoreEnumerable.TakeEvery(source, step);
        }
    }

    /// <summary><c>TakeLast</c> extension.</summary>
    public static partial class TakeLastExtension
    {
        /// <summary>
        /// Returns a specified number of contiguous elements from the end of 
        /// a sequence.
        /// </summary>
        /// <typeparam name = "TSource">The type of the elements of <paramref name = "source"/>.</typeparam>
        /// <param name = "source">The sequence to return the last element of.</param>
        /// <param name = "count">The number of elements to return.</param>
        /// <returns>
        /// An <see cref = "IEnumerable{T}"/> that contains the specified number of 
        /// elements from the end of the input sequence.
        /// </returns>
        /// <remarks>
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// int[] numbers = { 12, 34, 56, 78 };
        /// IEnumerable&lt;int&gt; result = numbers.TakeLast(2);
        /// </code>
        /// The <c>result</c> variable, when iterated over, will yield 
        /// 56 and 78 in turn.
        /// </example>
        public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> source, int count)
        {
            return MoreEnumerable.TakeLast(source, count);
        }
    }

    /// <summary><c>TakeUntil</c> extension.</summary>
    public static partial class TakeUntilExtension
    {
        /// <summary>
        /// Returns items from the input sequence until the given predicate returns true
        /// when applied to the current source item; that item will be the last returned.
        /// </summary>
        /// <remarks>
        /// <para>
        /// TakeUntil differs from Enumerable.TakeWhile in two respects. Firstly, the sense
        /// of the predicate is reversed: it is expected that the predicate will return false
        /// to start with, and then return true - for example, when trying to find a matching
        /// item in a sequence.
        /// </para>
        /// <para>
        /// Secondly, TakeUntil yields the element which causes the predicate to return true. For
        /// example, in a sequence <code>{ 1, 2, 3, 4, 5 }</code> and with a predicate of
        /// <code>x => x == 3</code>, the result would be <code>{ 1, 2, 3 }</code>.
        /// </para>
        /// <para>
        /// TakeUntil is as lazy as possible: it will not iterate over the source sequence
        /// until it has to, it won't iterate further than it has to, and it won't evaluate
        /// the predicate until it has to. (This means that an item may be returned which would
        /// actually cause the predicate to throw an exception if it were evaluated, so long as
        /// no more items of data are requested.)
        /// </para>
        /// </remarks>
        /// <typeparam name = "TSource">Type of the source sequence</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "predicate">Predicate used to determine when to stop yielding results from the source.</param>
        /// <returns>Items from the source sequence, until the predicate returns true when applied to the item.</returns>
        /// <exception cref = "ArgumentNullException"><paramref name = "source"/> or <paramref name = "predicate"/> is null</exception>
        public static IEnumerable<TSource> TakeUntil<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return MoreEnumerable.TakeUntil(source, predicate);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence</typeparam>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString<TSource>(this IEnumerable<TSource> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString(this IEnumerable<bool> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString(this IEnumerable<byte> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString(this IEnumerable<char> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString(this IEnumerable<decimal> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString(this IEnumerable<double> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString(this IEnumerable<float> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString(this IEnumerable<int> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString(this IEnumerable<long> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        [CLSCompliant(false)]
        public static string ToDelimitedString(this IEnumerable<sbyte> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString(this IEnumerable<short> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        public static string ToDelimitedString(this IEnumerable<string> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        [CLSCompliant(false)]
        public static string ToDelimitedString(this IEnumerable<uint> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        [CLSCompliant(false)]
        public static string ToDelimitedString(this IEnumerable<ulong> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToDelimitedString</c> extension.</summary>
    public static partial class ToDelimitedStringExtension
    {
        /// <summary>
        /// Creates a delimited string from a sequence of values and
        /// a given delimiter.
        /// </summary>
        /// <param name = "source">The sequence of items to delimit. Each is converted to a string using the
        /// simple ToString() conversion.</param>
        /// <param name = "delimiter">The delimiter to inject between elements. May be null, in which case
        /// the executing thread's current culture's list separator is used.</param>
        /// <returns>
        /// A string that consists of the elements in <paramref name = "source"/>
        /// delimited by <paramref name = "delimiter"/>. If the source sequence
        /// is empty, the method returns an empty string.
        /// </returns>
        /// <remarks>
        /// This operator uses immediate execution and effectively buffers the sequence.
        /// </remarks>
        [CLSCompliant(false)]
        public static string ToDelimitedString(this IEnumerable<ushort> source, string delimiter)
        {
            return MoreEnumerable.ToDelimitedString(source, delimiter);
        }
    }

    /// <summary><c>ToHashSet</c> extension.</summary>
    public static partial class ToHashSetExtension
    {
        /// <summary>
        /// Returns a <see cref = "HashSet{T}"/> of the source items using the default equality
        /// comparer for the type.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in source sequence.</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <returns>A hash set of the items in the sequence, using the default equality comparer.</returns>
        /// <exception cref = "ArgumentNullException"><paramref name = "source"/> is null</exception>
        /// <remarks>
        /// This evaluates the input sequence completely.
        /// </remarks>
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source)
        {
            return MoreEnumerable.ToHashSet(source);
        }
    }

    /// <summary><c>ToHashSet</c> extension.</summary>
    public static partial class ToHashSetExtension
    {
        /// <summary>
        /// Returns a <see cref = "HashSet{T}"/> of the source items using the specified equality
        /// comparer for the type.
        /// </summary>
        /// <typeparam name = "TSource">Type of elements in source sequence.</typeparam>
        /// <param name = "source">Source sequence</param>
        /// <param name = "comparer">Equality comparer to use; a value of null will cause the type's default equality comparer to be used</param>
        /// <returns>A hash set of the items in the sequence, using the default equality comparer.</returns>
        /// <exception cref = "ArgumentNullException"><paramref name = "source"/> is null</exception>
        /// <remarks>
        /// This evaluates the input sequence completely.
        /// </remarks>
        public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            return MoreEnumerable.ToHashSet(source, comparer);
        }
    }

    /// <summary><c>Trace</c> extension.</summary>
    public static partial class TraceExtension
    {
        /// <summary>
        /// Traces the elements of a source sequence for diagnostics.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence</typeparam>
        /// <param name = "source">Source sequence whose elements to trace.</param>
        /// <returns>
        /// Return the source sequence unmodified.
        /// </returns>
        /// <remarks>
        /// This a pass-through operator that uses deferred execution and 
        /// streams the results.
        /// </remarks>
        public static IEnumerable<TSource> Trace<TSource>(this IEnumerable<TSource> source)
        {
            return MoreEnumerable.Trace(source);
        }
    }

    /// <summary><c>Trace</c> extension.</summary>
    public static partial class TraceExtension
    {
        /// <summary>
        /// Traces the elements of a source sequence for diagnostics using
        /// custom formatting.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence</typeparam>
        /// <param name = "source">Source sequence whose elements to trace.</param>
        /// <param name = "format">
        /// String to use to format the trace message. If null then the
        /// element value becomes the traced message.
        /// </param>
        /// <returns>
        /// Return the source sequence unmodified.
        /// </returns>
        /// <remarks>
        /// This a pass-through operator that uses deferred execution and 
        /// streams the results.
        /// </remarks>
        public static IEnumerable<TSource> Trace<TSource>(this IEnumerable<TSource> source, string format)
        {
            return MoreEnumerable.Trace(source, format);
        }
    }

    /// <summary><c>Trace</c> extension.</summary>
    public static partial class TraceExtension
    {
        /// <summary>
        /// Traces the elements of a source sequence for diagnostics using
        /// a custom formatter.
        /// </summary>
        /// <typeparam name = "TSource">Type of element in the source sequence</typeparam>
        /// <param name = "source">Source sequence whose elements to trace.</param>
        /// <param name = "formatter">Function used to format each source element into a string.</param>
        /// <returns>
        /// Return the source sequence unmodified.
        /// </returns>
        /// <remarks>
        /// This a pass-through operator that uses deferred execution and 
        /// streams the results.
        /// </remarks>
        public static IEnumerable<TSource> Trace<TSource>(this IEnumerable<TSource> source, Func<TSource, string> formatter)
        {
            return MoreEnumerable.Trace(source, formatter);
        }
    }

    /// <summary><c>Windowed</c> extension.</summary>
    public static partial class WindowedExtension
    {
        /// <summary>
        /// Processes a sequence into a series of subsequences representing a windowed subset of the original
        /// </summary>
        /// <remarks>
        /// The number of sequences returned is: <c>Max(0, sequence.Count() - windowSize) + 1</c><br/>
        /// Returned subsequences are buffered, but the overall operation is streamed.<br/>
        /// </remarks>
        /// <typeparam name = "TSource">The type of the elements of the source sequence</typeparam>
        /// <param name = "source">The sequence to evaluate a sliding window over</param>
        /// <param name = "size">The size (number of elements) in each window</param>
        /// <returns>A series of sequences representing each sliding window subsequence</returns>
        public static IEnumerable<IEnumerable<TSource>> Windowed<TSource>(this IEnumerable<TSource> source, int size)
        {
            return MoreEnumerable.Windowed(source, size);
        }
    }

    /// <summary><c>ZipLongest</c> extension.</summary>
    public static partial class ZipLongestExtension
    {
        /// <summary>
        /// Returns a projection of tuples, where each tuple contains the N-th element
        /// from each of the argument sequences.
        /// </summary>
        /// <remarks>
        /// If the two input sequences are of different lengths then the result
        /// sequence will always be as long as the longer of the two input sequences.
        /// The default value of the shorter sequence element type is used for padding.
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// int[] numbers = { 1, 2, 3 };
        /// string[] letters = { "A", "B", "C", "D" };
        /// var zipped = numbers.EquiZip(letters, (n, l) => n + l);
        /// </code>
        /// The <c>zipped</c> variable, when iterated over, will yield "1A", "2B", "3C", "0D" in turn.
        /// </example>
        /// <typeparam name = "TFirst">Type of elements in first sequence</typeparam>
        /// <typeparam name = "TSecond">Type of elements in second sequence</typeparam>
        /// <typeparam name = "TResult">Type of elements in result sequence</typeparam>
        /// <param name = "first">First sequence</param>
        /// <param name = "second">Second sequence</param>
        /// <param name = "resultSelector">Function to apply to each pair of elements</param>
        /// <returns>
        /// A sequence that contains elements of the two input sequences,
        /// combined by <paramref name = "resultSelector"/>.
        /// </returns>
        public static IEnumerable<TResult> ZipLongest<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            return MoreEnumerable.ZipLongest(first, second, resultSelector);
        }
    }

    /// <summary><c>ZipShortest</c> extension.</summary>
    public static partial class ZipShortestExtension
    {
        /// <summary>
        /// Returns a projection of tuples, where each tuple contains the N-th element 
        /// from each of the argument sequences.
        /// </summary>
        /// <remarks>
        /// If the input sequences are of different lengths, the result sequence 
        /// is terminated as soon as the shortest input sequence is exhausted.
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// var numbers = new[] { 1, 2, 3 };
        /// var letters = new[] { "A", "B", "C", "D" };
        /// var chars   = new[] { 'a', 'b', 'c', 'd', 'e' };
        /// var zipped  = numbers.ZipShortest(letters, chars, (n, l, c) => c + n + l);
        /// </code>
        /// The <c>zipped</c> variable, when iterated over, will yield 
        /// "98A", "100B", "102C", in turn.
        /// </example>
        /// <typeparam name = "T1">Type of elements in first sequence</typeparam>
        /// <typeparam name = "T2">Type of elements in second sequence</typeparam>
        /// <typeparam name = "T3">Type of elements in third sequence</typeparam>
        /// <typeparam name = "TResult">Type of elements in result sequence</typeparam>
        /// <param name = "first">First sequence</param>
        /// <param name = "second">Second sequence</param>
        /// <param name = "third">Third sequence</param>
        /// <param name = "resultSelector">Function to apply to each triplet of elements</param>
        /// <returns>A projection of tuples, where each tuple contains the N-th element from each of the argument sequences.</returns>
        public static IEnumerable<TResult> ZipShortest<T1, T2, T3, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, Func<T1, T2, T3, TResult> resultSelector)
        {
            return MoreEnumerable.ZipShortest(first, second, third, resultSelector);
        }
    }

    /// <summary><c>ZipShortest</c> extension.</summary>
    public static partial class ZipShortestExtension
    {
        /// <summary>
        /// Returns a projection of tuples, where each tuple contains the N-th element 
        /// from each of the argument sequences.
        /// </summary>
        /// <remarks>
        /// If the input sequences are of different lengths, the result sequence 
        /// is terminated as soon as the shortest input sequence is exhausted.
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// var numbers = new[] { 1, 2, 3 };
        /// var letters = new[] { "A", "B", "C", "D" };
        /// var chars   = new[] { 'a', 'b', 'c', 'd', 'e' };
        /// var flags   = new[] { true, false };
        /// var zipped  = numbers.ZipShortest(letters, chars, flags (n, l, c, f) => n + l + c + f);
        /// </code>
        /// The <c>zipped</c> variable, when iterated over, will yield 
        /// "1AaTrue", "2BbFalse" in turn.
        /// </example>
        /// <typeparam name = "T1">Type of elements in first sequence</typeparam>
        /// <typeparam name = "T2">Type of elements in second sequence</typeparam>
        /// <typeparam name = "T3">Type of elements in third sequence</typeparam>
        /// <typeparam name = "T4">Type of elements in fourth sequence</typeparam>
        /// <typeparam name = "TResult">Type of elements in result sequence</typeparam>
        /// <param name = "first">First sequence</param>
        /// <param name = "second">Second sequence</param>
        /// <param name = "third">Third sequence</param>
        /// <param name = "fourth">Fourth sequence</param>
        /// <param name = "resultSelector">Function to apply to each quadruplet of elements</param>
        /// <returns>A projection of tuples, where each tuple contains the N-th element from each of the argument sequences.</returns>
        public static IEnumerable<TResult> ZipShortest<T1, T2, T3, T4, TResult>(this IEnumerable<T1> first, IEnumerable<T2> second, IEnumerable<T3> third, IEnumerable<T4> fourth, Func<T1, T2, T3, T4, TResult> resultSelector)
        {
            return MoreEnumerable.ZipShortest(first, second, third, fourth, resultSelector);
        }
    }

    /// <summary><c>ZipShortest</c> extension.</summary>
    public static partial class ZipShortestExtension
    {
        /// <summary>
        /// Returns a projection of tuples, where each tuple contains the N-th element 
        /// from each of the argument sequences.
        /// </summary>
        /// <remarks>
        /// If the two input sequences are of different lengths, the result sequence 
        /// is terminated as soon as the shortest input sequence is exhausted.
        /// This operator uses deferred execution and streams its results.
        /// </remarks>
        /// <example>
        /// <code>
        /// var numbers = new[] { 1, 2, 3 };
        /// var letters = new[] { "A", "B", "C", "D" };
        /// var zipped = numbers.ZipShortest(letters, (n, l) => n + l);
        /// </code>
        /// The <c>zipped</c> variable, when iterated over, will yield "1A", "2B", "3C", in turn.
        /// </example>
        /// <typeparam name = "TFirst">Type of elements in first sequence</typeparam>
        /// <typeparam name = "TSecond">Type of elements in second sequence</typeparam>
        /// <typeparam name = "TResult">Type of elements in result sequence</typeparam>
        /// <param name = "first">First sequence</param>
        /// <param name = "second">Second sequence</param>
        /// <param name = "resultSelector">Function to apply to each pair of elements</param>
        /// <returns>A projection of tuples, where each tuple contains the N-th element from each of the argument sequences</returns>
        public static IEnumerable<TResult> ZipShortest<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            return MoreEnumerable.ZipShortest(first, second, resultSelector);
        }
    }
}
