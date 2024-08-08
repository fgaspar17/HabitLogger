using HabitLogger;
using HabitLogger.Menus;
using HabitLoggerLibrary;

SetupDatabase setupDatabase = new SetupDatabase();
setupDatabase.InitializeDatabase();

bool continueRunning = true;

UserInterface userInterface = new UserInterface();
MainMenu mainMenu = new MainMenu();

while (continueRunning)
{
	MainMenuOptions mainMenuOptionPicked = userInterface.ShowMenu<MainMenuOptions>([ mainMenu ])[0];

    HandleMenuOption(mainMenuOptionPicked, ref continueRunning, userInterface);

}

static void HandleMenuOption(MainMenuOptions option, ref bool continueRunning, UserInterface userInterface)
{
    List<int> userNewData = new List<int>();

    switch (option)
    {
        case MainMenuOptions.Quit:
            continueRunning = false;
            break;
        case MainMenuOptions.Create:
            Console.WriteLine("\nInserting...");
            userNewData = userInterface.ShowMenu<int>(new IMenu[] { new DayMenu(), new QuantityMenu() });
            HabitController.InsertRecord(new HabitModel { Day = userNewData[0], Quantity = userNewData[1] });
            break;
        case MainMenuOptions.Update:
            Console.WriteLine("\nUpdating...");
            userInterface.ShowRecords();
            userNewData = userInterface.ShowMenu<int>(new IMenu[] { new IdMenu(), new DayMenu(), new QuantityMenu() });
            HabitController.UpdateRecord(new HabitModel { Id = userNewData[0], Day = userNewData[1], Quantity = userNewData[2] });
            break;
        case MainMenuOptions.Delete:
            Console.WriteLine("\nDeleting...");
            userInterface.ShowRecords();
            userNewData = userInterface.ShowMenu<int>(new IMenu[] { new IdMenu() });
            HabitController.DeleteRecord(new HabitModel { Id = userNewData[0] });
            break;
        case MainMenuOptions.Show:
            userInterface.ShowRecords();
            break;
        default:
            Console.WriteLine("Invalid option selected. Please try again.");
            break;
    }
}