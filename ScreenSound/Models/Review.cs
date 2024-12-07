namespace ScreenSound.Modelos;

public class Review
{
    public Review(int score)
    {
        Score = score;
    }

    public int Score { get; }

    public static Review Parse(string textScore)
    {
        var score = int.Parse(textScore);
        return new Review(score);
    }
}
