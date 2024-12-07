using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class RegisterArtistMenu : Menu
{
    public override void Execute(Dictionary<string, Artist> bandasRegistradas)
    {
        base.Execute(bandasRegistradas);
        ExibirTituloDaOpcao("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Artist artist = new Artist(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, artist);
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
        Thread.Sleep(4000);
        Console.Clear();
    }
}
