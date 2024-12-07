using ScreenSound.Views.Interfaces;


namespace ScreenSound.Views;


public class MenuView : View, IMenuView
{
	private readonly string        _header;
	private readonly IEnumerable<string> _options;

	public int ChosenOption { get; private set; }

	public MenuView(string title, string header, IEnumerable<string> options) : base(title)
	{
		_header  = header;
		_options = options;
	}

	public override void BuildLayout()
	{
		Layout.Append(Logo);
		Layout.Append(_header);
		Layout.AppendLine("Select one of the options below.");
		Layout.AppendLine();

		for (var i = 0; i < _options.Count(); i++)
			Layout.AppendLine($"[{i + 1}] {_options.ElementAt(i)}");

		Layout.AppendLine();
		Layout.Append("Your choice (numbers only): ");
	}

	public void ReadEntry()
	{
		Display();

		var entry = Console.ReadKey();
		var validInput = int.TryParse(entry
		                              .KeyChar
		                              .ToString(),
		                              out var chosenOption);

		if (!validInput) return;

		ChosenOption = chosenOption;
	}
}
