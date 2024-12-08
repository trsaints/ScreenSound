using ScreenSound.Views;


namespace ScreenSound.Contexts.Interfaces;


public interface IContext
{
	public void Run();
}

public interface IContext<T> : IContext
{
	public Task Register();

	public void ViewAll();

	public void ViewDetails();

	public Task Remove();

	public Task AddReview();

	public Task Update();
}
