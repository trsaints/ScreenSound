using ScreenSound.Contexts;
using ScreenSound.Contexts.Interfaces;
using ScreenSound.Models;
using ScreenSound.Repositories;
using ScreenSound.Utils;
using ScreenSound.Views;


FileUtils.CreateAppDirectories();

ArtistRepository artistRepository = new();
AlbumRepository  albumRepository  = new();
TrackRepository  trackRepository  = new();

Context<Artist> artistContext = new ArtistContext(artistRepository);
Context<Album>  albumContext  = new AlbumContext(albumRepository);
Context<Track>  trackContext  = new TrackContext(trackRepository);

Dictionary<int, IContext> contexts = new();

contexts.Add(1, artistContext);
contexts.Add(2, albumContext);
contexts.Add(3, trackContext);

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

		if (contexts.ContainsKey(mainMenu.ChosenOption))
		{
			var chosenContext = contexts[mainMenu.ChosenOption];
			chosenContext.Run();

			if (mainMenu.ChosenOption > 0) continue;
		}

		break;
	}
}
