namespace ScreenSound.Models;


public abstract class Entity : IReviewable
{
	public static ulong NextId;

	private readonly Random _generator = new();

	public readonly ulong Id;

	protected Entity()
	{
		Id = NextId;

		_ = ulong.TryParse(_generator.NextInt64().ToString(), out NextId);
	}

	public abstract double AverageScore { get; }

	public abstract void AddReview(Review review);
}
