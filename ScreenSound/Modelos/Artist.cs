namespace ScreenSound.Modelos;


public class Artist : IReviewable
{
	private List<Album>  albuns = new List<Album>();
	private List<Review> notas  = new List<Review>();

	public Artist(string nome)
	{
		Nome = nome;
	}

	public string Nome { get; }

	public double Media
	{
		get
		{
			if (notas.Count == 0) return 0;
			else return notas.Average(a => a.Score);
		}
	}

	public List<Album> Albuns => albuns;

	public void AdicionarAlbum(Album album)
	{
		albuns.Add(album);
	}

	public void AdicionarNota(Review nota)
	{
		notas.Add(nota);
	}

	public void ExibirDiscografia()
	{
		Console.WriteLine($"Discografia da banda {Nome}");

		foreach (Album album in albuns)
		{
			Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
		}
	}
}
