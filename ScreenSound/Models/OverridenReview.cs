namespace ScreenSound.Models;


internal class OverridenReview
{
    public OverridenReview(int nota)
    {
        Nota = nota;
    }

    public int Nota { get; }

    public static OverridenReview Parse(string texto)
    {
        int nota = int.Parse(texto);
        return new OverridenReview(nota);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not OverridenReview other) return false;
        return Nota.Equals(other.Nota);
    }

    public override int GetHashCode()
    {
        return Nota.GetHashCode();
    }

    public override string ToString()
    {
        return Nota.ToString();
    }
}
