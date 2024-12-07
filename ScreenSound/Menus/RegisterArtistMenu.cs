using ScreenSound.Models;


namespace ScreenSound.Menus;


internal class RegisterArtistMenu : Menu
{
	public override void Execute(Dictionary<string, Artist> registeredArtists)
	{
		base.Execute(registeredArtists);
		DisplayOptionTitle("Artist Registration");

		Console.Write("Write in Artist's name: ");

		var artistName = Console.ReadLine()!;
		var artist     = new Artist(artistName);

		registeredArtists.Add(artistName, artist);
		Console.WriteLine(
			$"Artist \"{artistName}\" registration was successful!");
		Thread.Sleep(4000);
		Console.Clear();
	}
}
