using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Sorting {

[TestFixture]
public class SorterTestCase {
    protected int[] _unsortedArrayInt;
    private double[] _unsortedArrayDouble;
    private static readonly Random Random = new Random();
    protected readonly int[] _arraySizes = { 1000, 10000, 100000 };

    [Test]
    public virtual void TestSelectionSorterInt() {
        TestSorter(new SelectionSorter());
    }

    [Test]
    public void TestSelectionSorterDouble() {
        var size = _arraySizes[0];
        _unsortedArrayDouble = GetUnsortedArrayDouble(size);
        TestSorter(new SelectionSorter(), _unsortedArrayDouble, size);
    }

    [Test]
    public virtual void TestBubbleSorter() {
        TestSorter(new BubbleSorter());
    }

    [Test]
    public virtual void TestInsertionSorter() {
        TestSorter(new InsertionSorter());
    }

    [Test]
    public virtual void TestQuickSorter() {
        TestSorter(new QuickSorter());
    }

    private void TestSorter(ISorter sorter) {
        var size = _arraySizes[0];
        _unsortedArrayInt = GetUnsortedArrayInt(size);
        TestSorter(sorter, _unsortedArrayInt, size);
    }

    protected static void TestSorter<T>(ISorter sorter, T[] array, int arraySize) where T : IComparable<T> {
        var arrayToSort = (T[]) array.Clone();
        var sw = new Stopwatch();
        sw.Start();
        sorter.Sort(arrayToSort);
        sw.Stop();
        Assert.That(arrayToSort, Is.EquivalentTo(array));
        Assert.That(arrayToSort, Is.Ordered);
        TestContext.WriteLine($"{sorter} ({array}) of {arraySize}; Runs: {sorter.NumberOfRuns}");
        TestContext.WriteLine($"Time elapsed: {sw.Elapsed}");
    }

    protected static int[] GetUnsortedArrayInt(int arraySize) {
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