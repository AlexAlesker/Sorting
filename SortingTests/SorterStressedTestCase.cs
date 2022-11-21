using NUnit.Framework;

namespace Sorting {

internal class SorterStressedTestCase : SorterTestCase {
    [Test]
    public override void TestSelectionSorterInt() {
        TestSorter(new SelectionSorter());
    }

    [Test]
    public override void TestBubbleSorter() {
        TestSorter(new BubbleSorter());
    }

    [Test]
    public override void TestInsertionSorter() {
        TestSorter(new InsertionSorter());
    }

    private void TestSorter(ISorter sorter) {
        foreach (var size in _arraySizes) {
            _unsortedArrayInt = GetUnsortedArrayInt(size);
            TestSorter(sorter, _unsortedArrayInt, size);
        }
    }
}
}
