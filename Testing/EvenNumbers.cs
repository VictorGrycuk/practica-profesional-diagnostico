using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagnostico2019.Exercises;

namespace Testing
{
    [TestClass]
    public class TestingEvenNumbers
    {
        [TestMethod]
        public void GetEvenNumbers()
        {
            int[] input = new int[] { 45, 23, 52, 68, 2, 98, 106, 107, 465, 23, 18 };
            int[] expected = new int[] { 52, 68, 2, 98, 106, 18 };
            int[] result = EvenNumbers.FilterEvenNumbers(input);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CountEvenNumbers()
        {
            int[] input = new int[] { 45, 23, 52, 68, 2, 98, 106, 107, 465, 23, 18 };
            int result = EvenNumbers.CountEvenNumbers(input);

            Assert.AreEqual(6, result);
        }
    }
}
