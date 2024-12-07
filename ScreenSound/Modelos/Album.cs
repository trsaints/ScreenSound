namespace ScreenSound.Modelos;


public class Album : IReviewable
{
	public Album(string name)
	{
		Name = name;
	}

	private readonly List<Track>  _tracks = new();
	private readonly List<Review> _scores = new();

	public string Name          { get; }
	public long   AlbumDuration => _tracks.Sum(track => track.Duration);

	public double AverageScore
	{
		get
		{
			if (_scores.Count == 0) return 0;

			return _scores.Average(review => review.Score);
		}
	}

	public List<Track> Tracks => _tracks;

	public void AddTrack(Track track)
	{
		_tracks.Add(track);
	}

	public void AddReview(Review review)
	{
		_scores.Add(review);
	}

	public void DisplayAlbumTracks()
	{
		Console.WriteLine($"Track list of \"{Name}\":\n");

		foreach (var track in _tracks)
		{
			Console.WriteLine(
				$"Track: \"{track.Name}\" \t\t Duration: {track.Duration}");
		}

		Console.WriteLine(
			$"\nFor listening to the whole album, it takes {AlbumDuration}s");
	}
}
