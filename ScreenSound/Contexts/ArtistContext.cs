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

	public override async Task Remove()
	{
		InputView searchInput = new("Delete Artist");
		searchInput.BuildLayout();
		searchInput.ReadInput("Delete",
		                      "Enter the name of the artist to remove: ");

		var artistName  = searchInput.GetEntry("Delete");
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

		searchInput.ReadInput("Confirm",
		                      $"{details}\nAre you sure you want to delete this Artist? [Y] [N].");

		var confirm = searchInput.GetEntry("Confirm");

		if (confirm.ToLower() == "y")
		{
			var successfulTask = await Repository.Delete(foundArtist.Id);

			if (!successfulTask)
				searchInput.ReadInput("Error",
				                      "An error occurred while deleting the artist. Press [Enter] to continue.");

			searchInput.ReadInput("Success",
			                      $"Artist \"{foundArtist.Name}\" deleted successfully.\nPress [Enter] to continue.");

			return;
		}

		searchInput.ReadInput("Cancelled",
		                      "Artist deletion cancelled. Press [Enter] to continue.");
	}

	public override async Task AddReview()
	{
		InputView searchInput = new("Add Review");
		searchInput.BuildLayout();

		searchInput.ReadInput("Review",
		                      "Enter the name of the artist: ");

		var artistName  = searchInput.GetEntry("Review");
		var foundArtist = Repository.GetByName(artistName);

		if (foundArtist is null)
		{
			searchInput.ReadInput("Error",
			                      $"Couldn't find \"{artistName}\". Press [Enter] to continue.");

			return;
		}

		searchInput.ReadInput("Score",
		                      $"What's your score to \"{foundArtist.Name}\"? [0-10]");

		var parsedScore
			= int.TryParse(searchInput.GetEntry("Score"), out var score);

		if (!parsedScore)
		{
			searchInput.ReadInput("Error",
			                      "Invalid score. Press [Enter] to continue.");

			return;
		}

		if (score < 0 || score > 10)
		{
			searchInput.ReadInput("Error",
			                      "Score must be between 0 and 10. Press [Enter] to continue.");

			return;
		}

		foundArtist.AddReview(new Review(score));

		var successfulTask = await Repository.Update(foundArtist);

		if (!successfulTask)
			searchInput.ReadInput("Error",
			                      "An error occurred while adding the review. Press [Enter] to continue.");

		searchInput.ReadInput("Success",
		                      "Review added successfully. Press [Enter] to continue.");
	}

	public override Task Update() { throw new NotImplementedException(); }
}
