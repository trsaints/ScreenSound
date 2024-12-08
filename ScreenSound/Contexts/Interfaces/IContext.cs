using ScreenSound.Views;


namespace ScreenSound.Contexts.Interfaces;


public interface IContext
{
	public void Run();
}

public interface IContext<T> : IContext
{
	public void Register();

	public void ViewAll();

	public void ViewDetails();

	public void Remove();

	public void AddReview();

	public void Update();
}
