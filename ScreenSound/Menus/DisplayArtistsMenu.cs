using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class DisplayArtistsMenu : Menu
{
    public override void Execute(Dictionary<string, Artist> registeredArtists)
    {
        base.Execute(registeredArtists);
        DisplayOptionTitle("Display All Artists");

        foreach (var artist in registeredArtists.Keys)
        {
            Console.WriteLine($"Artist: {artist}");
        }

        Console.WriteLine("\nPress any key to return.");
        Console.ReadKey();
        Console.Clear();
    }
}
