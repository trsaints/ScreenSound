namespace ScreenSound.Models;


internal class OverridenReview
{
	public OverridenReview(int score)
	{
		Score = score;
	}

	public int Score { get; }

	public static OverridenReview Parse(string texto)
	{
		var nota = int.Parse(texto);

		return new OverridenReview(nota);
	}

	public override bool Equals(object? obj)
	{
		return obj is OverridenReview other && Score.Equals(other.Score);
	}

	public override int GetHashCode()
	{
		return Score.GetHashCode();
	}

	public override string ToString()
	{
		return Score.ToString();
	}
}
