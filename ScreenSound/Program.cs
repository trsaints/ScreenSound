using ScreenSound.Contexts.Interfaces;
using ScreenSound.Models;
using ScreenSound.Views;

Dictionary<int, IContext<IReviewable>> mainOptions = new();

Init();

return;

void Init()
{
	while (true)
	{
		string[] options = { "Artists", "Albums", "Tracks", "Exit" };

		MenuView mainMenu = new("Main Menu",
		                        "Welcome to ScreenSound! What's your context? ",
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
