namespace ScreenSound.Modelos;


public class Track : IReviewable
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
		Console.WriteLine($"Nome: {Name}");
		Console.WriteLine($"Artista: {Artist.Nome}");
		Console.WriteLine($"Duração: {Duration}");

		Console.WriteLine(Available
			                  ? "Disponível no plano."
			                  : "Adquira o plano Plus+");
	}

	public double AverageScore
	{
		get
		{
			if (_scores.Count == 0) return 0;

			return _scores.Average(review => review.Score);
		}
	}

	public void AddReview(Review review)
	{
		_scores.Add(review);
	}
}
