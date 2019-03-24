using Diagnostico2019.Exercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class TestingBubbleSort
    {
        [TestMethod]
        public void SortDescending()
        {
            int[] input = new int[] { 23, 1, 5, 2, 98, 14, 76, 98, 104, 3, 9 };
            int[] expected = new int[] { 104, 98, 98, 76, 23, 14, 9, 5, 3, 2, 1 };
            int[] result = BubbleSort.Sort(input, BubbleSort.IsGreater);

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
