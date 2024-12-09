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
	protected readonly string        Title;

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
		StringBuilder headerLines = new();
		StringBuilder header      = new();
		
		var           windowWidth = Console.WindowWidth;

		for (var i = 0; i < windowWidth; i++)
		{
			headerLines.Append('\u25a9');
		}

		header.AppendLine(headerLines.ToString());
		header.AppendLine(title.PadLeft((windowWidth + title.Length) / 2)
		                       .PadRight(windowWidth));
		header.AppendLine(headerLines.ToString());

		return header.ToString();
	}
}
