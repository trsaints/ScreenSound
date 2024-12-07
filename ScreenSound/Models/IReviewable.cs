namespace ScreenSound.Models;

public interface IReviewable
{
    double AverageScore { get; }
    void AddReview(Review review);
}
