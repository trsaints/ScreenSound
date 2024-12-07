using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class ExitMenu : Menu
{
    public override void Execute(Dictionary<string, Artist> bandasRegistradas)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
