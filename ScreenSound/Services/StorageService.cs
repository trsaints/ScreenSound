using ScreenSound.Services.Interfaces;
using System.Text.Json;
using ScreenSound.Models;
using ScreenSound.Utils;


namespace ScreenSound.Services;


public sealed class StorageService<T> : IStorageService<T> where T : IReviewable
{
	public StorageService()
	{
		if (File.Exists(_dataFilePath)) return;

		File.Create(_dataFilePath).Dispose();
	}

	private readonly string _dataFilePath
		= Path.Combine(FileUtils.StorageDirectory, $"{typeof(T).Name}s.json");

	public async Task SaveAsync(List<T>? items)
	{
		await using var fileStream = File.OpenWrite(_dataFilePath);

		await JsonSerializer.SerializeAsync(fileStream, items);
	}

	public async Task<List<T>?> LoadAsync()
	{
		await using var fileStream = File.OpenRead(_dataFilePath);

		List<T>? items;

		try
		{
			items = await JsonSerializer.DeserializeAsync<List<T>>(fileStream);
		}
		catch (Exception e) when (e is ArgumentNullException or JsonException
			                          or NotSupportedException)
		{
			Console.WriteLine(e.Message);
			return null;
		}

		return items;
	}
}
