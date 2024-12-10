using ScreenSound.Views;


namespace ScreenSound.Models;


public class Track : Entity
{
	public Track(string name): base(name) { }

	public Track(ulong artistId,
	             ulong albumId,
	             string name,
	             uint duration,
	             bool available): base(name)
	{
		ArtistId  = artistId;
		AlbumId   = albumId;
		Duration  = duration;
		Available = available;
	}

	private readonly List<Review> _reviews = new();
	public           ulong        AlbumId   { get; init; }
	public           ulong        ArtistId  { get; init; }
	public           bool         Available { get; init; }
	public           uint         Duration  { get; init; }

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
