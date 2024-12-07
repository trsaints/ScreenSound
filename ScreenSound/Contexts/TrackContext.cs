using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;


namespace ScreenSound.Contexts;


public class TrackContext : Context<Track> 
{
	public TrackContext(IRepository<Track> repository) : base(repository)
	{
	}
}
