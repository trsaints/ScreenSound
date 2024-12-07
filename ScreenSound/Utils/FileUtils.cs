namespace ScreenSound.Utils;


public static class FileUtils
{
	public static readonly string BaseDirectory =
		Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder
			                                     .ApplicationData),
			"TRSaints",
			"ScreenSound");

	public static readonly string StorageDirectory =
		Path.Combine(BaseDirectory, "Storage");

	public static readonly string LayoutsDirectory =
		Path.Combine(BaseDirectory, "Layouts");

	public static void Initialize()
	{
		string[] mainDirectories =
			{ BaseDirectory, StorageDirectory, LayoutsDirectory };

		foreach (var dir in mainDirectories)
		{
			if (Directory.Exists(dir)) continue;

			Directory.CreateDirectory(dir);
		}
	}
}
