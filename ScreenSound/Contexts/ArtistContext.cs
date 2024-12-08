using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;


namespace ScreenSound.Contexts;


public class ArtistContext : Context<Artist>
{
	public ArtistContext(IRepository<Artist> repository) :
		base(repository)
	{
	}

	public override void Register()
	{
		throw new NotImplementedException();
	}

	public override void ViewAll()
	{
		throw new NotImplementedException();
	}

	public override void ViewDetails()
	{
		throw new NotImplementedException();
	}

	public override void Remove()
	{
		throw new NotImplementedException();
	}

	public override void AddReview()
	{
		throw new NotImplementedException();
	}

	public override void Update()
	{
		throw new NotImplementedException();
	}
}
