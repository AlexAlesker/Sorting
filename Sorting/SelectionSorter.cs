using System;

namespace Sorting {

public class SelectionSorter : Sorter {
    public override void Sort<T>(T[] items) {
        for (var i = 0; i < items.Length - 1; i++) {
            var minIndex = GetMinIndex(items, i);
            if (items[minIndex].CompareTo(items[i]) < 0) {
                Swap(ref items[i], ref items[minIndex]);
            }
        }

        NumberOfRuns = items.Length - 1;
    }

    public override int NumberOfRuns { get; set; }

    private static int GetMinIndex<T>(T[] items, int startIndex) where T : IComparable<T> {
        var minIndex = startIndex;

        for (var i = startIndex + 1; i < items.Length; i++) {
            if (items[i].CompareTo(items[minIndex]) < 0) {
                minIndex = i;
            }
        }

        return minIndex;
    }
}
}
