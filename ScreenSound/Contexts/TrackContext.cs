using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;
using ScreenSound.Views;


namespace ScreenSound.Contexts;


public class TrackContext : Context<Track>
{
	public TrackContext(IRepository<Track> repository,
	                    IRepository<Artist> artists,
	                    IRepository<Album> albums) : base(repository)
	{
		_artists = artists;
		_albums  = albums;
	}

	private readonly IRepository<Artist> _artists;
	private readonly IRepository<Album>  _albums;

	public override async Task Register()
	{
		InputView userInput = new("Register Track");
		userInput.BuildLayout();

		userInput.ReadInput("Name", "Track name: ");
		userInput.ReadInput("Artist", "Artist name: ");
		userInput.ReadInput("Album", "Album name: ");
		userInput.ReadInput("Duration", "Duration (seconds): ");
		userInput.ReadInput("Available", "Available (true/false): ");

		var trackArtist = _artists.GetByName(userInput.GetEntry("Artist"));
		var trackAlbum  = _albums.GetByName(userInput.GetEntry("Album"));

		if (trackArtist == null)
		{
			userInput.ReadInput("Error",
			                    "Artist not found. Press [Enter] to return.");

			return;
		}

		if (trackAlbum == null)
		{
			userInput.ReadInput("Error",
			                    "Album not found. Press [Enter] to return.");

			return;
		}


		Track newTrack = new(userInput.GetEntry("Name"))
		{
			ArtistId  = trackArtist.Id,
			AlbumId   = trackAlbum.Id,
			Duration  = uint.Parse(userInput.GetEntry("Duration")),
			Available = bool.Parse(userInput.GetEntry("Available"))
		};

		var success = await Repository.Add(newTrack);

		if (success)
		{
			userInput.ReadInput("Success",
			                    "Track registered successfully. Press [Enter] to return.");

			return;
		}

		userInput.ReadInput("Error",
		                    "Track could not be registered. Press [Enter] to return.");
	}

	public override void ViewAll() { throw new NotImplementedException(); }

	public override void ViewDetails() { throw new NotImplementedException(); }

	public override Task Remove() { throw new NotImplementedException(); }

	public override Task AddReview() { throw new NotImplementedException(); }

	public override Task Update() { throw new NotImplementedException(); }
}
