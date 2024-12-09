using ScreenSound.Views.Interfaces;


namespace ScreenSound.Views;


public sealed class InputView : View, IInputView
{
	public readonly Dictionary<string, string> UserEntries = new();

	private string? _messagePrompt;

	public InputView(string title) : base(title)
	{
	}

	public void ReadInput(string key, string? messagePrompt = null)
	{
		if (messagePrompt is not null)
		{
			Layout.Clear();
			_messagePrompt = messagePrompt;
			BuildLayout();
		}

		Console.Clear();
		Display();

		var userInput = Console.ReadLine();

		if (userInput is null) return;

		UserEntries.Add(key, userInput);
	}

	public string GetEntry(string key)
	{
		_ = UserEntries.TryGetValue(key, out var entry);

		return entry ?? "";
	}

	public override string BuildLayout()
	{
		Layout.AppendLine(Title);
		Layout.AppendLine();
		Layout.Append(_messagePrompt);
		
		return Layout.ToString();
	}
}
