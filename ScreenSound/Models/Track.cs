using ScreenSound.Views;


namespace ScreenSound.Models;


public class Track : Entity
{
	public Track(Artist artist, string name)
	{
		Artist = artist;
		Name   = name;
	}

	private readonly List<Review> _scores = new();

	public string Name      { get; }
	public Artist Artist    { get; }
	public uint   Duration  { get; set; }
	public bool   Available { get; set; }

	public string ShortDescription =>
		$"A this track, \"{Name}\", belongs to \"{Artist}\"";

	public void DisplayResume()
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
