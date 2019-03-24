using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnostico2019.Exercises;

namespace Diagnostico2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu("== Diagnostico 2019 ==", "Please select one of the following items:");
            menu.AddOption(EvenNumbers.GetNumbers, "Filter and show even numbers.");

            while (!menu.Exit)
            {
                Console.Clear();
                menu.ShowMenu();
                menu.GetSelection();
            }
        }
    }
}
