using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class ReviewAlbumnMenu : Menu
{
    public override void Execute(Dictionary<string, Artist> bandasRegistradas)
    {
        base.Execute(bandasRegistradas);

        ExibirTituloDaOpcao("Avaliar álbum");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Artist artist = bandasRegistradas[nomeDaBanda];

            Console.Write("Agora digite o título do álbum: ");
            string tituloAlbum = Console.ReadLine()!;

            if (artist.Albuns.Any(a => a.Name.Equals(tituloAlbum)))
            {
                Album album = artist.Albuns.First(a => a.Name.Equals(tituloAlbum));
                Console.Write($"Qual a nota que o álbum {tituloAlbum} merece: ");
                Review nota = Review.Parse(Console.ReadLine()!);
                album.AddReview(nota);
                Console.WriteLine($"\nA nota {nota.Score} foi registrada com sucesso para o álbum {tituloAlbum}");
                Thread.Sleep(2000);
                Console.Clear();
            } 
            else
            {
                Console.WriteLine($"\nO álbum {tituloAlbum} não foi encontrado!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
