namespace ScreenSound.Views;


public class DetailsView : View
{
	public DetailsView(string title,
	                   Dictionary<string, string> details) :
		base(title)
	{
		_details = details;
	}

	private readonly Dictionary<string, string> _details;

	public override void BuildLayout()
	{
		foreach (var detail in
		         _details)
			Layout.AppendLine($"{detail.Key}: {detail.Value}");
	}
}
