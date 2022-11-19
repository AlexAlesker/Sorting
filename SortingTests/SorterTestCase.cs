using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Sorting {

[TestFixture]
public class SorterTestCase {
    private int[] _unsortedArrayInt;
    private double[] _unsortedArrayDouble;
    private static readonly Random Random = new Random();
    private readonly int[] _arraySizes = { 1000, 10000, 100000 };

    [Test]
    public void TestSelectionSorterInt() {
        foreach (var size in _arraySizes) {
            _unsortedArrayInt = GetUnsortedArrayInt(size);
            TestSorter(new SelectionSorter(), _unsortedArrayInt, size);
        }
        
    }

    [Test]
    public void TestSelectionSorterDouble() {
        foreach (var size in _arraySizes) {
            _unsortedArrayDouble = GetUnsortedArrayDouble(size);
            TestSorter(new SelectionSorter(), _unsortedArrayDouble, size);
        }
    }

    private static void TestSorter<T>(ISorter sorter, T[] array, int arraySize) where T : IComparable<T> {
        var sw = new Stopwatch();
        sw.Start();
        sorter.Sort(array);
        sw.Stop();
        Assert.That(IsArraySorted(array, arraySize));
        TestContext.WriteLine($"{sorter} ({array}) of {arraySize}:");
        TestContext.WriteLine($"Time elapsed: {sw.Elapsed}");
    }

    private static bool IsArraySorted<T>(T[] array, int arraySize) where T : IComparable<T> {
        for (var i = 0; i < arraySize - 1; i++) {
            if (array[i].CompareTo(array[i + 1]) > 0) {
                return false;
            }
        }

        return true;
    }

    private static int[] GetUnsortedArrayInt(int arraySize) {
        var buffer = new int[arraySize];

        for (var i = 0; i < arraySize; i++) {
            buffer[i] = Random.Next(arraySize);
        }

        return buffer;
    }

    private static double[] GetUnsortedArrayDouble(int arraySize) {
        var buffer = new double[arraySize];

        for (var i = 0; i < arraySize; i++) {
            buffer[i] = Random.NextDouble() * arraySize;
        }

        return buffer;
    }
}
}