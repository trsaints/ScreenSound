using System.Text;
using ScreenSound.Repositories;


namespace ScreenSound.Models;


public class Album : Entity
{
	private readonly List<Review> _scores = new();

	public ulong   ArtistId { get; init; }
	public  string? Name     { get; init; }

	public Album() { }

	public Album(string? name, ulong artistId)
	{
		ArtistId = artistId;
		Name     = name;
	}

	public override double AverageScore
	{
		get
		{
			if (_scores.Count == 0) return 0;

			return _scores.Average(review => review.Score);
		}
	}

	public List<ulong> TracksIds { get; } = new();

	public override void AddReview(Review review) { _scores.Add(review); }

	public uint GetAlbumDuration(TrackRepository repository)
	{
		uint duration = 0;

		foreach (var track in TracksIds)
		{
			var trackData = repository.GetById(track);

			if (trackData is null) continue;

			duration += trackData.Duration;
		}

		return duration;
	}
}
