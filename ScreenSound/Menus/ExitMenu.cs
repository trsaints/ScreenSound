using ScreenSound.Models;


namespace ScreenSound.Menus;


internal class ExitMenu : Menu
{
	public override void Execute(Dictionary<string, Artist> registeredArtists)
	{
		Console.WriteLine("See you, space cowboy...");
	}
}
