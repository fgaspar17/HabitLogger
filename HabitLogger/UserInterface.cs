using HabitLogger.Menus;
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
        public T ShowMenu<T>(IMenu menu)
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
                    return userInput;
                }

                Console.WriteLine("Invalid input. Please try again.");
            }
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

        public void HandleMenuOption(MainMenuOptions option, ref bool continueRunning)
        {
            int userId, userDay, userQuantity;
            switch (option)
            {
                case MainMenuOptions.Quit:
                    continueRunning = false;
                    break;
                case MainMenuOptions.Create:
                    Console.WriteLine("\nInserting...");
                    userDay = ShowMenu<int>(new DayMenu());
                    userQuantity = ShowMenu<int>(new QuantityMenu());
                    HabitController.InsertRecord(new HabitModel { Day = userDay, Quantity = userQuantity });
                    Console.WriteLine("\nRecord inserted successfully");
                    break;
                case MainMenuOptions.Update:
                    Console.WriteLine("\nUpdating...");
                    ShowRecords();
                    userId = ShowMenu<int>(new IdMenu());
                    userDay = ShowMenu<int>(new DayMenu());
                    userQuantity = ShowMenu<int>(new QuantityMenu());
                    HabitController.UpdateRecord(new HabitModel { Id = userId, Day = userDay, Quantity = userQuantity });
                    Console.WriteLine("\nRecord updated successfully");
                    break;
                case MainMenuOptions.Delete:
                    Console.WriteLine("\nDeleting...");
                    ShowRecords();
                    userId = ShowMenu<int>(new IdMenu());
                    HabitController.DeleteRecord(new HabitModel { Id = userId });
                    Console.WriteLine("\nRecord deleted successfully");
                    break;
                case MainMenuOptions.Show:
                    ShowRecords();
                    break;
                default:
                    Console.WriteLine("Invalid option selected. Please try again.");
                    break;
            }
        }
    }
}
