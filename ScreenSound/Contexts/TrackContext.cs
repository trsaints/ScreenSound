using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;


namespace ScreenSound.Contexts;


public class TrackContext : Context<Track>
{
	public TrackContext(IRepository<Track> repository) : base(repository)
	{
	}

	public override Task Register()
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
