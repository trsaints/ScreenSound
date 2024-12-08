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

		_menu = new MenuView(_title, $"Welcome to ${_title} Context. ",
		                     menuOptions);
		_menu.BuildLayout();
		InitMenuActions();
	}

	protected readonly IRepository<T> Repository;
	private readonly   MenuView _menu;
	private readonly   string _title = $"{typeof(T).Name}";
	private readonly   Dictionary<uint, Func<Task>> _menuActions = new();

	private void InitMenuActions()
	{
		_menuActions.Add(1, async () => await Register());
		_menuActions.Add(2, async () =>
		{
			ViewAll();
			await Task.CompletedTask;
		});
		_menuActions.Add(3, async () =>
		{
			ViewDetails();
			await Task.CompletedTask;
		});
		_menuActions.Add(4, async () => await Remove());
		_menuActions.Add(5, async () => await AddReview());
		_menuActions.Add(6, async () => await Update());
	}

	public Task Init()
	{
		return Task.Run(async () =>
		{
			_menu.ReadEntry();

			if (_menu.ChosenOption == -1)
				return Task.CompletedTask;

			await _menuActions[(uint)_menu.ChosenOption]();
			return Task.CompletedTask;
		});
	}

	public abstract Task Register();
	public abstract void ViewAll();
	public abstract void ViewDetails();
	public abstract Task Remove();
	public abstract Task AddReview();
	public abstract Task Update();
}
