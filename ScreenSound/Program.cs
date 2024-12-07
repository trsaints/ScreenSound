using ScreenSound.Contexts.Interfaces;
using ScreenSound.Models;
using ScreenSound.Views;

Dictionary<int, IContext<IReviewable>> mainOptions       = new();

Init();

return;

void Init()
{
	while (true)
	{
		string[] options =
		{
			"Register an Artist", "Register an Album", "Display all artists",
			"Review an Artist", "Review an Album", "View Artist details", "Exit"
		};

		MenuView mainMenu = new("Main Menu",
		                        "Welcome to ScreenSound! What would you like to do? ",
		                        options);

		mainMenu.BuildLayout();
		mainMenu.ReadEntry();

		if (mainOptions.ContainsKey(mainMenu.ChosenOption))
		{
			var chosenContext = mainOptions[mainMenu.ChosenOption];
			chosenContext.Run();

			if (mainMenu.ChosenOption > 0) continue;
		}

		break;
	}
}
