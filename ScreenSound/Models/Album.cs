using System.Text;
using ScreenSound.Repositories;


namespace ScreenSound.Models;


public class Album : Entity
{
	public Album(string name, ulong artistId)
	{
		ArtistId = artistId;
		Name     = name;
	}

	private readonly ulong  ArtistId;
	public readonly  string Name;

	private readonly List<ulong>  _tracksIds = new();
	private readonly List<Review> _scores = new();

	public override double AverageScore
	{
		get
		{
			if (_scores.Count == 0) return 0;

			return _scores.Average(review => review.Score);
		}
	}

	public List<ulong> TracksIds => _tracksIds;

	public override void AddReview(Review review)
	{
		_scores.Add(review);
	}

	public void DisplayAlbumTracks(ArtistRepository artists,  TrackRepository tracks)
	{
		var artist = artists.GetById(ArtistId);
		Console.WriteLine($"Album: \"{Name}\" by \"{artist?.Name}\":\n");
		StringBuilder trackContent = new();

		foreach (var track in _tracksIds)
		{
			var trackData = tracks.GetById(track);

			if (trackData is null) continue;

			trackContent.AppendLine(
				$"Track: \"{trackData.Name}\" \t\t Duration: {trackData.Duration}");
		}

		Console.WriteLine(trackContent.ToString());
		Console.WriteLine(
			$"\nFor listening to the whole album, it takes {GetAlbumDuration(tracks)}s");
	}
	
	public uint GetAlbumDuration(TrackRepository repository)
	{
		uint duration = 0;

		foreach (var track in _tracksIds)
		{
			var trackData = repository.GetById(track);

			if (trackData is null) continue;

			duration += trackData.Duration;
		}

		return duration;
	}
}
