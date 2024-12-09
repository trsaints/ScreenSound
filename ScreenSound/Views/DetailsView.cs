namespace ScreenSound.Views;


public class DetailsView : View
{
	private readonly Dictionary<string, string> _details;

	public DetailsView(string title,
	                   Dictionary<string, string> details) :
		base(title)
	{
		_details = details;
	}

	public override string BuildLayout()
	{
		foreach (var detail in
		         _details)
			Layout.AppendLine($"{detail.Key}: {detail.Value}");
		
		return Layout.ToString();
	}
}
