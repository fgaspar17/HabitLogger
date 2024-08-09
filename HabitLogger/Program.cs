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
	MainMenuOptions mainMenuOptionPicked = userInterface.ShowMenu<MainMenuOptions>(mainMenu);
    userInterface.HandleMenuOption(mainMenuOptionPicked, ref continueRunning);
}

