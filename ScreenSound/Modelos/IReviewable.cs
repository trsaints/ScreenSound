namespace ScreenSound.Modelos;

internal interface IReviewable
{
    double Media { get; }
    void AdicionarNota(Review nota);
}
