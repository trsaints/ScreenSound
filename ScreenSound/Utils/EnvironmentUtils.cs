namespace ScreenSound.Utils;


public static class EnvironmentUtils
{
	public static readonly Dictionary<string, string> Variables
		= LoadVariables();

	private static Dictionary<string, string> LoadVariables()
	{
		Dictionary<string, string> environmentVariables = new();

		var filePath = Path.Combine(FileUtils.BaseDirectory, ".env");

		foreach (var row in File.ReadAllLines(filePath))
		{
			var kvPair = row.Split('=', StringSplitOptions.RemoveEmptyEntries);

			if (kvPair.Length is not 2)
				continue;

			environmentVariables.Add(kvPair[0], kvPair[1]);
		}

		return environmentVariables;
	}
}
