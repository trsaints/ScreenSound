using ScreenSound.Models;


namespace ScreenSound.Menus;


internal class RegisterAlbumMenu : Menu
{
	public override void Execute(Dictionary<string, Artist> registeredArtists)
	{
		base.Execute(registeredArtists);
		DisplayOptionTitle("Album Registration");

		Console.Write("Write in Artist's name: ");

		var artistName = Console.ReadLine()!;

		if (registeredArtists.ContainsKey(artistName))
		{
			Console.Write("Now, the Album name: ");

			var albumTitle = Console.ReadLine()!;
			var artist      = registeredArtists[artistName];
			
			artist.AddAlbum(new Album(albumTitle));
			
			Console.WriteLine(
				$"{albumTitle}, by {artistName}, added successfully!");

			Thread.Sleep(4000);
		}
		else
		{
			Console.WriteLine($"\nArtist {artistName} not found!");
			Console.WriteLine("Press any key to return.");
			Console.ReadKey();
		}

		Console.Clear();
	}
}
