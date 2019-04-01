using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnostico2019.Exercises;

namespace Diagnostico2019
{
    static class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu("== Diagnostico 2019 ==", "Please select one of the following items:");
            menu.AddOption(EvenNumbers.GetNumbers, "Filter and show even numbers.");
            menu.AddOption(BubbleSort.SortDescending, "Bubble sort array in descensing order.");
            menu.AddOption(Dates.GetMondays, "Shows the list of dates of a specific week day between two given dates.");
            menu.AddOption(Fibonacci.GetFibonacci, "Returns a Fibonaci sequence of a given lenght.");
            menu.AddOption(ImageValidation.Validate, "Takes two images and returns wether they are the same or not.");
            menu.AddOption(OhmLaw.ShowMenu, "Ohm's calculator.");
            menu.AddOption(TwoPoints.GetDistance, "Calculates the distance between two points.");
            menu.AddOption(Hash.Encode, "Generates a 16 characters hash from a given string.");
            menu.AddOption(ResolveJaggedArray.FindElement, "Find a value in a jagged array and returns its position.");
            menu.AddOption(ParabolicProjectile.Calculate, "Calculates the maximum distance of X and Y of a parabolic projectile using initial speed and angle.");

            while (!menu.Exit)
            {
                Console.Clear();
                menu.ShowMenu();
                menu.GetSelection();
            }
        }
    }
}

