using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuSair : Menu
{
    public override void Executar(Dictionary<string, Artist> bandasRegistradas)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
