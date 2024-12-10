using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;
using ScreenSound.Views;


namespace ScreenSound.Contexts;


public class AlbumContext : Context<Album>
{
	public AlbumContext(IRepository<Album> repository, IRepository<Artist> artists) : base(repository)
	{
		_artists = artists;
	}

	private readonly IRepository<Artist> _artists;

	public override async Task Register()
	{
		InputView userInput = new("Register Album");
		userInput.BuildLayout();
		userInput.ReadInput("Name", "Album Name: ");
		userInput.ReadInput("Artist", "Artist Name: ");

		var albumArtist = _artists.GetByName(userInput.GetEntry("Artist"));

		if (albumArtist is null)
		{
			userInput.ReadInput("Error",
			                    "Artist not found. Please register the artist first.");

			return;
		}

		Album newAlbum = new()
		{
			Name     = userInput.GetEntry("Name"),
			ArtistId = albumArtist.Id
		};

		var successfulTask = await Repository.Add(newAlbum);
		
		if (successfulTask)
		{
			userInput.ReadInput("Success",
			                    "Album registered successfully. Press [Enter] to continue");
			return;
		}

		userInput.ReadInput("Error",
		                    "Album registration failed. Press [Enter] to continue");
	}

	public override void ViewAll() { throw new NotImplementedException(); }

	public override void ViewDetails() { throw new NotImplementedException(); }

	public override Task Remove() { throw new NotImplementedException(); }

	public override Task AddReview() { throw new NotImplementedException(); }

	public override Task Update() { throw new NotImplementedException(); }
}
