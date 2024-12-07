using ScreenSound.Models;


namespace ScreenSound.Menus;


internal class DisplayDetailsMenu : Menu
{
	public override void Execute(Dictionary<string, Artist> registeredArtists)
	{
		base.Execute(registeredArtists);
		DisplayOptionTitle("Display Artist Details");
		Console.Write("Write in Artist's name: ");
		var artistName = Console.ReadLine()!;

		if (registeredArtists.ContainsKey(artistName))
		{
			var artist = registeredArtists[artistName];

			Console.WriteLine(
				$"\nArtist \"{artistName}\"'s score is {artist.AverageScore}.");
			Console.WriteLine("\nDiscography:");

			foreach (var album in artist.Albums)
			{
				Console.WriteLine($"{album.Name} \t->\t {album.AverageScore}");
			}
		}
		else
		{
			Console.WriteLine(
				$"\nCouldn't find \"{artistName}\" in the database.");
		}

		Console.WriteLine(
			"\nPress any key to return.");
		Console.ReadKey();
		Console.Clear();
	}
}
