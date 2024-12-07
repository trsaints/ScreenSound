using System.Text;


namespace ScreenSound.Models;


public class Artist : IReviewable
{
	private readonly List<Review> _reviews = new();

	public Artist(string name)
	{
		Name = name;
	}

	public string Name { get; }

	public double AverageScore
	{
		get
		{
			if (_reviews.Count == 0) return 0;

			return _reviews.Average(a => a.Score);
		}
	}

	public List<Album> Albums { get; } = new();

	public void AddAlbum(Album album)
	{
		Albums.Add(album);
	}

	public void AddReview(Review review)
	{
		_reviews.Add(review);
	}

	public void DisplayDiscography()
	{
		Console.WriteLine($"{Name}'s Discography");

		StringBuilder discography = new();

		foreach (var album in Albums)
		{
			discography.AppendLine(
				$"Album: {album.Name} \t-\t({album.AlbumDuration})");
		}

		Console.WriteLine(discography.ToString());
	}
}
