using System;

namespace Sorting {

public class QuickSorter : Sorter {
    public override void Sort<T>(T[] items) {
        NumberOfRuns = 0;

        QuickSort(items, 0, items.Length - 1);
    }

    private void QuickSort<T>(T[] items, int low, int high) where T : IComparable<T> {
        if (low >= high) {
            return;
        }

        var pivot = high;

        for (var i = low; i < pivot;) {
            if (items[i].CompareTo(items[pivot]) < 0) {
                i++;
                continue;
            }

            var tmpPivot = items[pivot];
            items[pivot] = items[i];
            pivot--;
            items[i] = items[pivot];
            items[pivot] = tmpPivot;

            i = low;
        }

        NumberOfRuns++;

        QuickSort(items, low, pivot - 1);
        QuickSort(items, pivot + 1, high);
    }

    public override int NumberOfRuns { get; set; }
}
}
