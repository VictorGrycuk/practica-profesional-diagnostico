using System;
using Diagnostico2019.Exercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class TestHash
    {
        [TestMethod]
        public void ValidatLength()
        {
            string result = Hash.Encode("This sentence is only used to test the length of the hash encoding algorithm");
            Assert.IsTrue(result.Length == 16);
        }

        [TestMethod]
        public void ValidatDeterminism()
        {
            string result1 = Hash.Encode("Hashing this sentence twice should give the same result");
            string result2 = Hash.Encode("Hashing this sentence twice should give the same result");
            Assert.IsTrue(result1 == result2);
        }
    }
}
