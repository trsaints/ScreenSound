using System.Text.Json;
using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;
using ScreenSound.Services;


namespace ScreenSound.Repositories;


public abstract class Repository<T> : IRepository<T> where T : Entity
{
	protected readonly StorageService<T> StorageService = new();
	protected          List<T>?          Dataset;

	protected Repository()
	{
		if (Dataset is not null)
			return;

		Task.Run(async () =>
		    {
			    try
			    {
				    using var savedData = StorageService.LoadAsync();

				    Dataset = await savedData;
			    }
			    catch (Exception e) when (e is JsonException
			                                   or AggregateException
			                                   or IOException)
			    {
				    Dataset = new List<T>();
			    }
		    })
		    .Wait();
	}

	public virtual async Task<bool> Add(T entity)
	{
		if (Exists(entity)) return false;

		Dataset.Add(entity);

		await StorageService.SaveAsync(Dataset);

		return true;
	}

	public List<T> GetAll()
	{
		return Dataset;
	}

	public T? GetById(ulong id)
	{
		return Dataset.FirstOrDefault(t => t.Id == id);
	}

	public T GetByName(string? name)
	{
		return Dataset.FirstOrDefault(t =>
		{
			var nameProperty = t.GetType().GetProperty("Nome");

			var nameValue = nameProperty.GetValue(t).ToString();

			return nameValue is not null && nameValue == name;
		});
	}

	public async Task<bool> Update(T entity)
	{
		var previousModel = GetById(entity.Id);

		if (previousModel is null) return await Add(entity);

		var removeSuccessful = await Delete(entity.Id);

		if (!removeSuccessful) return false;

		await Add(entity);
		await StorageService.SaveAsync(Dataset);

		return true;
	}

	public async Task<bool> Delete(ulong id)
	{
		var modelo = GetById(id);

		if (modelo is null)
			return false;

		Dataset.Remove(modelo);

		await StorageService.SaveAsync(Dataset);

		return true;
	}

	public virtual bool Exists(T entity)
	{
		return Dataset.Contains(entity);
	}
}
