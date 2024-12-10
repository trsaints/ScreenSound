using ScreenSound.Contexts.Interfaces;
using ScreenSound.Models;
using ScreenSound.Repositories.Interfaces;
using ScreenSound.Views;


namespace ScreenSound.Contexts;


public abstract class Context<T> : IContext<T> where T : Entity
{
	private readonly MenuView                     _menu;
	protected readonly Dictionary<uint, Func<Task>> MenuActions = new();
	private readonly string                       _title = $"{typeof(T).Name}";

	protected readonly IRepository<T> Repository;

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

	public Task Init()
	{
		return Task.Run(async () =>
		{
			_menu.ReadEntry();

			if (_menu.ChosenOption == -1)
				return Task.CompletedTask;

			await MenuActions[(uint)_menu.ChosenOption]();
			return Task.CompletedTask;
		});
	}

	public abstract Task Register();
	public abstract void ViewAll();
	public abstract void ViewDetails();
	public abstract Task Remove();
	public abstract Task AddReview();
	public abstract Task Update();

	protected virtual void InitMenuActions()
	{
		MenuActions.Add(1, async () => await Register());
		MenuActions.Add(2, async () =>
		{
			ViewAll();
			await Task.CompletedTask;
		});
		MenuActions.Add(3, async () =>
		{
			ViewDetails();
			await Task.CompletedTask;
		});
		MenuActions.Add(4, async () => await Remove());
		MenuActions.Add(5, async () => await AddReview());
		MenuActions.Add(6, async () => await Update());
	}
}
