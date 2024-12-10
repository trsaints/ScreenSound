namespace ScreenSound.Models;


public abstract class Entity : IReviewable
{
	protected Entity(string name)
	{
		Id = NextId;
		Name = name;

		_ = ulong.TryParse(_generator.NextInt64().ToString(), out NextId);
	}

	public static ulong NextId;

	private readonly Random _generator = new();

	public ulong  Id   { get; }
	public string Name { get; }

	public abstract double AverageScore { get; }

	public abstract void AddReview(Review review);
}
