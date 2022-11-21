using NUnit.Framework;

namespace Sorting {

internal class SorterStressedTestCase : SorterTestCase {
    [Test]
    public override void TestSelectionSorterInt() {
        foreach (var size in _arraySizes) {
            _unsortedArrayInt = GetUnsortedArrayInt(size);
            TestSorter(new SelectionSorter(), _unsortedArrayInt, size);
        }
    }

    [Test]
    public override void TestBubbleSorter() {
        foreach (var size in _arraySizes) {
            _unsortedArrayInt = GetUnsortedArrayInt(size);
            TestSorter(new BubbleSorter(), _unsortedArrayInt, size);
        }
    }
}
}
