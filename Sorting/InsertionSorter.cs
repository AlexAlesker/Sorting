namespace Sorting {

public class InsertionSorter : Sorter {
    public override void Sort<T>(T[] items) {
        NumberOfRuns = 0;

        for (var i = 1; i < items.Length; i++) {
            var key = items[i];
            var j = i - 1;
            for (; j >= 0 && items[j].CompareTo(key) > 0; j--) {
                items[j + 1] = items[j];
            }

            items[j + 1] = key;

            NumberOfRuns++;
        }
    }

    public override int NumberOfRuns { get; set; }
}
}
