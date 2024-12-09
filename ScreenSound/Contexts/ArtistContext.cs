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
			confirmation.ReadInput("Error", "No artists were found in the database. Press [Enter] to continue.");

			return;
		}
		
		PageView artistPages = new("Artists", artists);
		artistPages.BuildLayout();
		artistPages.Display();
	}

	public override void ViewDetails()
	{
		throw new NotImplementedException();
	}

	public override Task Remove()
	{
		throw new NotImplementedException();
	}

	public override Task AddReview()
	{
		throw new NotImplementedException();
	}

	public override Task Update()
	{
		throw new NotImplementedException();
	}
}
