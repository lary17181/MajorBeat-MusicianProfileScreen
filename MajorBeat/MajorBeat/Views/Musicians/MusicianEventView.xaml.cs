using MajorBeat.Models;
using MajorBeat.ViewModels;
using MajorBeat.ViewModels.Musician;


namespace MajorBeat.Views.Musicians;

public partial class MusicianEventView : ContentPage
{
	public MusicianEventView(Evento evento)
	{
		InitializeComponent();
		BindingContext = new MusicianEventViewModel(evento);
	}

    private async void search_page_btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MusicianSearchPage());
    }

    private async void home_page_btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MusicianHomePage());
    }

    private async void profile_page_btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MusicianProfilePage());
    }
    private async void voltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}