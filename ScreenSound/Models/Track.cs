using ScreenSound.Views;


namespace ScreenSound.Models;


public class Track : Entity
{
	private readonly List<Review> _reviews = new();
	public           ulong        AlbumId   { get; init; }
	public           ulong        ArtistId  { get; init; }
	public           bool         Available { get; init; }
	public           uint         Duration  { get; init; }

	public string? Name { get; init; }

	public Track() { }

	public Track(ulong artistId,
	             ulong albumId,
	             string? name,
	             uint duration,
	             bool available)
	{
		ArtistId  = artistId;
		AlbumId   = albumId;
		Name      = name;
		Duration  = duration;
		Available = available;
	}

	public override double AverageScore
	{
		get
		{
			if (_reviews.Count == 0) return 0;

			return _reviews.Average(review => review.Score);
		}
	}

	public override void AddReview(Review review) { _reviews.Add(review); }
}
