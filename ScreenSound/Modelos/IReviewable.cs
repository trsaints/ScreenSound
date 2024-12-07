namespace ScreenSound.Modelos;

public interface IReviewable
{
    double AverageScore { get; }
    void AddReview(Review review);
}
