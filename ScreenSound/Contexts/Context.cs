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

		var menuOptions = GetType()
		                  .GetMethods()
		                  .Select(method => method.Name)
		                  .Where(methodName => methodName != "ToString"
		                                       && methodName != "Equals"
		                                       && methodName != "GetHashCode"
		                                       && methodName != "GetType"
		                                       && methodName != "Run")
		                  .ToArray();

		Menu = new MenuView(Title, "Welcome. ", menuOptions);
		Menu.BuildLayout();
	}

	protected readonly IRepository<T> Repository;
	public readonly    MenuView       Menu;
	private const      string         Title = $"{nameof(T)} Context";

	public void Run()
	{
		Menu.ReadEntry();
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
