namespace ScreenSound.Modelos;

public interface IReviewable
{
    double Media { get; }
    void AdicionarNota(Review nota);
}
