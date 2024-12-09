namespace ScreenSound.Services.Interfaces;


public interface IStorageService<T>
{
	public Task SaveAsync(List<T>? items);

	public Task<List<T>?> LoadAsync();
}
