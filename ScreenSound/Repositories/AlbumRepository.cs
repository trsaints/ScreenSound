using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;


namespace ScreenSound.Repositories;


public class AlbumRepository : Repository<Album>, IAlbumRepository
{
	public List<Album> GetByArtist(ulong artistId)
	{
		return Dataset?.Where(album => album.ArtistId == artistId).ToList() ?? new List<Album>();
	}
}
