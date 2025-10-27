using MajorBeat.Models;
using MajorBeat.ViewModels;
using MajorBeat.ViewModels.Musician;
using MajorBeat.Views.Hirers;
using Microsoft.Extensions.Logging;


namespace MajorBeat.Views.Musicians;

public partial class MusicianEventView : ContentPage
{
	public MusicianEventView(Evento evento)
    {
		InitializeComponent();
        var vm = new MusicianEventViewModel(evento);

        // Define o BindingContext
        BindingContext = vm;
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

    private async void Calendar_page_btn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HirerCalendarPage());
    }
    private async void Voltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MusicianHomePage());
    }

}