using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diagnostico2019.Exercises;

namespace Testing
{
    [TestClass]
    public class TestFibonacci
    {
        [TestMethod]
        public void GetFibonacci()
        {
            foreach (var element in Fibonacci.GetSequence(50))
            {
                Assert.IsTrue(IsFibonacciNumber(element));
            }
        }

        /// <summary>
        /// There is a method to test if a number corresponds to the Fibonacci sequence:
        /// Ff (5 * n * 2 + 4) or (5 * n * 2 – 4) is a perfect square
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsFibonacciNumber(double number)
        {
            return IsPerfectSquare((5 * number * number) + 4) || (IsPerfectSquare((5 * number * number) - 4));
        }

        private static bool IsPerfectSquare(double number)
        {
            var square = Math.Sqrt(number);
            return square * square == number;
        }
    }
}
