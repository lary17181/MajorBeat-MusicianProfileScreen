namespace MajorBeat.ViewModels.Musician;

public class MusicianHomeViewModel : ContentPage
{
	public MusicianHomeViewModel()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}