using System.Text;
using ScreenSound.Repositories;


namespace ScreenSound.Models;


public class Artist : Entity
{
	private readonly List<Review> _reviews = new();

	public readonly List<ulong> AlbumsIds = new();

	public Artist(string name)
	{
		Name = name;
	}

	public string Name { get; }

	public override double AverageScore
	{
		get
		{
			if (_reviews.Count == 0) return 0;

			return _reviews.Average(a => a.Score);
		}
	}

	public override void AddReview(Review review)
	{
		_reviews.Add(review);
	}

	public void DisplayDiscography(AlbumRepository albums,
	                               TrackRepository tracks)
	{
		Console.WriteLine($"{Name}'s Discography");

		StringBuilder discography = new();

		foreach (var album in AlbumsIds)
		{
			var albumData = albums.GetById(album);

			if (albumData is null) continue;

			discography.AppendLine(
				$"Album: {albumData.Name} \t-\t({albumData.GetAlbumDuration(tracks)})");
		}

		Console.WriteLine(discography.ToString());
	}
}
