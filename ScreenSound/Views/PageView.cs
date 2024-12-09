using ScreenSound.Models;
using ScreenSound.Views.Interfaces;


namespace ScreenSound.Views;


public class PageView : View, IPageView
{
	public PageView(string title, IEnumerable<Entity> contents) : base(title)
	{
		_contents.AddRange(contents);
	}

	private readonly List<Entity> _contents = new();
	private          uint         CurrentPage    { get; set; }
	private          string?      CurrentContent { get; set; }

	public override void Display()
	{
		base.Display();
		
		var userDirection = Console.ReadKey();
		
		while (true)
		{
			if (userDirection.Key == ConsoleKey.Escape) break;

			ChangePage(userDirection.Key);
			BuildLayout();
			
			base.Display();

			userDirection = Console.ReadKey();
		}
	}

	public override string BuildLayout()
	{
		var currentObject = _contents[(int)CurrentPage];
		var currentProperties = currentObject.GetType()
		                                     .GetProperties()
		                                     .ToDictionary(
			                                     p => p.Name,
			                                     p => p.GetValue(currentObject)!
				                                     .ToString() ?? "");

		DetailsView objectDetails
			= new("Details: " + currentObject.GetType().Name,
			      currentProperties);

		CurrentContent = objectDetails.BuildLayout();
		
		Layout.Clear();
		Layout.AppendLine(GenerateHeader("View All Artists"));
		Layout.AppendLine(CurrentContent);
		Layout.AppendLine();
		Layout.AppendLine(GenerateLineSeparator('-'));
		Layout.AppendLine($"Page: {CurrentPage + 1}/{_contents.Count}");
		Layout.AppendLine("[Left/Right] to navigate \t\t\t [Esc] to exit");

		return Layout.ToString();
	}

	public void ChangePage(ConsoleKey direction)
	{
		CurrentPage = direction switch
		{
			ConsoleKey.LeftArrow => CurrentPage == 0
				? (uint)_contents.Count - 1
				: CurrentPage - 1,
			ConsoleKey.RightArrow => CurrentPage == _contents.Count - 1
				? 0
				: CurrentPage + 1,
			_ => CurrentPage
		};
	}
}
