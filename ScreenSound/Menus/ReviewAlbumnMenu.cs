using ScreenSound.Models;


namespace ScreenSound.Menus;


internal class ReviewAlbumnMenu : Menu
{
	public override void Execute(Dictionary<string, Artist> registeredArtists)
	{
		base.Execute(registeredArtists);

		DisplayOptionTitle("Review Album");
		Console.Write("Write in Artist's name: ");

		var artistName = Console.ReadLine()!;

		if (registeredArtists.ContainsKey(artistName))
		{
			var artist = registeredArtists[artistName];

			Console.Write("Write in Album's title: ");
			var albumTitle = Console.ReadLine()!;

			if (artist.Albums.Any(a => a.Name.Equals(albumTitle)))
			{
				var album = artist.Albums
				                  .First(a => a.Name.Equals(albumTitle));

				Console.Write(
					$"How much, out of 10, \"{albumTitle}\" deserves?");

				var review = Review.Parse(Console.ReadLine()!);

				album.AddReview(review);
				Console.WriteLine(
					$"\n{review.Score} score was added to \"{artistName}\"'s reviews!");
				Thread.Sleep(2000);
			}
			else
			{
				Console.WriteLine(
					$"\nCouldn't find \"{albumTitle}\" on \"{artistName}\"'s albums!");
				Console.WriteLine("Press any key to return.");
				Console.ReadKey();
			}
		}
		else
		{
			Console.WriteLine(
				$"\nCouldn't find \"{artistName}\" in the database.");
			Console.WriteLine("Press any key to return.");
			Console.ReadKey();
		}

		Console.Clear();
	}
}
