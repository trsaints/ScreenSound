namespace ScreenSound.Modelos;

public class Album : IReviewable
{
    private List<Track> musicas = new List<Track>();
    private List<Review> notas = new();

    public Album(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    public double Media
    {
        get
        {
            if (notas.Count == 0) return 0;
            else return notas.Average(nota => nota.Score);
        }
    }
    public List<Track> Musicas => musicas;

    public void AdicionarMusica(Track track)
    {
        musicas.Add(track);
    }

    public void AdicionarNota(Review nota)
    {
        notas.Add(nota);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Nome}:\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {DuracaoTotal}");
    }
}