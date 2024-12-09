namespace ScreenSound.Repositories.Interfaces;


public interface IRepository<T>
{
	public Task<bool> Add(T entity);

	public List<T> GetAll();

	public T? GetById(ulong id);

	public T? GetByName(string name);

	public Task<bool> Update(T entity);

	public Task<bool> Delete(ulong id);

	public bool Exists(T entity);
}
