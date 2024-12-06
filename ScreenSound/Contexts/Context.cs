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

		_menu = new MenuView(Title, $"Welcome to {typeof(T).Name}'s context. ",
		                     menuOptions);
		_menu.BuildLayout();
		InitContextOptions();
	}

	protected readonly IRepository<T>           Repository;
	private readonly   MenuView                 _menu;
	private const      string                   Title = $"{nameof(T)} Context";
	private readonly   Dictionary<uint, Action> _menuActions = new();

	private void InitContextOptions()
	{
		_menuActions.Add(1, Register);
		_menuActions.Add(2, ViewAll);
		_menuActions.Add(3, ViewDetails);
		_menuActions.Add(4, Remove);
		_menuActions.Add(5, AddReview);
		_menuActions.Add(6, Update);
	}

	public void Run()
	{
		_menu.ReadEntry();

		if (_menu.ChosenOption == -1)
			return;

		_menuActions[(uint)_menu.ChosenOption].Invoke();
	}


	public void Register()
	{
	}

	public void ViewAll()
	{
		throw new NotImplementedException();
	}

	public void ViewDetails()
	{
		throw new NotImplementedException();
	}

	public void Remove()
	{
		throw new NotImplementedException();
	}

	public void AddReview()
	{
		throw new NotImplementedException();
	}

	public void Update()
	{
		throw new NotImplementedException();
	}
}
