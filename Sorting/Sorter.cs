using System;

namespace Sorting {

public interface ISorter {
    void Sort<T>(T[] items) where T : IComparable<T>;
    int NumberOfRuns { get; }
}

public abstract class Sorter : ISorter {
    public abstract void Sort<T>(T[] items) where T : IComparable<T>;
    public abstract int NumberOfRuns { get; set; }

    protected void Swap<T>(ref T left, ref T right) {
        T tmp = left;
        left = right;
        right = tmp;
    }
}
}