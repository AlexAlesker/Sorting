using System;

namespace Sorting {

public interface ISorter {
    void Sort<T>(T[] items) where T : IComparable<T>;
}

public abstract class Sorter : ISorter {
    public abstract void Sort<T>(T[] items) where T : IComparable<T>;

    protected void Swap<T>(ref T left, ref T right) {
        T tmp = left;
        left = right;
        right = tmp;
    }
}
}