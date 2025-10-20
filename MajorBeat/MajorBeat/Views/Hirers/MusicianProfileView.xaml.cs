using MajorBeat.ViewModels.Hirer;
namespace MajorBeat.Views.Hirers;
using MajorBeat.Models;
using MajorBeat.Views.Musicians;

public partial class MusicianProfileView : ContentPage
{
    private MusicianProfileViewModel _viewModel;
    public MusicianProfileView(Musico musico = null)
    {
        InitializeComponent();

        if (musico != null)
            _viewModel = new MusicianProfileViewModel(musico);
        else
            _viewModel = new MusicianProfileViewModel();
        BindingContext = _viewModel;

        ImageCarousel.PositionChanged += OnCarouselPositionChanged;

    }
    private void OnCarouselPositionChanged(object sender, PositionChangedEventArgs e)
    {
        _viewModel.SetCarouselIndex(e.CurrentPosition);
        PositionLabel.Text = $"{_viewModel.CurrentIndex + 1}/{_viewModel.Images.Count}";
    }

    // Navegação
    private async void search_page_btn_Clicked(object sender, EventArgs e) =>
        await Navigation.PushAsync(new MusicianSearchPage());

    private async void home_page_btn_Clicked(object sender, EventArgs e) =>
        await Navigation.PushAsync(new MusicianHomePage());

    private async void profile_page_btn_Clicked(object sender, EventArgs e) =>
        await Navigation.PushAsync(new MusicianProfilePage());


    private void OnGaleriaTapped(object sender, TappedEventArgs e)
    {
   
        UpdateTabStyles("Galeria");
        galeriaStack.IsVisible = true;
        sobreStack.IsVisible = false;
        avaliacoesStack.IsVisible = false;
    }

    private void OnSobreTapped(object sender, TappedEventArgs e)
    {
        UpdateTabStyles("Sobre");
        galeriaStack.IsVisible = false;
        sobreStack.IsVisible = true;
        avaliacoesStack.IsVisible = false;
    }

    private void OnAvaliacoesTapped(object sender, TappedEventArgs e)
    {
        UpdateTabStyles("Avaliacoes");
        galeriaStack.IsVisible = false;
        sobreStack.IsVisible = false;
        avaliacoesStack.IsVisible = true;
    }

    private void UpdateTabStyles(string tab)
    {
        switch (tab)
        {
            case "Galeria":
                TabGaleria.TextColor = Color.FromArgb("#4F1271");
                TabGaleria.FontAttributes = FontAttributes.Bold;
                BoxViewGaleria.HeightRequest = 4;
                BoxViewGaleria.BackgroundColor = Color.FromArgb("#4F1271");

                ResetOtherTabs("Galeria");
                break;

            case "Sobre":
                TabSobre.TextColor = Color.FromArgb("#4F1271");
                TabSobre.FontAttributes = FontAttributes.Bold;
                BoxViewSobre.HeightRequest = 4;
                BoxViewSobre.BackgroundColor = Color.FromArgb("#4F1271");

                ResetOtherTabs("Sobre");
                break;

            case "Avaliacoes":
                TabAvaliacoes.TextColor = Color.FromArgb("#4F1271");
                TabAvaliacoes.FontAttributes = FontAttributes.Bold;
                BoxViewAvaliacoes.HeightRequest = 4;
                BoxViewAvaliacoes.BackgroundColor = Color.FromArgb("#4F1271");

                ResetOtherTabs("Avaliacoes");
                break;
        }
    }

    // Resetando as outras abas
    private void ResetOtherTabs(string activeTab)
    {
        if (activeTab != "Galeria")
        {
            TabGaleria.TextColor = Color.FromArgb("#783F8E");
            TabGaleria.FontAttributes = FontAttributes.None;
            BoxViewGaleria.HeightRequest = 3;
            BoxViewGaleria.BackgroundColor = Color.FromArgb("#783F8E");
        }

        if (activeTab != "Sobre")
        {
            TabSobre.TextColor = Color.FromArgb("#783F8E");
            TabSobre.FontAttributes = FontAttributes.None;
            BoxViewSobre.HeightRequest = 3;
            BoxViewSobre.BackgroundColor = Color.FromArgb("#783F8E");
        }

        if (activeTab != "Avaliacoes")
        {
            TabAvaliacoes.TextColor = Color.FromArgb("#783F8E");
            TabAvaliacoes.FontAttributes = FontAttributes.None;
            BoxViewAvaliacoes.HeightRequest = 3;
            BoxViewAvaliacoes.BackgroundColor = Color.FromArgb("#783F8E");
        }
    }
}

