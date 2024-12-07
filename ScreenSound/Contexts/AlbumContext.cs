using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;


namespace ScreenSound.Contexts;


public class AlbumContext : Context<Album>
{
	public AlbumContext(IRepository<Album> repository) : base(repository)
	{
	}
}
