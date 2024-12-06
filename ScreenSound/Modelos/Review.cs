namespace ScreenSound.Modelos;

internal class Review
{
    public Review(int nota)
    {
        Nota = nota;
    }

    public int Nota { get; }

    public static Review Parse(string texto)
    {
        int nota = int.Parse(texto);
        return new Review(nota);
    }
}
