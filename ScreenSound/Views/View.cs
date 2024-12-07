using System.Text;
using ScreenSound.Views.Interfaces;

public abstract class View : IView
{
	public readonly StringBuilder Layout = new();
	public readonly string        Title;

	protected View(string title)
	{
		Title = title;
	}

	public virtual void Display()
	{
		Console.Clear();
		Console.Write(Layout.ToString());
	}

	public virtual void BuildLayout()
	{
		Layout.AppendLine(Title);
	}
}
