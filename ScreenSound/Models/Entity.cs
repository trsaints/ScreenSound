namespace ScreenSound.Models;


public abstract class Entity : IReviewable
{
	protected Entity()
	{
		Id = NextId;

		_ = ulong.TryParse(_generator.NextInt64().ToString(), out NextId);
	}

	public readonly ulong Id;

	private readonly Random _generator = new();

	public static   ulong  NextId;
	
	public abstract double AverageScore { get; }
	
	public abstract void AddReview(Review review);
}
