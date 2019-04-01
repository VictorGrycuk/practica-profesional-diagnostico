using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagnostico2019.Exercises;

namespace Testing
{
    [TestClass]
    public class TestJaggedArray
    {
        private int[][] jaggedArray = new int[][]
        {
            new int[] {1, 3, 5, 7, 9},
            new int[] {0, 2, 4, 6},
            new int[] {11, 22}
        };

        [TestMethod]
        public void ValidateResult()
        {
            int[] expectdResult = new int[] { 2, 3 };

            CollectionAssert.AreEqual(ResolveJaggedArray.Find(jaggedArray, 4), expectdResult);
        }

        [TestMethod]
        public void ValidateEmptyResult()
        {
            Assert.IsNull(ResolveJaggedArray.Find(jaggedArray, 25));
        }
    }
}
