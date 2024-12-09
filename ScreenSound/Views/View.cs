using System.Text;
using ScreenSound.Views.Interfaces;


namespace ScreenSound.Views;


public abstract class View : IView
{
	protected const string Logo = @"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
";

	protected readonly StringBuilder Layout = new();

	protected readonly string Title;

	protected View(string title) { Title = title; }

	public virtual void Display()
	{
		Console.Clear();
		Console.Write(Layout.ToString());
	}

	public virtual string BuildLayout()
	{
		Layout.AppendLine(Title);

		return Layout.ToString();
	}

	public string GenerateHeader(string title)
	{
		StringBuilder header = new();

		var windowWidth = Console.WindowWidth;
		var headerLines = GenerateLineSeparator();

		header.AppendLine(headerLines);
		header.AppendLine(title.PadLeft((windowWidth + title.Length) / 2)
		                       .PadRight(windowWidth));
		header.AppendLine(headerLines);

		return header.ToString();
	}


	public string GenerateLineSeparator()
	{
		StringBuilder separator = new();

		for (var i = 0; i < Console.WindowWidth; i++)
		{
			separator.Append('\u25a9');
		}

		return separator.ToString();
	}
}
