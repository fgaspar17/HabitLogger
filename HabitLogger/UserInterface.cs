using HabitLoggerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger
{
    public  class UserInterface
    {
        public List<T> ShowMenu<T>(IMenu[] menus)
        {
            List<T> result = new List<T>();

            foreach (IMenu menu in menus)
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine(menu.GetMenu());

                    string? input = Console.ReadLine();

                    IValidator<T> validator = ValidatorFactory.GetValidator<T>();
                    (bool inputValid, T userInput) = validator.Validate(input);
                    if (inputValid)
                    {
                        result.Add(userInput);
                        break;
                    }

                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            return result;
        }

        public void ShowRecords()
        {
            Console.WriteLine();
            Console.WriteLine("List of records: ");
            foreach (var record in HabitController.GetRecords())
            {
                Console.WriteLine($"{record.Id}. Day: {record.Day}, Quantity: {record.Quantity}");
            }
        }
    }
}
