namespace Sorting {

public class BubbleSorter : Sorter {
    public override void Sort<T>(T[] items) {
        NumberOfRuns = 0;

        while (true) {
            var changed = false;

            for (var i = 0; i < items.Length - 1; i++) {
                if (items[i].CompareTo(items[i + 1]) > 0) {
                    Swap(ref items[i], ref items[i + 1]);
                    changed = true;
                }
            }

            NumberOfRuns++;

            if (changed) {
                continue;
            }

            break;
        }
    }

    public override int NumberOfRuns { get; set; }
}
}
