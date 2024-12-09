namespace ScreenSound.Views.Interfaces;


public interface IInputView
{
	public void ReadInput(string key, string? messagePrompt);

	public string GetEntry(string key);
}
