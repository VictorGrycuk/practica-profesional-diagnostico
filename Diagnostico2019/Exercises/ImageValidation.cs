using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace Diagnostico2019.Exercises
{
    public static class ImageValidation
    {
        public static void Validate()
        {
            Console.WriteLine("Enter the path to the first image");
            var firstImage = IOHelper.GetFileInput();

            Console.WriteLine(Environment.NewLine + "Enter the path to the second image");
            var secondImage = IOHelper.GetFileInput();

            // I created three checks, from less resource consumption to more resource consumption,
            // to avoid using much resources when a simple check is enough.

            if (!CheckImagesSize(firstImage, secondImage))
            {
                Console.WriteLine("The images size does not match.");
                return;
            }

            if (!CheckImagesDimensions(firstImage, secondImage))
            {
                Console.WriteLine("The images dimension does not match.");
                return;
            }

            if (!CheckImagesStream(firstImage, secondImage))
            {
                Console.WriteLine("The images are different.");
                return;
            }

            Console.WriteLine("The images are the same.");
        }

        public static bool CheckImagesSize(string file1, string file2)
        {
            var firstImage = new FileInfo(file1);
            var secondImage = new FileInfo(file2);

            return firstImage.Length == secondImage.Length;
        }

        public static bool CheckImagesDimensions(string file1, string file2)
        {
            Image firstImage = Image.FromFile(file1);
            Image secondImage = Image.FromFile(file2);

            var result =  firstImage.Height != secondImage.Height
                ? false
                : firstImage.Width == secondImage.Width;

            firstImage.Dispose();
            secondImage.Dispose();

            return result;
        }

        public static bool CheckImagesStream(string file1, string file2)
        {
            var firstImage = IOHelper.GetFileAsHexa(file1);
            var secondImage = IOHelper.GetFileAsHexa(file2);

            for (int i = 0; i < firstImage.Count; i++)
            {
                if (firstImage[i] != secondImage[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
