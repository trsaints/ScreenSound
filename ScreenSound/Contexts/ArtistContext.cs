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
		{
			Console.WriteLine("Failed to register artist.");
			Thread.Sleep(3000);
		}
		
		Console.WriteLine($"Artist \"{newArtist.Name}\" registered successfully.");
		Thread.Sleep(3000);
	}

	public override void ViewAll()
	{
		throw new NotImplementedException();
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
