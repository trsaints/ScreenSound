using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;
using ScreenSound.Views;


namespace ScreenSound.Contexts;


public class ArtistContext : Context<Artist>
{
	public ArtistContext(IRepository<Artist> repository) :
		base(repository)
	{
	}

	public override async Task Register()
	{
		InputView userInput = new("Register Artist");
		userInput.BuildLayout();

		userInput.ReadInput("Name", "Enter the name of the artist: ");

		Artist newArtist = new(userInput.GetEntry("Name"));

		var successfulTask = await Repository.Add(newArtist);

		if (!successfulTask)
			userInput.ReadInput("Error",
			                    "An error occurred while registering the artist. Press [Enter] to continue.");

		userInput.ReadInput("Success",
		                    $"Artist \"{newArtist.Name}\" registered successfully.\nPress [Enter] to continue.");
	}

	public override void ViewAll()
	{
		var artists = Repository.GetAll();

		if (artists.Count is 0)
		{
			InputView confirmation = new("No Artists Found");
			confirmation.BuildLayout();
			confirmation.ReadInput("Error",
			                       "No artists were found in the database. Press [Enter] to continue.");

			return;
		}

		PageView artistPages = new("Artists", artists);
		artistPages.BuildLayout();
		artistPages.Display();
	}

	public override void ViewDetails()
	{
		InputView searchInput = new("Search Artist");
		searchInput.BuildLayout();
		searchInput.ReadInput("Search",
		                      "Enter the name of the artist to search for: ");

		var artistName  = searchInput.GetEntry("Search");
		var foundArtist = Repository.GetByName(artistName);

		if (foundArtist is null)
		{
			searchInput.ReadInput("Error",
			                      $"Couldn't find \"{artistName}\". Press [Enter] to continue.");
			return;
		}

		var artistProperties = foundArtist.GetType()
		                                  .GetProperties()
		                                  .ToDictionary(
			                                  p => p.Name,
			                                  p => p.GetValue(foundArtist)
			                                        .ToString() ?? "N/A");

		DetailsView artistDetails = new("Artist Details", artistProperties);
		var         details       = artistDetails.BuildLayout();

		searchInput.ReadInput("Success",
		                      $"{details}\nPress [Enter] to continue.");
	}

	public override Task Remove() { throw new NotImplementedException(); }

	public override Task AddReview() { throw new NotImplementedException(); }

	public override Task Update() { throw new NotImplementedException(); }
}
