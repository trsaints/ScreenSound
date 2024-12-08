using ScreenSound.Views;


namespace ScreenSound.Contexts.Interfaces;


public interface IContext
{
	public void Run();
}

public interface IContext<T> : IContext
{
	public void Register(T data);

	public void ViewAll();

	public void ViewDetails(int id);

	public void Remove(int id);

	public void Review(int id);

	public void Update(int id, T newData);
}
