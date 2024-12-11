using System.Text;
using System.Text.Json.Serialization;
using ScreenSound.Repositories;


namespace ScreenSound.Models;


public class Album : Entity
{
	public Album(string name) : base(name) { }

	[JsonConstructor]
	public Album(string name, ulong artistId) : base(name)
	{
		ArtistId = artistId;
	}

	private readonly List<Review> _scores = new();

	public ulong ArtistId { get; init; }

	public override double AverageScore
	{
		get
		{
			if (_scores.Count == 0) return 0;

			return _scores.Average(review => review.Score);
		}
	}

	public override void AddReview(Review review) { _scores.Add(review); }

	public long GetAlbumDuration(TrackRepository tracks)
	{
		var albumTracks = tracks.GetAll().Where(t => t.AlbumId == Id);
		var duration    = albumTracks.Sum(t => t.Duration);

		return duration;
	}
}
