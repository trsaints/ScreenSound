using ScreenSound.Views.Interfaces;


namespace ScreenSound.Views;


public class MenuView : View, IMenuView
{
	private readonly string   _header;
	private readonly string[] _options;

	public int ChosenOption { get; private set; }

	public MenuView(string title, string header, string[] options) : base(title)
	{
		_header  = header;
		_options = options;
	}

	public override void BuildLayout()
	{
		Layout.Append(_header);
		Layout.AppendLine("Select one of the options below.");
		Layout.AppendLine();

		for (var i = 0; i < _options.Length; i++)
			Layout.AppendLine($"[{i + 1}] {_options[i]}");

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
