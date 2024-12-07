
using ScreenSound.Models;


namespace ScreenSound.Menus;

internal class Menu
{
    public void DisplayOptionTitle(string title)
    {
        var letterCount = title.Length;
        var asterisks = string.Empty.PadLeft(letterCount, '*');
        Console.WriteLine(asterisks);
        Console.WriteLine(title);
        Console.WriteLine(asterisks + "\n");
    }
    public virtual void Execute(Dictionary<string, Artist> registeredArtists)
    {
        Console.Clear();
    }
}
