namespace ScreenSound.Modelos;


public class Track
{
    public Track(Artist artista, string nome)
    {
        Artista = artista;
        Nome = nome;
    }

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

    public double Media { get; }
    
    public void AdicionarNota(Review nota)
    {
        throw new NotImplementedException();
    }
}