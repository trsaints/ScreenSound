using ScreenSound.Models;


namespace ScreenSound.Repositories.Interfaces;


public interface IAlbumRepository
{
	public List<Album> GetByArtist(ulong artistId);
}
