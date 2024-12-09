using System.Text.Json;
using ScreenSound.Models;
using ScreenSound.Services.Interfaces;
using ScreenSound.Utils;


namespace ScreenSound.Services;


public sealed class StorageService<T> : IStorageService<T> where T : IReviewable
{
	public readonly string DataFilePath
		= Path.Combine(FileUtils.StorageDirectory, $"{typeof(T).Name}s.json");

	public StorageService()
	{
		if (File.Exists(DataFilePath)) return;

		File.Create(DataFilePath).Dispose();
	}

	public async Task SaveAsync(List<T>? items)
	{
		await using var fileStream = File.OpenWrite(DataFilePath);

		await JsonSerializer.SerializeAsync(fileStream, items);
	}

	public async Task<List<T>?> LoadAsync()
	{
		await using var fileStream = File.OpenRead(DataFilePath);

		List<T>? items;

		try
		{
			items = await JsonSerializer.DeserializeAsync<List<T>>(fileStream);
		}
		catch (Exception e) when (e is ArgumentNullException or JsonException
			                          or NotSupportedException)
		{
			return new List<T>();
		}

		return items;
	}
}
