namespace ScreenSound.Views.Interfaces;


public interface IView
{
	public void Display();

	public string BuildLayout();

	public string GenerateHeader(string title);

	public string GenerateLineSeparator();
}
