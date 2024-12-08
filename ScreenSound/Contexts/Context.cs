using ScreenSound.Contexts.Interfaces;
using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;
using ScreenSound.Views;


namespace ScreenSound.Contexts;


public abstract class Context<T> : IContext<T> where T : Entity
{
	protected Context(IRepository<T> repository)
	{
		Repository = repository;

		var menuOptions = GetType().GetMethods().Select(m => m.Name);
		Menu = new MenuView(Title, "Welcome", menuOptions);
	}

	protected readonly IRepository<T> Repository;
	public readonly    MenuView       Menu;
	private const      string         Title = $"{nameof(T)} Context";

	public void Run()
	{
		throw new NotImplementedException();
	}

	public void Register(T data)
	{
		throw new NotImplementedException();
	}

	public void ViewAll()
	{
		throw new NotImplementedException();
	}

	public void ViewDetails(int id)
	{
		throw new NotImplementedException();
	}

	public void Remove(int id)
	{
		throw new NotImplementedException();
	}

	public void Review(int id)
	{
		throw new NotImplementedException();
	}

	public void Update(int id, T newData)
	{
		throw new NotImplementedException();
	}
}