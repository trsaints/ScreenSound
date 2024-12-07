namespace ScreenSound.Modelos;


public class Track : IReviewable
{
    public Track(Artist artista, string nome)
    {
        Artista = artista;
        Nome = nome;
    }
    
    private List<Review> scores   = new();

    public string Nome { get; }
    public Artist Artista { get; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public string DescricaoResumida => $"A música {Nome} pertence à banda {Artista}";

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        } else
        {
            Console.WriteLine("Adquira o plano Plus+");
        }
    }

    public double Media
    {
        get
        {
            if (scores.Count == 0) return 0;
            else return scores.Average(nota => nota.Score);
        }
    }
    
    public void AdicionarNota(Review nota)
    {
        scores.Add(nota);
    }
}