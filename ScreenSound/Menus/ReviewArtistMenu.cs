using ScreenSound.Models;


namespace ScreenSound.Menus;


internal class ReviewArtistMenu : Menu
{
	public override void Execute(Dictionary<string, Artist> registeredArtists)
	{
		base.Execute(registeredArtists);

		DisplayOptionTitle("Review Artist");
		Console.Write("Write in Artist's name: ");

		var artistName = Console.ReadLine()!;

		if (registeredArtists.ContainsKey(artistName))
		{
			var artist = registeredArtists[artistName];
			Console.Write($"How much, out of 10, \"{artistName}\" deserves?");

			var review = Review.Parse(Console.ReadLine()!);
			artist.AddReview(review);

			Console.WriteLine(
				$"\n{review.Score} score was added to \"{artistName}\"'s reviews!");
			Thread.Sleep(2000);
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
