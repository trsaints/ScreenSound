using ScreenSound.Views;


namespace ScreenSound.Models;


public class Track : Entity
{
	private readonly List<Review> _reviews = new();
	public readonly  ulong        AlbumId;
	public readonly  ulong        ArtistId;
	public readonly  bool         Available;
	public readonly  uint         Duration;

	public readonly string Name;

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

	public override double AverageScore
	{
		get
		{
			if (_reviews.Count == 0) return 0;

			return _reviews.Average(review => review.Score);
		}
	}

	public void DisplayDetails()
	{
		var trackProperties = GetType().GetProperties();
		var trackInfo = trackProperties.ToDictionary(info => info.Name,
			info => info.GetValue(this).ToString()!);

		DetailsView detailsView = new("Track Details", trackInfo);
		detailsView.BuildLayout();
		detailsView.Display();
	}

	public override void AddReview(Review review)
	{
		_reviews.Add(review);
	}
}
