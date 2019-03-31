using System;
using System.IO;
using Diagnostico2019.Exercises;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class TestImageValidation
    {
        [TestMethod]
        public void ValidateSize()
        {
            Assert.IsTrue(ImageValidation.CheckImagesSize(GetTestImage("Image1.png"), GetTestImage("Image4.png")));

            Assert.IsTrue(!ImageValidation.CheckImagesSize(GetTestImage("Image1.png"), GetTestImage("Image2.png")));
        }

        [TestMethod]
        public void ValidateDimensions()
        {
            Assert.IsTrue(ImageValidation.CheckImagesDimensions(GetTestImage("Image1.png"), GetTestImage("Image2.png")));

            Assert.IsTrue(!ImageValidation.CheckImagesDimensions(GetTestImage("Image1.png"), GetTestImage("Image3.png")));
        }

        [TestMethod]
        public void ValidateStream()
        {
            Assert.IsTrue(ImageValidation.CheckImagesStream(GetTestImage("Image1.png"), GetTestImage("Image4.png")));

            Assert.IsTrue(!ImageValidation.CheckImagesStream(GetTestImage("Image1.png"), GetTestImage("Image3.png")));
        }

        public string GetTestImage(string name)
        {
            return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "TestFiles" , name);
        }
    }
}
