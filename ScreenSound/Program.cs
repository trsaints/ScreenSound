using ScreenSound.Menus;
using ScreenSound.Models;

Artist ira = new("Ira!");
ira.AddReview(new Review(10));
ira.AddReview(new Review(8));
ira.AddReview(new Review(6));
Artist beatles = new("The Beatles");

Dictionary<string, Artist> registeredArtists = new();
registeredArtists.Add(ira.Name, ira);
registeredArtists.Add(beatles.Name, beatles);

Dictionary<int, Menu> mainOptions = new();
mainOptions.Add(1, new RegisterArtistMenu());
mainOptions.Add(2, new RegisterAlbumMenu());
mainOptions.Add(3, new DisplayArtistsMenu());
mainOptions.Add(4, new ReviewArtistMenu());
mainOptions.Add(5, new ReviewAlbumnMenu());
mainOptions.Add(6, new DisplayDetailsMenu());
mainOptions.Add(-1, new ExitMenu());

void DisplayLogo()
{
	Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
	Console.WriteLine("Welcome to Screen Sound 2.0!");
}

void DisplayOptions()
{
	while (true)
	{
		DisplayLogo();
		Console.WriteLine("\n[1] Register an Artist");
		Console.WriteLine("[2] Register an Album");
		Console.WriteLine("[3] Display all artists");
		Console.WriteLine("[4] Review an Artist");
		Console.WriteLine("[5] Review an Album");
		Console.WriteLine("[6] View Artist details");
		Console.WriteLine("[-1] Exit");

		Console.Write("\nYour option (digits only): ");

		var chosenOption = Console.ReadLine()!;
		var parsedOption = int.Parse(chosenOption);

		if (mainOptions.ContainsKey(parsedOption))
		{
			var chosenMenu = mainOptions[parsedOption];
			chosenMenu.Execute(registeredArtists);

			if (parsedOption > 0) continue;
		}

		if (parsedOption != -1) Console.WriteLine("Invalid Option. Exiting...");

		break;
	}
}

DisplayOptions();
