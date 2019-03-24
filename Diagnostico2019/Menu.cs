using System;
using System.Collections.Generic;
using System.Linq;

namespace Diagnostico2019
{
    public class Menu
    {
        public bool Exit;

        private string title;
        private string description;
        private List<Option> options = new List<Option>();

        public Menu(string title, string description)
        {
            this.title = title;
            this.description = description;
            options.Add(new Option { func = null, description = "Exit." });
        }

        public void AddOption(Action action, string optionDescription)
        {
            var exit = options[options.Count - 1];
            options.RemoveAt(options.Count - 1);
            options.Add(new Option { func = action, description = optionDescription });
            options.Add(exit);
        }

        public void ShowMenu()
        {
            string menu = string.Join(Environment.NewLine,
                title + Environment.NewLine,
                description,
                GetFormatedOptions(options)
            );

            Console.WriteLine(menu);
        }

        public void GetSelection()
        {
            int selection = -1;
            if (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Invalid selection. Please select again.");
            }
            else if (selection > options.Count)
            {
                Console.WriteLine("Selection is out of range. Please select again.");
            }
            else if (selection == options.Count)
            {
                Exit = true;
            }
            else
            {
                Console.Clear();
                var selectedOption = options[selection - 1].func;
                selectedOption.Invoke();
                Retry(selectedOption);
            }
        }

        private static string GetFormatedOptions(List<Option> options)
        {
            string[] formattedOptions = options.Select(o => $"{ Array.IndexOf(options.ToArray(), o) + 1 }. { o.description }").ToArray();
            return string.Join(Environment.NewLine, formattedOptions);
        }

        public class Option
        {
            public Action func;
            public string description;
        }

        private void Retry(Action action)
        {
            Console.WriteLine(Environment.NewLine + "Enter 0 to try again, any other key to return to menu.");
            var key = Console.ReadKey().Key;

            if (key == ConsoleKey.D0 || key == ConsoleKey.NumPad0)
            {
                Console.Clear();
                action.Invoke();
                Retry(action);
            }
        }
    }
}
