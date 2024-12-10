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

Context<Artist> artistContext
	= new ArtistContext(artistRepository, albumRepository, trackRepository);
Context<Album> albumContext = new AlbumContext(albumRepository, artistRepository);
Context<Track> trackContext
	= new TrackContext(trackRepository, artistRepository, albumRepository);

Dictionary<int, IContext> contexts = new()
{
	{ 1, artistContext },
	{ 2, albumContext },
	{ 3, trackContext }
};

await Init();

return;

async Task Init()
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
			await chosenContext.Init();

			if (mainMenu.ChosenOption != 4) continue;
		}

		break;
	}
}
