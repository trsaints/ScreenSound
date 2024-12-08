using ScreenSound.Views;


namespace ScreenSound.Models;


public class Track : Entity
{
	public Track(ulong artistId,
	             ulong albumId,
	             string name,
	             uint duration,
	             bool available)
	{
		ArtistId  = artistId;
		AlbumId   = albumId;
		Name      = name;
		Duration  = duration;
		Available = available;
	}

	private readonly List<Review> _scores = new();

	public readonly string Name;
	public readonly ulong  ArtistId;
	public readonly ulong  AlbumId;
	public readonly uint   Duration;
	public readonly bool   Available;

	public void DisplayDetails()
	{
		var trackProperties = GetType().GetProperties();
		var trackInfo = trackProperties.ToDictionary(info => info.Name,
			info => info.GetValue(this).ToString()!);

		DetailsView detailsView = new("Track Details", trackInfo);
		detailsView.BuildLayout();
		detailsView.Display();
	}

	public override double AverageScore
	{
		get
		{
			if (_scores.Count == 0) return 0;

			return _scores.Average(review => review.Score);
		}
	}

	public override void AddReview(Review review)
	{
		_scores.Add(review);
	}
}
