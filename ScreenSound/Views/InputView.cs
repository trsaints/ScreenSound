using System.Text;
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

    var            userInput = new StringBuilder();
    ConsoleKeyInfo keyInfo;

    while (true)
    {
        keyInfo = Console.ReadKey(intercept: true);

        if (keyInfo.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();
            break;
        }
        
        if (keyInfo.Key == ConsoleKey.Backspace)
        {
	        if (userInput.Length <= 0) continue;

	        userInput.Remove(userInput.Length - 1, 1);
	        Console.Write("\b \b");
        }
        else
        {
            userInput.Append(keyInfo.KeyChar);
            Console.Write(keyInfo.KeyChar);
        }
    }

    UserEntries.Add(key, userInput.ToString());
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
